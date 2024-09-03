﻿global using AutoMapper;
global using AutoMapper.QueryableExtensions;
global using FluentValidation;
global using MediatR;
global using MediatR.Extensions.FluentValidation.AspNetCore;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Localization;
global using Microsoft.IdentityModel.Tokens;
global using SchoolApp.Application.Common;
global using SchoolApp.Application.Common.Models;
global using SchoolApp.Application.Common.Resoruces;
global using SchoolApp.Application.Common.ResponseBases;
global using SchoolApp.Application.Common.Validations;
global using SchoolApp.Application.Features.AuthorizationFeatrue.Commands.UpdateRoleById;
global using SchoolApp.Application.Features.AuthorizationFeatrue.Queries;
global using SchoolApp.Application.Features.StudentFeatrue.Commands.AddStudent;
global using SchoolApp.Application.Features.UserFeatrue.Queries;
global using SchoolApp.Application.Services.RoleService;
global using SchoolApp.Application.Services.StudentService;
global using SchoolApp.Domain.Entities;
global using SchoolApp.Domain.Entities.Identity;
global using SchoolApp.Domain.Helpers;
global using SchoolApp.Domain.RepositoriesInterfaces;
global using System.ComponentModel.DataAnnotations;
global using System.IdentityModel.Tokens.Jwt;
global using System.Linq.Expressions;
global using System.Net;
global using System.Reflection;
global using System.Security.Claims;
global using System.Text;
