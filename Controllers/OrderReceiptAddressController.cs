using Microsoft.AspNetCore.Mvc;
using OnlineStore.Data;
using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Controllers
{
    public class OrderReceiptAddressController : Controller
    {
        private readonly ApplicationDbContext _db;
        public OrderReceiptAddressController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<OrderReceiptAddress> objList = _db.orderReceiptAddress;
            return View(objList);
        }

        // GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        // POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OrderReceiptAddress obj)
        {
            _db.orderReceiptAddress.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
