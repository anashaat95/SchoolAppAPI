namespace SchoolApp.Application.Services.RoleService;

public interface IAuthorizationService
{
    Task<Role?> GetRoleByIdAsync(int Id);
    Task<IdentityResult> AddRoleAsync(Role NewRole);
    Task<IdentityResult> UpdateRoleAsync(Role Role);
    Task<bool> IsRoleExistsAsync(string Name);
    Task<bool> IsRoleExistsAsyncExceptSelf(string Name);
    Task<bool> IsRoleExistsAsync(int Id);
}
