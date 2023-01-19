namespace Domain.Filters;

public class CustomerFilter: PaginationFilter
{

    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }


    public CustomerFilter():base()
    {
        
    }
    public CustomerFilter(int pageNumber, int pageSize) :base(pageNumber,pageSize)
    {
        
    }
    
    
}

