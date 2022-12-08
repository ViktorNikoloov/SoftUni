namespace Tree;

using System.Collections.Generic;

public class IntegerTree : Tree<int>, IIntegerTree
{
    public IntegerTree(int key, params Tree<int>[] children)
        : base(key, children)
    {
    }

    public IEnumerable<IEnumerable<int>> GetPathsWithGivenSum(int sum)
    {
        List<List<int>> result = new ();

        LinkedList<int> currentPath = new();
        currentPath.AddFirst(this.Key);

        int currentSum = this.Key;
        this.Dfs(this, result, currentPath, ref currentSum, sum);

        return result;
    }

    public IEnumerable<Tree<int>> GetSubtreesWithGivenSum(int sum)
    {
        List<Tree<int>> result = new();
        var allSubtrees = this.GetAllNodesBfs();

        foreach (var subtree in allSubtrees)
        {
            if (this.HasGivenSum(subtree, sum))
            {
                result.Add(subtree);
            }
        }

        return result;
    }

    private bool HasGivenSum(Tree<int> subtree, int wantedSum)
    {
        int actualSum = subtree.Key;
        this.DfsGetSubtreeSum(subtree, wantedSum, ref actualSum);

        return actualSum == wantedSum;
    }

    private void DfsGetSubtreeSum(Tree<int> subtree, int wantedSum, ref int actualSum)
    {
        foreach (var child in subtree.Children)
        {
            actualSum += child.Key;
            this.DfsGetSubtreeSum(child, wantedSum, ref actualSum);
        }
    }

    private List<Tree<int>> GetAllNodesBfs()
    {
        List<Tree<int>> result = new();
        Queue<Tree<int>> queue = new();

        queue.Enqueue(this);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            result.Add(current);

            foreach (var child in current.Children)
            {
                queue.Enqueue(child);
            }
        }

        return result;
    }

    private void Dfs(
        Tree<int> subtree,
        List<List<int>> result,
        LinkedList<int> currentPath,
        ref int currentSum,
        int wantedSum)
    {
        foreach (var child in subtree.Children)
        {
            currentSum += child.Key;
            currentPath.AddLast(child.Key);

            this.Dfs(child, result, currentPath, ref currentSum, wantedSum);
        }

        if (currentSum == wantedSum)
        {
            result.Add(new List<int>(currentPath));
        }

        currentSum -= subtree.Key;
        currentPath.RemoveLast();
    }
}
