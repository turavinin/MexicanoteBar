using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Db
{
    public class SqlDb : IDataAccess
    {
        private readonly IConfiguration _config;

        public SqlDb(IConfiguration config)
        {
            _config = config;
        }


        // LOAD DATA
        public async Task<List<T>> LoadData<T, U>(string storedProcedures, U parameters, string connectionStringName)
        {
            // Get connection string
            string connectionString = _config.GetConnectionString(connectionStringName);

            // Connection with DB
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var rows = await connection.QueryAsync<T>(storedProcedures,
                                                          parameters,
                                                          commandType: CommandType.StoredProcedure);

                return rows.ToList();
            }
        }


        // SAVE DATA
        public async Task<int> SaveData<U>(string storedProcedures, U parameters, string connectionStringName)
        {
            // Get connection string
            string connectionString = _config.GetConnectionString(connectionStringName);

            // Connection with DB
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                return await connection.ExecuteAsync(storedProcedures,
                                                     parameters,
                                                     commandType: CommandType.StoredProcedure);
            }
        }
    }
}
