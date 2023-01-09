namespace ProductAPI.Models;

public class Customer
{
    public int CustomerId { get; set; }
    public string Name { get; set;}
    public DateTime birthay { get; set; }
    public string address { get; set;}
    public string number { get; set;}
    public string email { get; set;}
    public string CreatedBy { get; set; }
    public DateTime CreateDate { get; set; }
    public string UpdatedBy { get; set; }
    public DateTime UpdatedDate { get; set; }
}