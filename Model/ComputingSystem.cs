using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ComputingSystem : IEnumerable<Processor>
{
    public IEnumerator<Processor> GetEnumerator()
    {
        return _processors.Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() => _processors.Values.GetEnumerator();

    public IEnumerable<Processor> FinishTasks => _processors.Values.Where( j=> !j.Children.Any());

    private Dictionary<long, Processor> _processors;

    public ComputingSystem()
    {
        _processors = new Dictionary<long, Processor>();
    }

    public void AddProcessor(Processor job)
    {
       _processors[job.Id] = job; 
    }
}

public class TickState
{
    public List<Processor> ReadyProcessors {get; set;}

    public List<Job> ReadyJobs {get; set;}

    public int[] JobsInProcess {get; set;}
}

public class Link
{
    public Processor RelatedJob{get; private set;}

    public long Weight{get; private set;}
    public Link(Processor relatedJob, long weight)
    {
        RelatedJob = relatedJob;
        Weight = weight;
    }    
}

public class Processor
{
    public int Id {get; set;}

    public List<Link> Parents{get ;private set;}

   public List<Link> Children{get; private set;}

   public long Weight{get; private set;}

   public void AddParent(Processor parentJob, long weight)
   {
       Parents.Add(new Link(parentJob, weight));
   }

   public void AddChild(Processor childJob, long weight)
   {
       Children.Add(new Link(childJob, weight));
   }

   public Processor(int id)
   {
       Id = id;
       Parents = new List<Link>();
       Children = new List<Link>();
   }
}