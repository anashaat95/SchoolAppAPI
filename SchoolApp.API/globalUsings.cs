﻿global using Microsoft.AspNetCore.Mvc;
global using SchoolApp.API.Bases;
global using SchoolApp.Application.Features.StudentFeature.Queries.GetStudentPaginatedList;
global using SchoolApp.Domain.AppMetaData;
global using SchoolApp.Application.Features.StudentFeature.Commands.AddStudent;
global using SchoolApp.Application.Features.StudentFeature.Commands.DeleteStudentCommand;
global using SchoolApp.Application.Features.StudentFeature.Commands.UpdateStudentById;
global using SchoolApp.Application.Features.StudentFeature.Queries.GetStudentById;
global using SchoolApp.Application.Features.StudentFeature.Queries.StudentListQuery;
global using FluentValidation;
global using Microsoft.EntityFrameworkCore;
global using SchoolApp.Application.Common.ResponseBases;
global using System.Net;
global using System.Text.Json;