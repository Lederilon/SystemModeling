using System.Collections.Generic;

public class Job
{
   public List<Relation> Parents{get ;private set;}

   public List<Relation> Children{get; private set;}

   public long Weight{get; private set;}

   public void AddParent(Job parentJob, long weight)
   {
       Parents.Add(new Relation(parentJob, weight));
   }

   public void AddChild(Job childJob, long weight)
   {
       Children.Add(new Relation(childJob, weight));
   }
   public long Id{get; private set;}

   public Job(long id, long weight)
   {
       Parents = new List<Relation>();
       Children = new List<Relation>();
       Id = id;
       Weight = weight;
   }
}