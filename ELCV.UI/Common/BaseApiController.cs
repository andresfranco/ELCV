using Microsoft.AspNetCore.Mvc;

namespace ELCV.UI.WebApi.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : Controller
    {
    }
}
