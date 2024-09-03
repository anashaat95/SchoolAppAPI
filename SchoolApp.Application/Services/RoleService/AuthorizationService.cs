using Microsoft.VisualBasic;

namespace SchoolApp.Application.Services.RoleService;

public class AuthorizationService : IAuthorizationService
{
    #region Fields
    #endregion
    private readonly RoleManager<Role> _roleManager;

    #region Constructor(s)
    public AuthorizationService(RoleManager<Role> roleManager)
    {
        _roleManager = roleManager;
    }
    #endregion

    #region Method(s)
    public async Task<Role?> GetRoleByIdAsync(int Id)
    {
        return await _roleManager.FindByIdAsync(Id.ToString());
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
    #endregion
}
