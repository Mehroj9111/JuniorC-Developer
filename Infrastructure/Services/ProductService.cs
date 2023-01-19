using Domain.Entities;
using Domain.Dtos;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Domain.Wrapper;

namespace Infrastructure.Services;

public class ProductService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ProductService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }
    
    public async Task<Response<List<GetProduct>>> GetProducts( Month month )
    {
        var products = await _context.Products.ToListAsync();
        var list = new List<GetProduct>();
     
        foreach (var t in products)
        {
            var todo = new GetProduct()
            {
                ProductId = t.ProductId,
                ProductType = t.ProductType,
                ProductName = t.ProductName,
                Month = month,
                ProductPrice = t.ProductPrice,
                GeneralCredit =  GetDept( t.ProductType, t.ProductPrice, month ),
                ProductPerMonth = GetCustomerCredits( t.ProductType, t.ProductPrice, month )

            };
            list.Add(todo);
        }
       return new Response<List<GetProduct>>(list);
    }

    public async Task<Response<AddProduct>> AddProduct(AddProduct product)
    {
                var newTodo = new Product()
                {
                    ProductType = product.ProductType,
                    ProductName = product.ProductName,
                    ProductPrice = product.ProductPrice,
                    CustomerId = product.CustomerId
                
                };  
            _context.Products.Add(newTodo);
             await _context.SaveChangesAsync();
             product.ProductId = newTodo.ProductId;
            return new Response<AddProduct>(product);
            
    }
    public async Task<Response<AddProduct>> Update(AddProduct todo)
    {
        
        var find = await _context.Products.FindAsync(todo.ProductId);
        find.ProductType = todo.ProductType;
        find.ProductName =  todo.ProductName;
        find.ProductPrice = todo.ProductPrice;
        find.CustomerId = todo.CustomerId;
        await _context.SaveChangesAsync();
        return new Response<AddProduct>(todo);
    }
    
    public async Task<Product> Delete(int id)
    {
        var delete = await _context.Products.FindAsync(id);
        _context.Products.Remove(delete);
        await _context.SaveChangesAsync();
        return delete;
    }
    public decimal GetCustomerCredits(  ProductType tech, decimal price, Month month )
    {
        if ( Month.month9 >= month && ProductType.Phone == tech ){
            return price / ((decimal)month);
        }
        if ( Month.month12 <= month && Month.month18 >= month && ProductType.Phone == tech ){
            return (price + (price * 3 / 100)) / ((decimal)month);
        }
        if ( Month.month24 >= month && ProductType.Phone == tech ){
            return (price + (price * 6 / 100)) / ((decimal)month);
        }
        //------
        if ( Month.month12 >= month && ProductType.Computer == tech ){
            return price / ((decimal)month);
        }
        if ( Month.month18 >= month && ProductType.Computer == tech ){
            return (price + (price * 4 / 100)) / ((decimal)month);
        }
        if ( Month.month24 >= month && ProductType.Computer == tech ){
            return (price + (price * 8 / 100)) / ((decimal)month);
        }
        //-------
         if ( Month.month18 >= month && ProductType.TV == tech ){
            return price / ((decimal)month);
        }
        if ( Month.month24 >= month && ProductType.TV == tech ){
            return (price + (price * 5 / 100)) / ((decimal)month);
        }
        return price;
    }
    public decimal GetDept(  ProductType tech, decimal price, Month month )
    {
        if ( Month.month9 >= month && ProductType.Phone == tech ){
            return price ;
        }
        if ( Month.month12 <= month && Month.month18 >= month && ProductType.Phone == tech ){
            return (price + (price * 3 / 100));
        }
        if ( Month.month24 >= month && ProductType.Phone == tech ){
            return (price + (price * 6 / 100)) ;
        }
        //------
        if ( Month.month12 >= month && ProductType.Computer == tech ){
            return price;
        }
        if ( Month.month18 >= month && ProductType.Computer == tech ){
            return (price + (price * 4 / 100)) ;
        }
        if ( Month.month24 >= month && ProductType.Computer == tech ){
            return (price + (price * 8 / 100));
        }
        //-------
         if ( Month.month18 >= month && ProductType.TV == tech ){
            return price  ;
        }
        if ( Month.month24 >= month && ProductType.TV == tech ){
            return (price + (price * 5 / 100));
        }
        return price;
    }
}
