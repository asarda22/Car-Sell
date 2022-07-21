using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarSell.AppDbContext;
using CarSell.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarSell.Controllers
{
    [Authorize(Roles = "Admin,Executive")]
    public class ModelController : Controller
    {
        private readonly CarDbContext _db;

        [BindProperty]
        public ModelViewModel modelViewModel { get; set; }

        public ModelController(CarDbContext db)
        {
            _db = db;
            modelViewModel = new ModelViewModel()
            {
                Brands = _db.Brands.ToList(),
                Model = new Models.Model()
            };
        }

        public IActionResult Index()
        {
            //fetch dependent column based on foreign key
            var model = _db.Models.Include(m => m.Brand);
            return View(model);
        }

        public IActionResult Create()
        {
            return View(modelViewModel);
        }

        [HttpPost,ActionName("Create")]
        public IActionResult CreatePost()
        {
            if(!ModelState.IsValid)
            {
                return View(modelViewModel);
            }
            _db.Models.Add(modelViewModel.Model);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            modelViewModel.Model = _db.Models.Include(m => m.Brand).SingleOrDefault(m => m.Id == id);
            if(modelViewModel.Model == null)
            {
                return NotFound();
            }
            return View(modelViewModel);
        }

        [HttpPost,ActionName("Edit")]
        public IActionResult EditPost()
        {
            if (!ModelState.IsValid)
            {
                return View(modelViewModel);
            }
            _db.Update(modelViewModel.Model);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Model model = _db.Models.Find(id);
            if(model == null)
            {
                return NotFound();
            }
            _db.Models.Remove(model);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        [AllowAnonymous]
        [HttpGet("api/models/{brandId}")]
        public IEnumerable<Model> GetModels(int brandId)
        {
            return _db.Models.ToList().Where(m=>m.BrandFK==brandId);
        }
    }
}