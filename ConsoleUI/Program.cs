using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            //GetAllTest();
            //GetByIdTest();
            //HatalıEklemeTest();
            //CarAddedTest();
            //BrandAddedTest();
            //ColorAddedTest();

            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Araç Adı: " + car.CarName + " ------- " + "Markası: " + car.BrandName + " ------- " + "Rengi : " + car.ColorName + " ------- " + " Günlük Fiyatı: " + car.DailyPrice + " TL \n");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            RentalAdd(rentalManager);

            Console.ReadLine();
        }

        private static void RentalAdd(RentalManager rentalManager)
        {
            var rental = rentalManager.Add(new Rental { RentalId = 3, CarId = 1, CustomerId = 2, ReturnDate = new DateTime(2021, 02, 12), 
                RentDate = DateTime.Today });
            Console.WriteLine(rental.Message);

        }

        //private static void ColorAddedTest()
        //{
        //    ColorManager colorManager = new ColorManager(new EfColorDal());
        //    colorManager.Add(new Color { ColorId = 5, ColorName = "Gece Mavisi" });
        //}

        //private static void BrandAddedTest()
        //{
        //    BrandManager brandManager = new BrandManager(new EfBrandDal());
        //    brandManager.Add(new Brand { BrandId = 5, BrandName = "Ferrari" });
        //}

        //private static void CarAddedTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    carManager.Add(new Car { Id = 6, CarName = "Q7", BrandId = 4, ColorId = 4, ModelYear = 2007, DailyPrice = 300, Description = "Otomatik" });
        //}

        //private static void HatalıEklemeTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    BrandManager brandManager = new BrandManager(new EfBrandDal());
        //    carManager.Add(new Car { BrandId = 3, ColorId = 2, DailyPrice = 0, ModelYear = 2005, Description = "Otomatik" });
        //    brandManager.Add(new Brand { BrandName = "T" });
        //}

        //private static void GetByIdTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    Console.WriteLine(carManager.GetById(1).CarName);
        //    Console.WriteLine("\n");
        //}

        //private static void GetAllTest()
        //{
        //    Console.WriteLine("TÜM ARABALAR:");
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    foreach (var car in carManager.GetAll())
        //    {
        //        Console.WriteLine("ID: " + car.Id + " Araç Adı: " + car.CarName + " Marka Numarası: " + car.BrandId +
        //            " Renk Numarası: " + car.ColorId + " Günlük Fiyatı: " + car.DailyPrice + " Açıklaması: " + car.Description);

        //    }
        //    Console.WriteLine("\n");
        //}
    }
    
}
