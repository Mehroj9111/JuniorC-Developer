using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Infrastructure.Services;
using Domain.Dtos;
using Domain.Wrapper;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class ProductController{
    public readonly ProductService _productService;
    public ProductController(ProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("GetAll")]
    public async Task<Response<List<GetProduct>>> GetProducts( Month month){
        return await _productService.GetProducts(month);
    }
    [HttpPost("Add")]
    public async Task<Response<AddProduct>> AddProduct([FromForm]AddProduct product){
        return await _productService.AddProduct(product);
    }
    [HttpPut("Update")]
    public async Task<Response<AddProduct>> Update(AddProduct product){
        return await _productService.Update(product);
    }
    [HttpDelete("Dalate")]
    public async Task<Product> Delete(int id){
        return await _productService.Delete(id);
    }
}