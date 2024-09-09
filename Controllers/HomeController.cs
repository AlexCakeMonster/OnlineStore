using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineStore.Data;
using OnlineStore.Models;
using OnlineStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            HomeVm homeVM = new HomeVm()
            {
                Products = _db.Product.Include(u => u.Category).Include(u => u.ApplicationType),
                Categories = _db.Category
            };
            return View(homeVM);
        }

        public IActionResult Details(int Id)
        {
            DetailsVm detailsVm = new DetailsVm()
            {
                Product = _db.Product.Include(u => u.Category).Include(u => u.ApplicationType)
                .Where(u => u.Id == Id).FirstOrDefault(),
                ExistsInCart = false
            };

            return View(detailsVm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
