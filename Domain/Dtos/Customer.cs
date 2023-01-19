namespace Domain.Dtos;
using Domain.Entities;
public class AddCustomer
{
    public int CustomerId { get; set; }
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
}
public class GetCustomer
{
    public int CustomerId { get; set; }
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public List<GetProduct> Products { get; set; }
}