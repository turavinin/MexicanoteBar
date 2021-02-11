using DataLibrary.Data;
using DataLibrary.Models;
using MexicanoteMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MexicanoteMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMenuData _menuData;
        private readonly IPedidoData _pedidoData;

        public HomeController(ILogger<HomeController> logger, IMenuData menuData, IPedidoData pedidoData)
        {
            _logger = logger;
            _menuData = menuData;
            _pedidoData = pedidoData;
        }

        public async Task<IActionResult> Index()
        {
            var menu = await _menuData.GetMenu();

            return View(menu);
        }



        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(string emailCliente)
        {
            var pedido = await _pedidoData.GetPedidoByEmail(emailCliente);

            if (pedido != null)
            {
                return RedirectToAction("Display", "Menu", new { pedido.Id });
            }
            else
            {
                return RedirectToAction("Display", "Menu");
            }
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
