using System.Collections.Generic;

public class Job
{
   public List<Job> Parents{get ;private set;}

   public List<Job> Children{get; private set;}

   public long Weight{get; private set;}

   public void AddParent(Job parentJob)
   {
       Parents.Add(parentJob);
   }

   public long Id{get; private set;}

   public Job(long id, long weight)
   {
       Parents = new List<Job>();
       Children = new List<Job>();
       Id = id;
       Weight = weight;
   }
}