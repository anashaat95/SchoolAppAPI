﻿using Microsoft.VisualBasic;

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

    public async Task<IdentityResult> DeleteRoleAsync(Role Role)
    {
        return await _roleManager.DeleteAsync(Role);
    }

    public async Task<int> GetUsersInRoleAsync(string roleName)
    {
        var count = await _roleManager.Roles.Include(r => r.Users).Where(r => r.Name == roleName).CountAsync();
        if (count > 0) return count;
        else return 0;
    }
    #endregion
}
