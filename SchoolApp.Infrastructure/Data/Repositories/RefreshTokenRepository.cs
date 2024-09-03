using SchoolApp.Domain.Entities.Identity;

namespace SchoolApp.Infrastructrue.Data.Repositories;

public class RefreshTokenRepository : GenericRepository<UserRefreshToken>, IRefreshTokenRepository
{
    #region Field(s)
    private readonly DbSet<UserRefreshToken> _set;
    #endregion

    #region Constructor(s)
    public RefreshTokenRepository(AppDbContext context) : base(context)
    {
        _set = context.Set<UserRefreshToken>();
    }
    #endregion

    #region Methods

    #endregion
}
