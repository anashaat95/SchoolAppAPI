namespace SchoolApp.Infrastructrue.Data.Repositories.Bases;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    #region Vars / Props
    protected readonly AppDbContext _context;
    protected readonly DbSet<T> _set;
    #endregion

    #region Constructor(s)
    public GenericRepository(AppDbContext context)
    {
        _context = context;
        _set = context.Set<T>();
    }
    #endregion



    #region Actions
    public virtual IQueryable<T> GetById(int id)
    {
        return _set.Where(x => EF.Property<int>(x, "Id") == id);
    }

    public virtual IQueryable<T> GetTableNoTracking()
    {
        return _set.AsNoTracking().AsQueryable();
    }

    public virtual IQueryable<T> GetTableAsTracking()
    {
        return _set.AsQueryable().AsQueryable();
    }

    public virtual async Task<int> AddAsync(T entity)
    {
        await _set.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity.Id;
    }

    public virtual async Task<bool> UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
        return true;
    }


    public virtual async Task<bool> DeleteAsync(T entity)
    {
        _set.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public virtual async Task<bool> AddRangeAsync(ICollection<T> entities)
    {
        await _set.AddRangeAsync(entities);
        await _context.SaveChangesAsync();
        return true;
    }

    public virtual async Task<bool> UpdateRangeAsync(ICollection<T> entities)
    {
        _set.UpdateRange(entities);
        await _context.SaveChangesAsync();
        return true;
    }

    public virtual async Task<bool> DeleteRangeAsync(ICollection<T> entities)
    {
        foreach (var entity in entities)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        await _context.SaveChangesAsync();
        return true;
    }

    public virtual async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public virtual IDbContextTransaction BeginTransaction()
    {
        return _context.Database.BeginTransaction();
    }

    public virtual void Commit()
    {
        _context.Database.CommitTransaction();
    }

    public virtual void RollBack()
    {
        _context.Database.RollbackTransaction();
    }

    public async Task<bool> IsExistsByIdAsync(int id)
    {
        return await _set.AnyAsync(s => s.Id == id);
    }
    #endregion
}

