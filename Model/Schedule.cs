public class Schedule
{
    public System.Collections.Generic.IEnumerable<Allocation> Allocations {get; private set;}

    public Schedule()
    {

    }
}

public class Allocation
{
    public Job AllocatedJob {get; private set;}

    public long Processor {get; set;}

    public long Start {get; set;}

    public long Finish {get; set;}

    public  Allocation(Job allocateJob)
    { 
        AllocatedJob = allocateJob;
    }
}