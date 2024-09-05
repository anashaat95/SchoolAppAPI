namespace SchoolApp.Application.Services.UserService;

public interface IUserService
{
    Task<bool> IsUserExistsByIdAsync(int Id);
    Task<bool> IsUserExistsByEmailAsync(string Email);
    Task<bool> IsUserExistsByUserNameAsync(string UserName);
    Task<bool> IsUserExistsAsync(int Id, string UserName, string Email);
    Task<bool> IsUserExistsAsync(string UserName, string Email);
    IQueryable<User> GetAllUsers();
    IQueryable<User> GetUserById(int Id);
    IQueryable<User> GetUserByEmail(string Email);
    IQueryable<User> GetUserByUserName(string UserName);
    IQueryable<User> GetUser(int Id, string UserName, string Email);
    Task<List<string>> GetUserRolesAsync(User User);
    Task<IdentityResult> AddNewUserAsync(User NewUser, string password);
    Task<IdentityResult> UpdateUserAsync(User UpdatedUser);
    Task<IdentityResult> ChangeUserPasswordAsync(User User, string CrurentPassword, string NewPassword);
    Task<bool> CheckPasswordAsync(User User, string Password);
    Task<IdentityResult> RemoveFromRolesAsync(User User, IEnumerable<string> Roles);
    Task<IdentityResult> AddToRoleAsync(User User, Role Role);
    Task<IdentityResult> UpdateUserRolesAsync(User User, List<Role> NewRole);
}
