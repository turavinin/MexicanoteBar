using DataLibrary.Models;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public interface IPedidoData
    {
        Task<int> CreatePedido(PedidoModel pedido);
        Task<int> DeletePedido(int pedidoId);
        Task<PedidoModel> GetPedidoByEmail(string emailCliente);
        Task<PedidoModel> GetPedidoById(int pedidoId);
        Task<int> UpdateEmailCliente(int pedidoId, string emailCliente);
        Task<int> UpdateNombreCliente(int pedidoId, string nombreCliente);
    }
}