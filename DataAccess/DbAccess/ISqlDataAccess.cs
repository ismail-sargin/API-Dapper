
namespace DataAccess.DbAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string storedProducere, U parameters, string connectionId = "Default");
        Task SaveData<T>(string storedProducere, T parameters, string connectionId = "Default");
    }
}
