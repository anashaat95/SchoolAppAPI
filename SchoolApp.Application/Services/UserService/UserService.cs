namespace SchoolApp.Application.Services.UserService;

public class UserService : IUserService
{
    #region Fields
    private readonly UserManager<User> _userManager;
    #endregion


    #region Constructors
    public UserService(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    #endregion

    #region Methods
    public async Task<bool> IsUserExistsByIdAsync(int Id)
    {
        return await _userManager.Users.AnyAsync(x => x.Id == Id);
    }

    public async Task<bool> IsUserExistsByEmailAsync(string Email)
    {
        return await _userManager.Users.AnyAsync(x => x.Email == Email);
    }

    public async Task<bool> IsUserExistsByUserNameAsync(string UserName)
    {
        return await _userManager.Users.AnyAsync(x => x.UserName == UserName);
    }

    public async Task<bool> IsUserExistsAsync(string UserName, string Email)
    {
        return await _userManager.Users.AnyAsync(x => x.Email == Email || x.UserName == UserName);
    }

    public async Task<bool> IsUserExistsAsync(int Id, string UserName, string Email)
    {
        return await _userManager.Users.AnyAsync(x => x.Id == Id || x.Email == Email || x.UserName == UserName);
    }

    public IQueryable<User> GetAllUsers()
    {
        return _userManager.Users.Include(u => u.UserRoles);
    }
    public IQueryable<User> GetUserById(int Id)
    {
        return _userManager.Users.Where(x => x.Id == Id).Include(u => u.UserRoles);
    }
    public IQueryable<User> GetUserByEmail(string Email)
    {
        return _userManager.Users.Where(x => x.Email!.ToLower().Equals(Email.ToLower()));
    }

    public IQueryable<User> GetUserByUserName(string UserName)
    {
        return _userManager.Users.Where(x => x.UserName!.ToLower().Equals(UserName.ToLower()));
    }

    public IQueryable<User> GetUser(int Id, string UserName, string Email)
    {
        return _userManager.Users.Where(x => x.Id == Id || x.Email!.ToLower().Equals(Email.ToLower()) || x.UserName!.ToLower().Equals(UserName.ToLower()));
    }

    public async Task<IdentityResult> AddNewUserAsync(User NewUser, string password)
    {
        return await _userManager.CreateAsync(NewUser, password);
    }

    public async Task<IdentityResult> ChangeUserPasswordAsync(User User, string CrurentPassword, string NewPassword)
    {
        return await _userManager.ChangePasswordAsync(User, CrurentPassword, NewPassword);
    }

    public async Task<IdentityResult> UpdateUserAsync(User UpdatedUser)
    {
        return await _userManager.UpdateAsync(UpdatedUser);
    }

    public async Task<bool> CheckPasswordAsync(User User, string Password)
    {
        return await _userManager.CheckPasswordAsync(User, Password);
    }

    public async Task<List<string>> GetUserRolesAsync(User User)
    {
        return (await _userManager.GetRolesAsync(User)).ToList();
    }

    public async Task<IdentityResult> RemoveFromRolesAsync(User User, IEnumerable<string> Roles)
    {
        return await _userManager.RemoveFromRolesAsync(User, Roles);
    }

    public async Task<IdentityResult> AddToRoleAsync(User User, Role Role)
    {
        User.UserRoles!.Add(new UserRole { Role = Role });
        return await _userManager.UpdateAsync(User); 
    }

    public async Task<IdentityResult> UpdateUserRolesAsync(User User, List<string> Roles)
    {
        return await _userManager.UpdateAsync(User);
    }

    public Task<IdentityResult> UpdateUserRolesAsync(User User, List<Role> NewRole)
    {
        throw new NotImplementedException();
    }

    //public async Task<IdentityResult> UpdateUserRolesAsync(User User, List<Role> NewRole)
    //{
    //    return await 
    //}

    #endregion
}
