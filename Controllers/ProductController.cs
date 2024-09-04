using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineStore.Data;
using OnlineStore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineStore.Models.ViewModels;

namespace OnlineStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> objList = _db.Product;

            foreach(var obj in objList)
            {
                obj.Category = _db.Category.FirstOrDefault(u => u.Id == obj.CategoryId);
            }

            return View(objList);
        }

        //GET - UPSERT
        public IActionResult Upsert(int? id)
        {            

            ProductVm productVm = new ProductVm
            {
                Product = new Product(),
                CategorySelectList = _db.Category.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };
        
            if (id == null)
            {
                //this is for create
                return View(productVm);
            }
            else
            {
                productVm.Product = _db.Product.Find(id);
                if(productVm.Product == null)
                {
                    return NotFound();
                }
            }
            return View(productVm);
        }

        //POST - UPSERT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Product obj)
        {
            if (ModelState.IsValid)
            {
                _db.Product.Add(obj);
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
