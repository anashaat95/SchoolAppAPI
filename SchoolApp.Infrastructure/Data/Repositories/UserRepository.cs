using SchoolApp.Domain.Entities.Identities;

namespace SchoolApp.Infrastructure.Data.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    #region Fields
    private new readonly DbSet<User> _set;
    #endregion

    #region Constructors
    public UserRepository(AppDbContext context) : base(context)
    {
        _set = context.Set<User>();
    }
    #endregion

    #region Actions
   
    #endregion
}
