namespace SchoolApp.Application.Services.RoleService;

public interface IAuthorizationService
{
    IQueryable GetRoleById(int Id);
    IQueryable GetRolesList();
    Task<IdentityResult> AddRoleAsync(Role NewRole);
    Task<IdentityResult> UpdateRoleAsync(Role Role);
    Task<IdentityResult> DeleteRoleAsync(Role Role);
    Task<bool> IsRoleExistsAsync(string Name);
    Task<bool> IsRoleExistsAsyncExceptSelf(string Name);
    Task<bool> IsRoleExistsAsync(int Id);
}
