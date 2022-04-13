using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderApi.DAL.Interfaces;
using OrderApi.Extensions;

namespace OrderApi.Controllers
{
    public class PostTerminalsController : ApiControllerBase
    {
        private readonly IPostTerminalRepository _terminalsRepository;

        public PostTerminalsController(IPostTerminalRepository terminalsRepository)
        {
            _terminalsRepository = terminalsRepository;
        }

        [HttpGet]
        [Route("active")]
        public async Task<IActionResult> GetActivePostTerminals()
        {
            var result = await _terminalsRepository.GetPostTerminals()
                .Where(t => t.IsActive)
                .OrderBy(t => t.Number)
                .ToListAsync();

            return Ok(result);
        }

        [HttpGet]
        [Route("{postTerminalNumber}")]
        [PostTerminalNumberFilter(ActionArgumentName = "postTerminalNumber")]
        public async Task<IActionResult> GetPostTerminalInfo([FromRoute] string postTerminalNumber)
        {
            var result = await _terminalsRepository.GetPostTerminalAsync(postTerminalNumber);

            if (result == null)
                return StatusCode(StatusCodes.Status404NotFound, $"Post terminal with number={postTerminalNumber} is not found.");

            return Ok(result);
        }
    }
}