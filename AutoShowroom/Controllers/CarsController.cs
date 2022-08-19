using Microsoft.AspNetCore.Mvc;
using DataAccess.Models;
using System.Collections.Generic;
using System.Linq;
using DataAccess.DAO;
using DataAccess.Models1;

namespace AutoShowroom.Controllers
{
    public class CarsController : Controller
    {
        CarDAO carDAO = null;
        public CarsController() => carDAO = new CarDAO();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CarList()
        {
            //List<Car> cars;
            //using(var db=new MyStockContext())
            //{
            //    cars = db.Cars.ToList();
            //}
            var carlist = carDAO.GetAllCar();
            return View(carlist);
        }

        public IActionResult Details(int? id)
        {
            //Car car;
            //using(var db = new MyStockContext())
            //{
            //    car = db.Cars.Where(c => c.CarId==id).FirstOrDefault();
            //}
            //return View(car);
            var car=carDAO.GetCarByID(id.Value);
            return View(car);
        }
        public IActionResult CarDetails(int? id)
        {
            //Car car;
            //using(var db = new MyStockContext())
            //{
            //    car = db.Cars.Where(c => c.CarId==id).FirstOrDefault();
            //}
            //return View(car);
            var car = carDAO.GetCarByID(id.Value);
            return View(car);
        }

        public IActionResult Edit(int id)
        {
            Car edit;
            using(var db = new MyStockContext())
            {
                edit = db.Cars.Where(c => c.CarId==id).FirstOrDefault();
            }
            return View(edit);
        }

        [HttpPost]
        public IActionResult Edit(Car car)
        {
            carDAO.UpdateCar(car);
            return View("Edit");
        }

        public IActionResult CarsManagement()
        {
            //List<Car> list;
            //using(var db = new MyStockContext())
            //{
            //    list = db.Cars.ToList();
            //}
            var cars=carDAO.GetAllCar();
            return View(cars);
        }

        public IActionResult Delete(int id)
        {
            carDAO.DeleteCar(id);
            return View("CarsManagement");
        }

        public IActionResult Create() => View();
        [HttpPost]
        public IActionResult Create(Car car)
        {
            carDAO.AddCar(car);
            return View("Create");
        }

        public IActionResult Search(string name)
        {
            var cars = new List<Car>();
            cars= (List<Car>)carDAO.Search(name);
            if(cars.Count==0)
            {
                var carlist = carDAO.GetAllCar();
                return View("CarList",carlist);
            }
            else
            {
                return View("CarList", cars);
            }
        }
    }
}
