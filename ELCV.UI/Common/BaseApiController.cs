using ELCV.Core.Common;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
       
        
    }
}
