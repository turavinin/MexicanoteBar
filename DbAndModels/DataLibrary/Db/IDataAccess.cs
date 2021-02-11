using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLibrary.Db
{
    public interface IDataAccess
    {
        Task<List<T>> LoadData<T, U>(string storedProcedures, U parameters, string connectionStringName);
        Task<int> SaveData<U>(string storedProcedures, U parameters, string connectionStringName);
    }
}