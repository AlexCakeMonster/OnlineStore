using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineStore.Data;
using OnlineStore.Models;

namespace OnlineStore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> abjList = _db.Category;
            return View(abjList);
        }

        //GET - CREATE
        public IActionResult Create()
        {            
            return View();
        }

        //GET - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);           
        }

        //GET - EDIT
        public IActionResult Edit(int? Id)
        {
            if(Id==null || Id == 0)
            {
                return NotFound();
            }

            var obj = _db.Category.Find(Id);
            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET - EDIT
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            var obj = _db.Category.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? Id)
        {
            var obj = _db.Category.Find(Id);

            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                _db.Category.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            
        }
    }
}
