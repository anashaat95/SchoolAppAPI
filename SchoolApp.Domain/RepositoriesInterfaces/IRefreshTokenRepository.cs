﻿using SchoolApp.Domain.Entities.Identities;

namespace SchoolApp.Domain.RepositoriesInterfaces;

public interface IRefreshTokenRepository : IGenericRepository<UserRefreshToken>
{
}
