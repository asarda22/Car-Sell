using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarSell.AppDbContext;
using CarSell.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarSell.Controllers
{
    public class BrandController : Controller
    {
        private readonly CarDbContext _dbContext;

        public BrandController(CarDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View(_dbContext.Brands.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Brand brand)
        {
            if(ModelState.IsValid)
            {
                _dbContext.Add(brand);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(brand);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var brand = _dbContext.Brands.Find(id);
            if(brand == null)
            {
                return NotFound();
            }
            _dbContext.Brands.Remove(brand);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var brand = _dbContext.Brands.Find(id);
            if (brand == null)
            {
                return NotFound();
            }
            return View(brand);
        }

        [HttpPost]
        public IActionResult Edit(Brand brand)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Update(brand);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(brand);
        }
    }
}