namespace SchoolApp.Domain.RepositoriesInterfaces.Bases;

public interface IGenericRepository<T> where T : class, IEntity
{
    IQueryable<T> GetById(int id);
    IQueryable<T> GetTableNoTracking();
    IQueryable<T> GetTableAsTracking();
    Task<bool> IsExistsByIdAsync(int id);
    Task<int> AddAsync(T entity);
    Task<bool> UpdateAsync(T entity);
    Task<bool> DeleteAsync(T entity);
    Task<bool> AddRangeAsync(ICollection<T> entities);
    Task<bool> UpdateRangeAsync(ICollection<T> entities);
    Task<bool> DeleteRangeAsync(ICollection<T> entities);
    Task SaveChangesAsync();
    IDbContextTransaction BeginTransaction();
    void Commit();
    void RollBack();
}
