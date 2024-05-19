using DataAccess.DbAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace DataAccess.Data;
public class UserData : IUserData
{
	private readonly ISqlDataAccess _db;

	public UserData(ISqlDataAccess db)
	{
		_db = db;
	}

	public Task<IEnumerable<UserModel>> GetUsers() =>
		_db.LoadData<UserModel, dynamic>(storedProducere: "dbo.spUser_GetAll", new { });
	public async Task<UserModel?> GetUser(int id)
	{
		var results = await _db.LoadData<UserModel, dynamic>(
			storedProducere: "dbo.spUser_Get",
			new { id });
		return results.FirstOrDefault();
	}
	public Task InsertUser(UserModel user) =>
		_db.SaveData(storedProducere: "dbo.spUser_Insert", new { user.FirstName, user.LastName });
	public Task UpdateUser(UserModel user) =>
		_db.SaveData(storedProducere: "dbo.spUser_Update", user);
	public Task DeleteUser(int id) =>
		_db.SaveData(storedProducere: "dbo.spUser_Delete", new { Id = id });

}
