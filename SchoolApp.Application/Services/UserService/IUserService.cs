using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Application.Services.UserService;

public interface IUserService
{
    Task<bool> IsUserExistsById(int Id);
    Task<bool> IsUserExistsByEmail(string Email);
    Task<bool> IsUserExistsByUserName(string UserName);
    Task<bool> IsUserExists(int Id, string UserName, string Email);
    Task<bool> IsUserExists(string UserName, string Email);
    IQueryable<User> GetAllUsers();
    IQueryable<User> GetUserById(int Id);
    IQueryable<User> GetUserByEmail(string Email);
    IQueryable<User> GetUserByUserName(string UserName);
    IQueryable<User> GetUser(int Id, string UserName, string Email);
    Task<IdentityResult> AddNewUserAsync(User NewUser, string password);
    Task<IdentityResult> UpdateUserAsync(User UpdatedUser);
    Task<IdentityResult> ChangeUserPasswordAsync(User User, string CurrentPassword, string NewPassword);
    Task<bool> CheckPasswordAsync(User User, string Password);
}
