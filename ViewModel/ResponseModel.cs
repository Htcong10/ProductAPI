using ProductAPI.Enums;

namespace ProductAPI.ViewModel
{
    public class ResponseModel
    {

        public ResponseModel(ResponseCode responseCode, string responseMessage, object dataSet)
        {
            ResponseCode = responseCode;
            ResponseMessage = responseMessage;
            Token = dataSet;
        }
        public ResponseCode ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public object Token { get; set; }
    }
}
