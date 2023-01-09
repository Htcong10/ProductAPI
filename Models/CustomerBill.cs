namespace ProductAPI.Models;

public class CustomerBill
{
    public Guid Id { get; set;}
    public DateTime billDate { get; set;}
    public double sumPrice { get; set;}
    public string lstProductId { get; set; }
    public int customerId { get; set; }
    public int typePay { get; set; }
    
}