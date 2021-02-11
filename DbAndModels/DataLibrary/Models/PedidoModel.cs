using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
    public class PedidoModel
    {
        public int Id { get; set; }
        public string NombreCliente { get; set; }
        public string EmailCliente { get; set; }
        public string DireccionCliente { get; set; }
        public int MenuId { get; set; }
        public DateTime FechaPedido { get; set; } = DateTime.UtcNow;
        public int CantidadTotal { get; set; }
        public decimal PrecioTotal { get; set; }
    }
}
