using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Filters;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class CustomerServices
{
    public readonly DataContext _context;
    public readonly IMapper _mapper;

    public CustomerServices(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
// GetAllCustomerWithListProducts_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _

    public async Task<Response<List<GetCustomer>>> GetAllCustomer()
    {
        var list = _mapper.Map<List<GetCustomer>>(await _context.Customers.ToListAsync());
        foreach (var item in list)
        {
            item.Products = _mapper.Map<List<GetProduct>>(_context.Products.Where(x=>x.CustomerId == item.CustomerId)).ToList();
        }
        return new Response<List<GetCustomer>>(list);
    } 
// GetCustomerWhithFilter_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ 
    public async Task<PaginationResponse<List<GetCustomer>>> GetGustomerWithFilter (CustomerFilter filter)
   {
        var query = _context.Customers.AsQueryable();
        if(filter.Name != null) query = query.Where(x=>x.FullName.ToLower().Contains(filter.Name.ToLower()));
        if(filter.PhoneNumber != null) query = query.Where(x=>x.PhoneNumber.ToLower().Contains(filter.PhoneNumber.ToLower()));
        var list = query.Skip((filter.PageNumber - 1) * filter.PageSize).Take(filter.PageSize).ToList();
        var res = _mapper.Map<List<GetCustomer>>(list);
        var totalRecords = await _context.Products.CountAsync();
        return new PaginationResponse<List<GetCustomer>>( res, totalRecords, filter.PageNumber, filter.PageSize); 
   }
   // AddCustomer_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
    public async Task<Response<AddCustomer>> AddCustomer(AddCustomer customer)
    {
            try 
            {
                var newCustomer = new Customer()
                {
                   FullName = customer.FullName,
                   PhoneNumber = customer.PhoneNumber,
                   Address = customer.Address
                
                };  
            _context.Customers.Add(newCustomer);
             await _context.SaveChangesAsync();
             customer.CustomerId = newCustomer.CustomerId;
            return new Response<AddCustomer>(customer);
           }
            catch (System.Exception ex)
            {
                
                return new Response<AddCustomer>(System.Net.HttpStatusCode.InternalServerError,ex.Message);
            }
    }
   // UpdateCustomer_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _

    public async Task<Response<GetCustomer>> UpdateCustomer(AddCustomer customer)
    {
        var find = await _context.Customers.FindAsync(customer.CustomerId);
        find.FullName = customer.FullName;
        find.PhoneNumber = customer.PhoneNumber;
        find.Address = customer.Address;
        await _context.SaveChangesAsync();
        return new Response<GetCustomer>(_mapper.Map<GetCustomer>(find));  
    }
   // DeletedCustomer_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
    public async Task<Customer> Delete(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
        return customer;
    }

}
