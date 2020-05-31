public class Relation
{
    public Job RelatedJob{get; private set;}

    public long Weight{get; private set;}
    public Relation(Job relatedJob, long weight)
    {
        RelatedJob = relatedJob;
        Weight = weight;
    }    
} 