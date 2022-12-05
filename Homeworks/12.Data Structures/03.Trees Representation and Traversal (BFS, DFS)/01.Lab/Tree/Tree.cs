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
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }

    public void Swap(T firstKey, T secondKey)
    {
        throw new NotImplementedException();
    }

    private void Dfs(Tree<T> node, ICollection<T> result)
    {
        foreach (var child in node.children)
        {
            this.Dfs(child, result);
        }

        result.Add(node.value);
    }

}
