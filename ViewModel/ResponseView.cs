namespace ProductAPI.ViewModel
{
    public class ResponsePostView
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public bool Success { get; set; }

        public ResponsePostView(string Message, int StatusCode, bool success )
        {
            this.Message = Message;
            this.StatusCode = StatusCode;
            Success = success;
        }

        public ResponsePostView() { }
    }
    public class ResponseViewModel
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public object Data { get; set; }
        public bool Success { get; set; }

        public ResponseViewModel(string message, int statusCode, object data, bool success)
        {
            Message = message;
            StatusCode = statusCode;
            Data = data;
            Success = success;
        }
    }

    public class ResponsePaging
    {
        public string Message { get; set; }
        public object Data { get; set; }
        public bool Success { get; set; }
        public int TotalRecord { get; set; }

        public ResponsePaging(string message, object data, bool success, int totalRecord)
        {
            Message = message;
            Data = data;
            Success = success;
            TotalRecord = totalRecord;
        }
    }
}
