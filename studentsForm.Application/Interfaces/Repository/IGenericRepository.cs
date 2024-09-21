using System.Linq.Expressions;

namespace studentsForm.Application.Interfaces.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);

        T Find(Expression<Func<T, bool>> criteria, string[] includes = null);
        IEnumerable<T> FindAll(string[] includes = null, Expression<Func<T, bool>> criteria = null);

        Task AddAsync(T entity);

        Task DeleteAsync(int id);
    }
}
