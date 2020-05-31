using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AllocationsController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody]AllocationTask allocationTask)
        {
            if (allocationTask == null)
            {
                return BadRequest();
            }
            return "top";
        }
    }
}