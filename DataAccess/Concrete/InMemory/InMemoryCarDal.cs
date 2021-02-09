using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car {Id=1,BrandId=1,ColorId=1,ModelYear=2015,DailyPrice=250,Description="BMW-Manuel-Dizel"},
                new Car {Id=2,BrandId=1,ColorId=2,ModelYear=1996,DailyPrice=100,Description="Tofaşk-Manuel-Benzinli"},
                new Car {Id=3,BrandId=2,ColorId=3,ModelYear=2020,DailyPrice=280,Description="Mercedes-Otomatik-Tüplü"},
                new Car {Id=4,BrandId=2,ColorId=3,ModelYear=2011,DailyPrice=170,Description="Toyota-Otomatik-Benzinli"},
                new Car {Id=5,BrandId=2,ColorId=2,ModelYear=2007,DailyPrice=140,Description="Audi-Manuel-Dizel"}
            };
        }


        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=>c.Id==car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c => c.Id == Id).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
