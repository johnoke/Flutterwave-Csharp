<<<<<<< HEAD:Flutterwave/Utilities/ApiResponse.cs
﻿namespace Flutterwave.Csharp.Utilities
{
    public class ApiResponse
    {
        public bool IsSuccessfulResponse { get; set; }
        public string StatusCode { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string ResponseData { get; set; }
        public bool RequiresValidation { get; set; }
        public ApiResponse()
        {
            this.IsSuccessfulResponse = false;
            this.RequiresValidation = false;
            this.ResponseCode = "00";
        }   
        
    }
}
=======
﻿namespace Flutterwave.Utilities.Api
{
    public class Response
    {
        public bool IsSuccessfulResponse { get; set; }
        public string StatusCode { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string ResponseData { get; set; }
        public bool RequiresValidation { get; set; }
        public Response()
        {
            this.IsSuccessfulResponse = false;
            this.RequiresValidation = false;
            this.ResponseCode = "00";
        } 
        
    }
}
>>>>>>> 50ce768f59cf5cb025831deaf220bf221998f2ae:Flutterwave/Utilities/Api/Response.cs
