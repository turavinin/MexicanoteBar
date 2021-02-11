using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MexicanoteMVC.Models
{
    public class CrearPedidoModel
    {
        public PedidoModel Pedido { get; set; } = new PedidoModel();
        public List<SelectListItem> ItemsMenu { get; set; } = new List<SelectListItem>();
    }
}
