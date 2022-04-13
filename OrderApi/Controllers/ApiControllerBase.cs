using Microsoft.AspNetCore.Mvc;

namespace OrderApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : ControllerBase { }
}