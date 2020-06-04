using System.Collections.Generic;
using System.Linq;

public class ProcessorSellector
{
    public ProcessorSellector(ComputingSystem system)
    {
        _system = system;
    }

    private ComputingSystem _system;

    public long GetNextProcessor()
    {
        return 0;
    }
}

public class ProcessorSorter 
{
    public ProcessorSorter()
    {

    }

    public List<Processor> SortProcessors(ComputingSystem system)
    {
        var processorsOrder = system.OrderByDescending(p=>p.Children.Count + p.Parents.Count);
        return processorsOrder.ToList();
    }
}