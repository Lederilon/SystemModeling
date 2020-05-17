using System.Collections;
using System.Collections.Generic;

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

    public Job FinishTask {get; private set;}

    private Dictionary<long, Job> _jobs;

    public TaskGraph(Job finishTask)
    {
        _jobs = new Dictionary<long, Job>();

        FinishTask = finishTask;
        _jobs[FinishTask.Id] = finishTask;
    }

    public void AddTask(Job job)
    {
       _jobs[job.Id] = job; 
    }
}