using WebApplication2.Models;
using WebApplication2.Repositories;

namespace WebApplication2.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PointDbContext _context;
        public IGenericRepository<Point> Points { get; }

        public UnitOfWork(PointDbContext context)
        {
            _context = context;
            Points = new GenericRepository<Point>(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
