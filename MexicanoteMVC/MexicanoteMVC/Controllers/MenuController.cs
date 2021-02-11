using DataLibrary.Data;
using DataLibrary.Models;
using MexicanoteMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MexicanoteMVC.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuData _menuData;
        private readonly IPedidoData _pedidoData;

        public MenuController(IMenuData menuData, IPedidoData pedidoData)
        {
            _menuData = menuData;
            _pedidoData = pedidoData;
        }

        

        public IActionResult Index()
        {
            return View();
        }


        // CREATE Primera parte (GET)
        public async Task<IActionResult> Create()
        {
            var menu = await _menuData.GetMenu();

            CrearPedidoModel model = new CrearPedidoModel();

            menu.ForEach(x =>
            {
                model.ItemsMenu.Add(new SelectListItem { Value = x.Id.ToString(), Text = x.NombrePlato });
            });

            return View(model);
        }

        // CREATE Segunda Parte (POST)
        [HttpPost]
        public async Task<IActionResult> Create(PedidoModel pedido)
        {
            // Check if submition is not valid
            if (ModelState.IsValid == false)
            {
                return View();
            }

            var menu = await _menuData.GetMenu();

            pedido.PrecioTotal = pedido.CantidadTotal * menu.Where(x => x.Id == pedido.MenuId).First().PrecioPlato;

            int id = await _pedidoData.CreatePedido(pedido);

            return RedirectToAction("Display", new { id });
        }

        // Action "Display por ID"
        public async Task<IActionResult> Display(int id)
        {
            PedidoDisplayModel displayPedido = new PedidoDisplayModel();

            displayPedido.Pedido = await _pedidoData.GetPedidoById(id);

            if (displayPedido.Pedido != null)
            {
                var menu = await _menuData.GetMenu();

                displayPedido.ItemComprado = menu.Where(x => x.Id == displayPedido.Pedido.MenuId).FirstOrDefault()?.NombrePlato;
            }

            return View(displayPedido);
        }



        // UPDATE NOMBRE
        [HttpPost]
        public async Task<IActionResult> UpdateNombre(int id, string nombreCliente)
        {
            await _pedidoData.UpdateNombreCliente(id, nombreCliente);

            return RedirectToAction("Display", new { id });
        }

        // UPDATE EMAIL
        [HttpPost]
        public async Task<IActionResult> UpdateEmail(int id, string emailCliente)
        {
            await _pedidoData.UpdateEmailCliente(id, emailCliente);

            return RedirectToAction("Display", new { id });
        }


        // DELETE
        public async Task<IActionResult> Delete(int id)
        {
            var pedido = await _pedidoData.GetPedidoById(id);

            return View(pedido);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(PedidoModel pedido)
        {
            await _pedidoData.DeletePedido(pedido.Id);

            return RedirectToAction("Index", "Home");
        }
    }
}
