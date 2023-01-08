namespace ProductAPI.Models;

public class CustomerBill
{
    public Guid Id { get; set;}
    public DateTime billDate { get; set;}
    public double sumPrice { get; set;}
    public string nameCustomer { get; set;}
    public string numberCustomer { get; set;}
    public string lstProductId { get; set; }
    
}