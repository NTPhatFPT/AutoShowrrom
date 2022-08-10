using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Models1;

namespace DataAccess.DAO
{
    public class CarDAO
    {
        public void DeleteCar(int id)
        {
            using (var db = new MyStockContext())
            {
                var car = db.Cars.Find(id);
                db.Cars.Remove(car);
                db.SaveChanges();
            }
        }

        public Car GetCarByID(int id)
        {
            var car = new Car();
            using (var db = new MyStockContext())
            {
                car = db.Cars.Find(id);
            }
            return car;
        }

         public IEnumerable<Car> GetAllCar()
         {
            var cars = new List<Car>();
            using(var db = new MyStockContext())
            {
                cars = db.Cars.ToList();
            }
            return cars;
         }

        public void UpdateCar(Car car)
        {
            Car car1 = GetCarByID(car.CarId);
            if(car1!=null)
            {
                using(var db = new MyStockContext())
                {
                    db.Cars.Update(car);
                    db.SaveChanges();
                }
            }
            else
            {
                throw new Exception("ID is already exist!");
            }
        }

        public void AddCar(Car car)
        {
            Car car1=GetCarByID(car.CarId);
            if(car1==null)
            {
                using(var db = new MyStockContext())
                {
                    db.Cars.Add(car);
                    db.SaveChanges();
                }
            }
            else
            {
                throw new Exception("ID is already exist!");
            }
        }
    }
}
