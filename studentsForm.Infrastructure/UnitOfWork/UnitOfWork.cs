using studentsForm.Application.Interfaces.Repository;
using studentsForm.Application.Interfaces.UnitOfWork;
using studentsForm.Infrastructure.Repositories;

namespace studentsForm.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private Dictionary<Type, object> _repositories;
        public UnitOfWork(ApplicationDbContext context)
        {
            this._context = context;
            _repositories = new Dictionary<Type, object>();
        }


        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            if (_repositories.ContainsKey(typeof(T)))
            {
                return _repositories[typeof(T)] as IGenericRepository<T>;
            }

            var repository = new GenericRepository<T>(_context);
            _repositories.Add(typeof(T), repository);
            return repository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
