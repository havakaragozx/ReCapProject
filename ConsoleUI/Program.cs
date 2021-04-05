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

            Car newCar = new Car
            { Name = "iX", BrandId = 1, ColorId = 2, ModelYear = 2020, DailyPrice = 500, Description = "Yeni teslim alındı." };

            carManager.Add(newCar);
            carManager.GetAll().ForEach(p => Console.WriteLine(p.Name));
            carManager.GetCarDetails().ForEach(p => Console.WriteLine("{0} {1} {2} {3}", p.CarName, p.BrandName, p.ColorName, p.DailyPrice));

        }
    }
}
