using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VP_Lifestyle.Data;
using VP_LifeStyle_V2.Data.DataAccess;

namespace VP_LifeStyle_V2.Data
{
    //Is an abstract class, at which other classes will inherit from.
    //RespositoryBase is generic and inherits from IRespository which is generic too
    public abstract class RespositoryBase<T>  : IRespositoryBase<T> where T : class 
    {
        //Create a private/protected variable of type LifeStyleDb and a constructor

        protected readonly LifestyleDbContext _lifestyleDbContext;

        //Constructor created
        public RespositoryBase(LifestyleDbContext lifestyleDbContext)
        {
            _lifestyleDbContext = lifestyleDbContext;
        }

        public void Create(T entity)
        {
            //Use the set method, to indicate the set at which the product will bw
            //Added too.
            _lifestyleDbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
           _lifestyleDbContext.Set<T>().Remove(entity);
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _lifestyleDbContext.Set<T>().Where(expression); 
        }

        public IEnumerable<T> FindWithOptions(QueryOptions<T> options)
        {
            //Add(Important) [Fix]
            IQueryable<T> query = _lifestyleDbContext.Set<T>();//is set to equal all the data in the Dbset.

            if (options.HasWhere)
                query = query.Where(options.Where);

            if (options.HasOrderBy)
            {
                if (options.OrderByDirection == "asc")
                    query = query.OrderBy(options.OrderBy);
                else
                    query = query.OrderByDescending(options.OrderBy);
            }
            //Important
            if (options.HasPaging)
            {
                query = query.Skip((options.PageNumber - 1) * options.PageSize)
                              .Take(options.PageSize);
            }
            return query.ToList();//Always return to list when working with IEnumerable;
        }

        public IEnumerable<T> GetAll()
        {
            //important
            return _lifestyleDbContext.Set<T>();
        }

        public T GetById(int id)
        {
           return _lifestyleDbContext.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
           _lifestyleDbContext.Set<T>().Update(entity);
        }
    }
}
