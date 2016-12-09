namespace Flutterwave.Utilities.Api
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
