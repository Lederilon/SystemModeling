using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TaskGraph : IEnumerable<Job>
{
    public IEnumerator<Job> GetEnumerator()
    {
        return _jobs.Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
       return _jobs.Values.GetEnumerator();
    }

    public IEnumerable<Job> FinishTasks => _jobs.Values.Where( j=> !j.Children.Any());

    private Dictionary<long, Job> _jobs;

    public TaskGraph()
    {
        _jobs = new Dictionary<long, Job>();
    }

    public void AddTask(Job job)
    {
       _jobs[job.Id] = job; 
    }
}