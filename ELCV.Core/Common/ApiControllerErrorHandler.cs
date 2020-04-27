using System.Net;
using Newtonsoft.Json;

namespace ELCV.Core.Common
{
    public class ApiControllerErrorHandler
    {

        public string JsonErrorMessage(int statusCode,string ErrorMessage="")
        {
            var apiError = new ApiError()
            {
                StatusCode =statusCode,
                Message = GetErrorMessage(statusCode,ErrorMessage)
            };
            

           var jsonError = JsonConvert.SerializeObject(apiError);
           return jsonError;
        }
        public string GetErrorMessage(int statusCode,string ErrorMessage)
        {
           
            if (statusCode == (int)HttpStatusCode.NotFound) return "Invalid Model Data";
            if (statusCode == (int)HttpStatusCode.BadRequest) return "Bad Request:" + ErrorMessage;
            if (statusCode == (int)HttpStatusCode.OK) return "Operation completed successfully";
            return "Bad Request-Server Error";

        }


    }
}
