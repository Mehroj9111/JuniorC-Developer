namespace  Domain.Dtos;
using Domain.Entities;
public class AddInstallment
{
    public int InstallmentId { get; set; }
    public Month Month { get; set; }
    public double PricePerMonth { get; set; }
    public int ProductId { get; set; }
}
public class GetInstallment
{
    public int InstallmentId { get; set; }
    public Month Month { get; set; }
    public double PricePerMonth { get; set; }
    public int ProductId { get; set; }
}