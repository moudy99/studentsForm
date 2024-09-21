using studentsForm.Application.Interfaces.Repository;

namespace studentsForm.Application.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> GetRepository<T>() where T : class;

        Task<int> SaveChangesAsync();
    }
}
