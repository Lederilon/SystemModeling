using System.Collections.Generic;

public class Job
{
   public List<Relation> Parents{get ;private set;}

   public List<Relation> Children{get; private set;}

   public int Weight{get; private set;}

   public bool Allocated {get; set;}
   public void AddParent(Job parentJob, int weight)
   {
       Parents.Add(new Relation(parentJob, weight));
   }

   public void AddChild(Job childJob, int weight)
   {
       Children.Add(new Relation(childJob, weight));
   }
   public int Id{get; private set;}

   public Job(int id, int weight)
   {
       Parents = new List<Relation>();
       Children = new List<Relation>();
       Id = id;
       Weight = weight;
   }

   public override int GetHashCode()
   {
       return Id * 213 + 27;
   }

    public override bool Equals(object? obj)
    {
        return Id == ((Job)obj).Id;
    }
}