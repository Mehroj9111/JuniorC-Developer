namespace Domain.Entities;
public class Product
{
    public int ProductId { get; set; }
    public ProductType ProductType { get; set; }
    public string ProductName { get; set; }
     public decimal ProductPerMonth { get; set; }
    public decimal ProductPrice { get; set; }
    public decimal GeneralCredit { get; set; }
    public int CustomerId { get; set; }
     public Customer Customers { get; set; }
    public List<Installment> Installments { get; set; }
}
public enum ProductType
{
    Phone = 1,
    Computer,
    TV
}