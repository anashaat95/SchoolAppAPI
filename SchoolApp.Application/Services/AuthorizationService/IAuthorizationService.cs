namespace SchoolApp.Application.Services.RoleService;

public interface IAuthorizationService
{
    IQueryable<Role> GetRoleById(int Id);
    IQueryable<Role> GetRoleByName(string RoleName);
    IQueryable<Role> GetRolesList();
    Task<IdentityResult> AddRoleAsync(Role NewRole);
    Task<IdentityResult> UpdateRoleAsync(Role Role);
    Task<IdentityResult> DeleteRoleAsync(Role Role);
    Task<bool> IsRoleExistsAsync(string Name);
    Task<bool> IsRoleExistsAsyncExceptSelf(string Name);
    Task<bool> IsRoleExistsAsync(int Id);
}
