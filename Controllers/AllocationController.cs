using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AllocationsController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<AllocationResult>> Post([FromBody]AllocationTask allocationTask)
        {
            if (allocationTask == null)
            {
                return BadRequest();
            }

            var nodesCount = allocationTask.Weights.Length;

            var nodeNumber = 1;

            var nodes = new List<Job>();

            var tasksGraph = new TaskGraph();

            foreach(var nodeWeight in allocationTask.Weights)
            {
                var node = new Job(nodeNumber, nodeWeight);
                nodes.Add(node);
                tasksGraph.AddTask(node);
                nodeNumber++;
            }

            for(int i = 0;  i < nodesCount; i ++)
            {
                for(int j = 0; j < nodesCount; j ++)
                {
                    if(allocationTask.JobRelations[i][j] == 0)
                    {
                        continue;
                    }
                    var parentJob = nodes[i];
                    var childJob = nodes[j];
                    var weight = allocationTask.JobRelations[i][j];

                    childJob.AddParent(parentJob, weight);
                    parentJob.AddChild(childJob, weight);

                }
        
            }

            var jobsSorter = new CriticalPathByTime();

            var jobsOrder = jobsSorter.GetJobOrder(tasksGraph);


            var allocationResult = new AllocationResult()
            {
                JobSorting = jobsOrder.Reverse().Select(jobsOrder=> jobsOrder.Id).ToArray()
            };


 
            return allocationResult;
        }
    }
}