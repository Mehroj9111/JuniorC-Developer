using AutoMapper;
using Domain.Dtos;
using Domain.Entities;

namespace Infrastructure.Mapper;

public class ServiceProfile:Profile
{
    public ServiceProfile()
    {
        CreateMap<Customer, AddCustomer>().ReverseMap();
        CreateMap<Customer, GetCustomer>().ReverseMap();
        CreateMap<GetCustomer, AddCustomer>().ReverseMap();

        // CreateMap<Order, AddOrder>().ReverseMap();
        // CreateMap<Order, GetOrder>().ReverseMap();
        // CreateMap<GetOrder, AddOrder>().ReverseMap();

        CreateMap<Installment, AddInstallment>().ReverseMap();
        CreateMap<Installment, GetInstallment>().ReverseMap();
        CreateMap<GetInstallment, AddInstallment>().ReverseMap();

        CreateMap<Product, AddProduct>().ReverseMap();
        CreateMap<Product, GetProduct>().ReverseMap();
        CreateMap<GetProduct, AddProduct>().ReverseMap();
    }
}
