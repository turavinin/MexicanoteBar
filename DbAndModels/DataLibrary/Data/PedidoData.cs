using Dapper;
using DataLibrary.Db;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public class PedidoData : IPedidoData
    {
        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public PedidoData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }


        // CREATE
        public async Task<int> CreatePedido(PedidoModel pedido)
        {
            DynamicParameters p = new DynamicParameters();

            p.Add("NombreCliente", pedido.NombreCliente);
            p.Add("EmailCliente", pedido.EmailCliente);
            p.Add("DireccionCliente", pedido.DireccionCliente);
            p.Add("MenuId", pedido.MenuId);
            p.Add("FechaPedido", pedido.FechaPedido);
            p.Add("CantidadTotal", pedido.CantidadTotal);
            p.Add("PrecioTotal", pedido.PrecioTotal);
            p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

            await _dataAccess.SaveData("dbo.spPedido_Insert", p, _connectionString.SqlConnectionName);

            return p.Get<int>("Id");
        }

        // GET BY ID
        public async Task<PedidoModel> GetPedidoById(int pedidoId)
        {
            var recs = await _dataAccess.LoadData<PedidoModel, dynamic>("dbo.spPedido_GetById",
                                                                        new { Id = pedidoId },
                                                                        _connectionString.SqlConnectionName);

            return recs.FirstOrDefault();
        }

        // GET BY EMAIL
        public async Task<PedidoModel> GetPedidoByEmail(string emailCliente)
        {
            var recs = await _dataAccess.LoadData<PedidoModel, dynamic>("dbo.spPedido_GetByEmail",
                                                                         new { EmailCliente = emailCliente },
                                                                         _connectionString.SqlConnectionName);

            return recs.FirstOrDefault();
        }


        // UPDATE
        // Nombre
        public Task<int> UpdateNombreCliente(int pedidoId, string nombreCliente)
        {
            return _dataAccess.SaveData("dbo.spPedido_UpdateNombre",
                                        new { Id = pedidoId, NombreCliente = nombreCliente },
                                        _connectionString.SqlConnectionName);
        }

        //Email
        public Task<int> UpdateEmailCliente(int pedidoId, string emailCliente)
        {
            return _dataAccess.SaveData("dbo.spPedido_UpdateEmail",
                                        new { Id = pedidoId, EmailCliente = emailCliente },
                                        _connectionString.SqlConnectionName);
        }


        // DELETE
        public Task<int> DeletePedido(int pedidoId)
        {
            return _dataAccess.SaveData("dbo.spPedido_Delete",
                                        new { Id = pedidoId },
                                        _connectionString.SqlConnectionName);
        }




    }
}
