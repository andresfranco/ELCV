using System.Net;
using Newtonsoft.Json;

namespace ELCV.Core.Common
{
    public class ApiControllerErrorHandler
    {

        public string JsonErrorMessage(string erroMessage)
        {
            var apiError = new ApiError()
            {
                StatusCode =(int) HttpStatusCode.NotFound,
                Message = erroMessage
            };
           var jsonError = JsonConvert.SerializeObject(apiError);
           return jsonError;
        }

    }
}
