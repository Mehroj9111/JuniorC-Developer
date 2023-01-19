namespace  Domain.Dtos;
using Domain.Entities;

public class AddProduct
{
    public int ProductId { get; set; }
    public ProductType ProductType { get; set; }
    public string ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public int CustomerId { get; set; }
}
public class GetProduct
{
    public int ProductId { get; set; }
    public ProductType ProductType { get; set; }
    public string ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public decimal GeneralCredit { get; set; }
     public decimal ProductPerMonth { get; set; }
    public string FullName { get; set; }
    public Month Month {get; set;}

}