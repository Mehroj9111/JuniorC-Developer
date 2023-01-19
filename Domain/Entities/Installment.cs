namespace Domain.Entities;
public class Installment
{
    public int InstallmentId { get; set; }
    public Month Month { get; set; }
    public double PricePerMonth { get; set; }
    public string PhoneNumber { get; set; }
    public int ProductId { get; set; }
    public Product Products { get; set; }
}

// Credit Month 3 6 9 12 18 24
public enum Month
{
     month3 = 3,
    month6 = 6,
    month9 = 9,
    month12 = 12,
    month18 = 18,
    month24 = 24 
}