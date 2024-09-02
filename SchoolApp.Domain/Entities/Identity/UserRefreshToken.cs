﻿namespace SchoolApp.Domain.Entities.Identity;

public class UserRefreshToken : BaseEntity
{
    public int Id { get; set; }
    public int? UserId { get; set; }
    public User? User { get; set; }
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
    public string? JwtId { get; set; }
    public bool IsUsed { get; set; }
    public bool IsRevoked { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? ExpiryDate { get; set; }
}
