namespace VP_LifeStyle_V2.Models.ProductMenuViewModel
{
    public class CustomerListView
    {
     public IEnumerable<Customer> Customer { get; set; }
     //add paging info
     public PageInfoViewModel PageInfo { get; set; }    
    }
}
