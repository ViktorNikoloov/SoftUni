namespace Tree;

using System;
using System.Collections.Generic;

public class Tree<T> : IAbstractTree<T>
{
    private List<Tree<T>> children;
    private T value;
    private Tree<T> parent; 

    public Tree(T value)
    {
        this.value = value;
        this.children = new List<Tree<T>>();
    }

    public Tree(T value, params Tree<T>[] children)
        : this(value)
    {
        foreach (var child in children)
        {
            child.parent = this;
            this.children.Add(child);
        }
    }

    public void AddChild(T parentKey, Tree<T> child)
    {
        var parentNode = this.FindNodeWithBfs(parentKey);
        if (parentNode is null)
        {
            throw new ArgumentNullException();
        }

        parentNode.children.Add(child);
        child.parent = parentNode;
    }

    public IEnumerable<T> OrderBfs()
    {
        Queue<Tree<T>> queue = new ();
        List<T> result = new ();

        queue.Enqueue(this);

        while (queue.Count > 0)
        {
            var subtree = queue.Dequeue();
            result.Add(subtree.value);

            foreach (var child in subtree.children)
            {
                queue.Enqueue(child);
            }
        }

        return result;
    }

    public IEnumerable<T> OrderDfs()
    {
        List<T>list = new ();
        this.Dfs(this, list);

        return list;
    }

    public IEnumerable<T> OrderDfsWithStack()
    {
        Stack<T> result = new();
        Stack<Tree<T>> stack = new ();
        stack.Push(this);

        while (stack.Count > 0)
        {
            var node = stack.Pop();

            foreach (var child in node.children)
            {
                stack.Push(child);
            }
        }

        return result;
    }

    public void RemoveNode(T nodeKey)
    {
        var toBeDeleteNode = this.FindNodeWithBfs(nodeKey);
        if (toBeDeleteNode is null)
        {
            throw new ArgumentNullException();
        }

        var parentNode = toBeDeleteNode.parent;
        if (parentNode is null)
        {
            throw new ArgumentException();
        }

        parentNode.children.Remove(toBeDeleteNode);
    }

    public void Swap(T firstKey, T secondKey)
    {
        var firstNode = this.FindNodeWithBfs(firstKey);
        var secondNode = this.FindNodeWithBfs(secondKey);
        if (firstNode is null || secondNode is null)
        {
            throw new ArgumentNullException();
        }

        var firstParent = firstNode.parent;
        var secondParent = secondNode.parent;
        if (firstParent is null || secondParent is null)
        {
            throw new ArgumentException();
        }

        var indexofFirstChild = firstParent.children.IndexOf(firstNode);
        var indexofSecondChild = secondParent.children.IndexOf(secondNode);

        firstParent.children[indexofFirstChild] = secondNode;
        secondNode.parent = firstParent;

        secondParent.children[indexofSecondChild] = firstNode;
        firstNode.parent = secondParent;
    }

    private void Dfs(Tree<T> node, ICollection<T> result)
    {
        foreach (var child in node.children)
        {
            this.Dfs(child, result);
        }

        result.Add(node.value);
    }

    private Tree<T> FindNodeWithBfs(T parentNode)
    {
        Queue<Tree<T>> queue = new();

        queue.Enqueue(this);

        while (queue.Count > 0)
        {
            var subtree = queue.Dequeue();

            if (subtree.value.Equals(parentNode))
            {
                return subtree;
            }

            foreach (var child in subtree.children)
            {
                queue.Enqueue(child);
            }
        }

        return null;
    }
}
