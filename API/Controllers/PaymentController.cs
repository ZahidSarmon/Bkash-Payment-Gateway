using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System;
using api.Data;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public PaymentController(
            ApplicationDbContext coreAdminContext)
        {
            _dbContext = coreAdminContext;
        }

        public IConfigurationRoot Configuration { get; set; }
        [HttpGet("GetData")]
        [AllowAnonymous]
        public async Task<IActionResult> GetData()
        {
            try{
                return Ok();
            }catch(Exception ex)
            {
                return await this.BadRequest(ex);
            }
        }
        public async Task<IActionResult> BadRequest(Exception ex)
        {
            if (ex.InnerException != null)
                return BadRequest(ex.InnerException.Message);
            return BadRequest(ex.Message);
        }
    }
    
}