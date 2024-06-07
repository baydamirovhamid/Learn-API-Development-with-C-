﻿using DotnetAPI.Data;
using DotnetAPI.Dtos;
using DotnetAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
namespace DotnetAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    DataContextDapper _dapper;
    public UserController(IConfiguration config)
    {
        _dapper = new DataContextDapper(config);
    }

    [HttpGet("TestConnection")]
    public DateTime TestConnection()
    {
        return _dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");
    }




    [HttpGet("GetUsers/")]
    //public IActionResult Test()
    public IEnumerable<UserDto> GetUsers()
    {
        string sql = @"
            SELECT [UserId],
            [FirstName],
            [LastName],
            [Email],
            [Gender],
            [Active] 
            FROM TutorialAppSchema.Users
        ";
        IEnumerable<UserDto> users =_dapper.LoadData<UserDto>(sql);
        return users;
    }

    [HttpGet("GetSingleUsers/{userId}")]
    public UserDto GetSingleUser(int userId)
    {
        string sql = @"
            SELECT [UserId],
            [FirstName],
            [LastName],
            [Email],
            [Gender],
            [Active] 
            FROM TutorialAppSchema.Users
            WHERE UserId = " + userId.ToString();
          UserDto user = _dapper.LoadDataSingle<UserDto>(sql);
          return user;

    }

    [HttpPut("EditUser")]
    public IActionResult EditUser(User user)
    {
        string sql = @"
        UPDATE TutorialAppSchema.Users
        SET [FirstName] = '" + user.FirstName +
        "', [LastName]  = '" + user.LastName +
        "', [Email]  = '" + user.Email +
        "', [Gender]  = '" + user.Gender +
        "', [Active]  = '" + user.Active +

      "' WHERE UserId = " + user.UserId;
        Console.WriteLine(sql);

        if (_dapper.ExecuteSql(sql))
        {
            return Ok();
        }
        throw new Exception("Failed to Update User");
    }


    [HttpPost("AddUser")]
    public IActionResult AddUser(UserDto user)
    {
        string sql = @"
    INSERT INTO TutorialAppSchema.Users(
    [FirstName],
    [LastName],
    [Email],
    [Gender],
    [Active]
    ) VALUES (" +
        "'" + user.FirstName +
        "', '" + user.LastName +
        "', '" + user.Email +
        "', '" + user.Gender +
        "', '" + user.Active +
             "')";
        Console.WriteLine(sql);

        if (_dapper.ExecuteSql(sql))
        {
            return Ok();
        }
        throw new Exception("Failed to Add User");
    }
}

