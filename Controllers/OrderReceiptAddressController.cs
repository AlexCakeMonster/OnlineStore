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
            if (ModelState.IsValid)
            {
                _db.orderReceiptAddress.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET - EDIT

        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            var obj = _db.orderReceiptAddress.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(OrderReceiptAddress obj)
        {
            if (ModelState.IsValid)
            {
                _db.orderReceiptAddress.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET - Delete

        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            var obj = _db.orderReceiptAddress.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST - Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? Id)
        {
            var obj = _db.orderReceiptAddress.Find(Id);
             if(obj == null)
            {
                return NotFound();
            }
            else
            {
                _db.orderReceiptAddress.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

        }
    }
}
