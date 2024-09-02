using SchoolApp.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Domain.RepositoriesInterfaces;

public interface IRefreshTokenRepository : IGenericRepository<UserRefreshToken>
{
}
