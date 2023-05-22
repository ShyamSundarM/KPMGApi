using KPMGApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KPMGApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ChartController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ChartController(AppDbContext context)
        {

            _context = context;

        }
        [HttpGet("GetBrowsers")]
        public async Task<ActionResult<List<Browser>>> Browsers()
        {
            try
            {
                 return await _context.Browsers.ToListAsync();
            }
            catch (Exception e)
            {
                return StatusCode(500, new ErrorResponse { ErrorMessage = e.Message});  
            }
        }

        [HttpGet("GetJobEmployments")]
        public async Task<ActionResult<List<JobEmployment>>> JobEmployments()
        {
            try
            {
                return await _context.JobEmployments.ToListAsync();
            }
            catch (Exception e)
            {
                return StatusCode(500, new ErrorResponse { ErrorMessage = e.Message });
            }
        }

        [HttpGet("GetRainTimelines")]
        public async Task<ActionResult<List<RainTimeline>>> RainTimelines()
        {
            try
            {
                return await _context.RainTimeline.ToListAsync();
            }
            catch (Exception e)
            {
                return StatusCode(500, new ErrorResponse { ErrorMessage = e.Message });
            }
        }



    }
}
