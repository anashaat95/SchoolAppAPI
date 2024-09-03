namespace SchoolApp.Application.Services.RoleService;

public interface IAuthorizationService
{
    Task<IdentityResult> AddRoleAsync(Role NewRole);
    Task<IdentityResult> UpdateRoleAsync(Role Role);
    Task<bool> IsRoleExistsAsync(string Name);
}
