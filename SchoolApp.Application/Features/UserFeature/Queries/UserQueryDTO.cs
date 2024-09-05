﻿using SchoolApp.Application.Features.UserFeatrue.Commands.AddUser;
using SchoolApp.Domain.Entities.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Application.Features.UserFeatrue.Queries;

public class UserQueryDTO
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public string? Country { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<User, UserQueryDTO>();
            CreateMap<User, User>();
        }
    }
}
