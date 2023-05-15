using ContactList.Core.Application;
using Microsoft.AspNetCore.Mvc;

namespace ContactList.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BalancedSupportsController : Controller
    {
        [HttpPost]
        public IActionResult VerifyBalancedSupports([FromBody] string text)
        {
            try
            {
                return Ok(BalancedSupportsAppService.VerifyBalancedSupports(text));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
