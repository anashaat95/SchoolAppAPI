using SchoolApp.Domain.Entities.Identity;

namespace SchoolApp.Domain.RepositoriesInterfaces;

public interface IRefreshTokenRepository : IGenericRepository<UserRefreshToken>
{
}
