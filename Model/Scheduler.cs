public class Scheduler
{
    private IJobSorter _sorter;

    public Scheduler()
    {
        _sorter = new CriticalPathByTime();
    }

    public Schedule Allocate(TaskGraph graph, ComputingSystem system)
    {
        var jobsOrder = _sorter.GetJobOrder(graph);
        return new Schedule();

    }
}