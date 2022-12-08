namespace Tree;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Tree<T> : IAbstractTree<T>
{
    private List<Tree<T>> children;

    public Tree(T key, params Tree<T>[] children)
    {
        this.Key = key;
        this.children = new List<Tree<T>>(children);

        foreach (var child in children)
        {
            this.AddChild(child);
            child.Parent = this;
        }
    }

    public T Key { get; private set; }

    public Tree<T> Parent { get; private set; }

    public IReadOnlyCollection<Tree<T>> Children => this.children.AsReadOnly();

    public void AddChild(Tree<T> child)
    {
        this.children.Add(child);
    }

    public void AddParent(Tree<T> parent)
    {
        this.Parent = parent;
    }

    public string AsString()
    {
        var sb = new StringBuilder();
        this.DfsAsString(sb, this, 0);

        return sb.ToString().Trim();
    }

    private void DfsAsString(StringBuilder sb, Tree<T> tree, int indent)
    {
        sb.Append(' ', indent)
          .AppendLine(tree.Key.ToString());

        foreach (var child in tree.children)
        {
            this.DfsAsString(sb, child, indent + 2);
        }
    }

    public IEnumerable<T> GetInternalKeys()
    {
        return this.BfsWithResultKeys(tree => tree.children.Count != 0 && tree.Parent != null)
            .Select(node=>node.Key);
    }

    public IEnumerable<T> GetLeafKeys()
    {
        return this.BfsWithResultKeys(tree => tree.children.Count == 0)
            .Select(node=>node.Key);
    }

    private IEnumerable<Tree<T>> BfsWithResultKeys(Predicate<Tree<T>> predicate)
    {
        List<Tree<T>> result = new();
        Queue<Tree<T>> queue = new();
        queue.Enqueue(this);

        while (queue.Count > 0)
        {
            var currentSubTree = queue.Dequeue();

            if (predicate.Invoke(currentSubTree))
            {
                result.Add(currentSubTree);
            }

            foreach (var child in currentSubTree.children)
            {
                queue.Enqueue(child);
            }
        }

        return result;
    }

    public T GetDeepestKey()
    {
        return this.GetDeepestNode().Key;
    }

    private Tree<T> GetDeepestNode()
    {
        var allleafs = this.BfsWithResultKeys(tree => tree.children.Count == 0);
        Tree<T> deepestNode = null;
        var maxDepth = 0;

        foreach (var leaf in allleafs)
        {
            var depth = this.GetDepth(leaf);
            if (depth > maxDepth)
            {
                maxDepth = depth;
                deepestNode = leaf;
            }
        }

        return deepestNode;
    }

    private int GetDepth(Tree<T> leaf)
    {
        int depth = 0;
        var tree = leaf;
        while(tree.Parent is not null)
        {
            depth++;
            tree = tree.Parent;
        }

        return depth;
    }

    public IEnumerable<T> GetLongestPath()
    {
        Stack <T> result = new();

        var deepestNode = this.GetDeepestNode();
        while (deepestNode.Parent is not null)
        {
            result.Push(deepestNode.Key);
            deepestNode = deepestNode.Parent;
        }
        result.Push(deepestNode.Key);

        return new List<T>(result);
    }
}
