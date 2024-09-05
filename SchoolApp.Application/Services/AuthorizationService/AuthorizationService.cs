using Microsoft.VisualBasic;
using SchoolApp.Domain.Entities.Identities;

namespace SchoolApp.Application.Services.RoleService;

public class AuthorizationService : IAuthorizationService
{
    #region Fields
    #endregion
    private readonly RoleManager<Role> _roleManager;
    private readonly UserManager<User> _userManager;

    #region Constructor(s)
    public AuthorizationService(RoleManager<Role> roleManager, UserManager<User> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }
    #endregion

    #region Method(s)
    public IQueryable<Role> GetRoleById(int Id)
    {
        return _roleManager.Roles.Where(r => r.Id == Id);
    }

    public IQueryable<Role> GetRoleByName(string RoleName)
    {
        return _roleManager.Roles.Where(r => r.Name == RoleName);
    }

    public IQueryable<Role> GetRolesList()
    {
        return _roleManager.Roles;
    }
    public async Task<IdentityResult> AddRoleAsync(Role NewRole)
    {
        return await _roleManager.CreateAsync(NewRole);
    }

    public async Task<IdentityResult> UpdateRoleAsync(Role Role)
    {
        return await _roleManager.UpdateAsync(Role);
    }

    public async Task<bool> IsRoleExistsAsync(string Name)
    {
        return await _roleManager.RoleExistsAsync(Name);
    }
    public async Task<bool> IsRoleExistsAsyncExceptSelf(string Name)
    {
        return await _roleManager.RoleExistsAsync(Name);
    }

    public async Task<bool> IsRoleExistsAsync(int Id)
    {
        return await _roleManager.FindByIdAsync(Id.ToString()) != null;
    }

    public async Task<IdentityResult> DeleteRoleAsync(Role Role)
    {
        return await _roleManager.DeleteAsync(Role);
    }

    #endregion
}
