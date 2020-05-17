using System;
using System.Collections.Generic;
using System.Linq;

public class CriticalPathByTime
{
    public CriticalPathByTime()
    {
    }

    public IEnumerable<Job> GetJobOrder(TaskGraph graph)
    {
        var taskOrder = new List<Job>();
        var order = new SortedList<long, Job>(new DuplicateKeyComparer<long>());
        fillCriticalPath(graph.FinishTask, 0, order);
        return order.Select( kvp => kvp.Value);
    }

    private void fillCriticalPath(Job job, long depth, SortedList<long, Job> jobOrder)
    {
        var addedDepth = job.Weight;
        var totalDepth = addedDepth + depth;
        foreach(var childJob in job.Children)
        {
            fillCriticalPath(job, totalDepth, jobOrder);
        }
        jobOrder.Add(totalDepth, job);
    }
}

public class ByWeight
{
     public IEnumerable<Job> GetJobOrder(TaskGraph graph)
    {
        var jobs = graph.Select(j => j);
        return jobs.OrderBy( j=> j.Weight);
    }

}

public class DuplicateKeyComparer<TKey>
                :
             IComparer<TKey> where TKey : IComparable
{
    #region IComparer<TKey> Members

    public int Compare(TKey x, TKey y)
    {
        int result = x.CompareTo(y);

        if (result == 0)
            return 1;   // Handle equality as beeing greater
        else
            return result;
    }

    #endregion
}