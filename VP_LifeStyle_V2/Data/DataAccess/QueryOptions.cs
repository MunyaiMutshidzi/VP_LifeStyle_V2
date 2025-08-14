
using System.Diagnostics.Contracts;
using System.Linq.Expressions;
namespace VP_LifeStyle_V2.Data.DataAccess
{
    public class QueryOptions<T>
    {
       //Public properties for sorting and filtering
       public Expression<Func<T,Object>> OrderBy { get; set; } //sorting
       public string OrderByDirection { get; set; } = "asc";//Default sorting direction
       public Expression<Func<T,bool>> Where { get; set; }//Filtering
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
       //Paging

        //Read-only properties
        public bool HasWhere => Where != null;//Filtering condition
        public bool HasOrderBy => OrderBy != null;
        //Paging conditioning
        public bool HasPaging => PageNumber> 0 || PageSize > 0;
        
      



    }
}
