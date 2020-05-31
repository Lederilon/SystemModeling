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