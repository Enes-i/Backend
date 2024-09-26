namespace WebApplication2.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Point> Points { get; }
        int Complete();
    }
}