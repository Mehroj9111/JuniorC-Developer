using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Infrastructure.Services;
using Domain.Filters;
using Domain.Wrapper;
using Domain.Dtos;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]

public class CustomerController
{
    public readonly CustomerServices _customerServices;
    public CustomerController(CustomerServices customerServices)
    {
        _customerServices = customerServices;
    }

    [HttpGet("GetAllCategoryWithListProducts")]
    public async Task<Response<List<GetCustomer>>> GetAllCustomer()
    {
        return await _customerServices.GetAllCustomer();
    }

      [HttpGet("GetCustomerWithFilter")]
    public async Task<PaginationResponse<List<GetCustomer>>> GetGustomerWithFilter([FromQuery] CustomerFilter filter)
    {
        return await _customerServices.GetGustomerWithFilter(filter);
    }

    [HttpPost("AddCustomer")]
    public async Task<Response<AddCustomer>> AddCustomer([FromForm]AddCustomer product){
        return await _customerServices.AddCustomer(product);
    }

    [HttpPut("UpdateCustomer")]
    public async Task<Response<GetCustomer>> UpdateCustomer([FromForm]AddCustomer product){
        return await _customerServices.UpdateCustomer(product);
    }

    [HttpDelete("Dalate")]
    public async Task<Customer> Delete(int Id){
        return await _customerServices.Delete(Id);
    }
}