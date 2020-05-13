using ELCV.Core.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace ELCV.UI.WebApi.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : Controller
    {
        public  ApiControllerErrorHandler _errorHandler;
        public BaseApiController(ApiControllerErrorHandler errorHandler)
        {
            _errorHandler = errorHandler;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(a => a.Value.Errors.Count > 0)
                    .SelectMany(x => x.Value.Errors)
                    .ToList();
                context.Result = Json(errors);
            }
            base.OnActionExecuting(context);
        }


    }
}
