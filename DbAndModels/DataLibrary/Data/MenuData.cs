using DataLibrary.Db;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public class MenuData : IMenuData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public MenuData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;

        }

        public Task<List<MenuModel>> GetMenu()
        {
            return _dataAccess.LoadData<MenuModel, dynamic>("spMenu_GetAll",
                                                            new { },
                                                            _connectionString.SqlConnectionName);
        }
    }
}
