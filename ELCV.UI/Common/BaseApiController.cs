using ELCV.Core.Common;
using Microsoft.AspNetCore.Mvc;
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
        public object CheckValidEntity(object entity)
        {
            if (entity!= null)
            return NotFound(_errorHandler.JsonErrorMessage((int)HttpStatusCode.NotFound));
            return entity;
        } 
      
    }
}
