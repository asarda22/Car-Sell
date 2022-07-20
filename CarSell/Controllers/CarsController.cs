using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarSell.AppDbContext;
using CarSell.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.AspNetCore.Hosting.Internal;

namespace CarSell.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarDbContext _db;
        private readonly HostingEnvironment _hostingEnvironment;

        [BindProperty]
        public CarViewModel carsViewModel { get; set; }

        public CarsController(CarDbContext db, HostingEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
            carsViewModel = new CarViewModel()
            {
                Brands = _db.Brands.ToList(),
                Models = _db.Models.ToList(),
                Car = new Models.Car()
            };
        }

        public IActionResult Index()
        {
            //fetch dependent column based on foreign key
            var cars = _db.Cars.Include(m => m.Brand).Include(m=>m.Model);
            return View(cars.ToList());
        }

        public IActionResult Create()
        {
            return View(carsViewModel);
        }

        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost()
        {
            if (!ModelState.IsValid)
            {
                carsViewModel.Brands = _db.Brands.ToList();
                carsViewModel.Models = _db.Models.ToList();
                return View(carsViewModel);
            }
            _db.Cars.Add(carsViewModel.Car);
            _db.SaveChanges();

            //Get BikeID we have saved in database            
            var carID = carsViewModel.Car.Id;

            //Get wwrootPath to save the file on server
            string rootPath = _hostingEnvironment.WebRootPath;

            //Get the Uploaded files
            var files = HttpContext.Request.Form.Files;

            //Get the reference of DBSet for the bike we have saved in our database
            var savedBike = _db.Cars.Find(carID);


            //Upload the file on server and save the path in database if user have submitted file
            if (files.Count != 0)
            {

                var imagePath = @"Images\Cars\";
                //Extract the extension of submitted file
                var Extension = Path.GetExtension(files[0].FileName);

                //Create the relative image path to be saved in database table 
                var RelativeImagePath = imagePath + carID + Extension;

                //Create absolute image path to upload the physical file on server
                var AbsImagePath = Path.Combine(rootPath, RelativeImagePath);


                //Upload the file on server using Absolute Path
                using (var filestream = new FileStream(AbsImagePath, FileMode.Create))
                {
                    files[0].CopyTo(filestream);
                }

                //Set the path in database
                savedBike.ImagePath = RelativeImagePath;

                _db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        /*
        public IActionResult Edit(int id)
        {
            modelViewModel.Model = _db.Models.Include(m => m.Brand).SingleOrDefault(m => m.Id == id);
            if (modelViewModel.Model == null)
            {
                return NotFound();
            }
            return View(modelViewModel);
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult EditPost()
        {
            if (!ModelState.IsValid)
            {
                return View(modelViewModel);
            }
            _db.Update(modelViewModel.Model);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }*/

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Car car = _db.Cars.Find(id);
            if (car == null)
            {
                return NotFound();
            }
            _db.Cars.Remove(car);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}