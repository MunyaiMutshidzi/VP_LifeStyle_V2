using System.Linq.Expressions;
using VP_LifeStyle_V2.Data.DataAccess;

namespace VP_LifeStyle_V2.Data
{
    //Contains list of methods to be implemented
    //It should be generic too
    public interface IRespositoryBase<T>
    {
      //Check methods

        T GetById(int id);
        IEnumerable<T> GetAll();

        //General methods/functionality
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);

        //Check out (Important)
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
        //Check out (Important)
        IEnumerable<T> FindWithOptions(QueryOptions<T> options);
    }
}
