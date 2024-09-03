namespace SchoolApp.Application.Features.UserFeatrue.Commands.UpdateUserById;

public class UpdateUserByIdDTO
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Password { get; set; }
    public required string ConfirmPassword { get; set; }
    public string? Address { get; set; }
    public string? Country { get; set; }

}
