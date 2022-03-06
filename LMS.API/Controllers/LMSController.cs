using LMS.Services.Models;
using LMS.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LMSController : ControllerBase
    {
        private readonly ILMSService lmsService;
        private readonly ILogger<LMSController> _logger;

        public LMSController(ILMSService lmsService, ILogger<LMSController> logger)
        {
            this.lmsService = lmsService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var entities = await lmsService.GetLMSEntities();
            return Ok(entities);
        }
    }
}