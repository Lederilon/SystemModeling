namespace Controllers
{
    public class AllocationTask
    {
        public int[] Weights {get; set;}

        public int[][] JobRelations {get; set;}

        public int[][] ProcessorRelations {get; set;}
    }

    public class AllocationResult
    {
        public int[] JobSorting {get; set;}

        public int[] ProcessorSorting{get; set;}

        public int[][] Allocations {get; set;}
    }
}