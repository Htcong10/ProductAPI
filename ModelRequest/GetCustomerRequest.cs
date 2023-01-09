namespace ProductAPI.ModelRequest
{
    public class GetCustomerRequest
    {
        public string? Name { get; set; }
        public string? number { get; set; }
        public string? email { get; set; }
    }
    public class GetBillByCustomerRequest : GetCustomerRequest
    {
        public DateTime? fromDate { get; set; }
        public DateTime? toDate { get; set; }
    }

}
