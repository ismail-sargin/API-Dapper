﻿using DataAccess.Models;
using System;
using System.Linq;

namespace DataAccess.Data
{
	public interface IUserData
	{
        Task<IEnumerable<UserModel>> GetUsers();
        Task<UserModel?> GetUser(int id);
		Task InsertUser(UserModel user);
		Task UpdateUser(UserModel user);
        Task DeleteUser(int id);
    }
}
