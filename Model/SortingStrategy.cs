using System;
using System.Collections.Generic;
using System.Linq;

public interface IJobSorter
{
   IEnumerable<Job> GetJobOrder(TaskGraph graph); 
}


public class CriticalPathByTime : IJobSorter
{
    public CriticalPathByTime()
    {
    }

    public IEnumerable<Job> GetJobOrder(TaskGraph graph)
    {
        var taskOrder = new List<Job>();
        var order = new SortedList<long, Job>(new DuplicateKeyComparer<long>());
        foreach(var finishTask in graph.FinishTasks)
        {
             fillCriticalPath(finishTask, 0, order);
        }
        return order.Select( kvp => kvp.Value);
    }

    private void fillCriticalPath(Job job, long depth, SortedList<long, Job> jobOrder)
    {
        var addedDepth = job.Weight;
        var totalDepth = addedDepth + depth;
        foreach(var childJob in job.Parents)
        {
            fillCriticalPath(childJob.RelatedJob, totalDepth + childJob.Weight, jobOrder);
        }
        jobOrder.Add(totalDepth, job);
    }
}

public class ByWeight : IJobSorter
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