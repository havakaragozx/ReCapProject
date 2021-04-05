using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            carManager.GetAll().ForEach(p => Console.WriteLine(p.DailyPrice));

            Console.WriteLine(carManager.GetById(1).DailyPrice);

            Car newCar = new Car
            { Id = 6, BrandId = 1, ColorId = 2, ModelYear = 2019, DailyPrice = 500, Description = "f" };

            carManager.Add(newCar);
            Console.WriteLine(carManager.GetById(6).DailyPrice);

            newCar.DailyPrice = 300;
            carManager.Update(newCar);
            Console.WriteLine(carManager.GetById(6).DailyPrice);

            carManager.Delete(newCar);

        }
    }
}
