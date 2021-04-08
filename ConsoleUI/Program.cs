using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            //carTest();
            //userTest();
            //customerUser();
            //rentalTest();
        }
        private static void rentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //Rental rental = new Rental
            //{
            //    //Id = 3,
            //    CarId = 2,
            //    CustomerId = 2,
            //    RentDate = DateTime.Now,
            //    ReturnDate = null
            //};
            //IResult result = rentalManager.Add(rental);
            //if (!result.Success) Console.WriteLine(result.Message);
            //rentalManager.Update(rental);
            //rentalManager.Delete(rental);
            //rentalManager.GetAll().Data.ForEach(r => Console.WriteLine(r.CarId + " " + r.RentDate));
        }
        private static void customerUser()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            //Customer customer = new Customer
            //{
            //    Id = 1,
            //    UserId =1,
            //    CompanyName = "HavaKaragoz",
            //};
            //customerManager.Add(customer);
            //customerManager.Update(customer);
            //customerManager.Delete(customer);
            customerManager.GetAll().Data.ForEach(c => Console.WriteLine(c.Id + " " + c.UserId + " " + c.CompanyName));
        }
        private static void userTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            //User user = new User
            //{
            //    FirstName = "Hava",
            //    LastName = "Karagöz",
            //    Email = "havakaragoz@outlook.com",
            //    Password = "testpassword"
            //};
            //userManager.Add(user);
            //userManager.Update(user);
            //userManager.Delete(user);
            userManager.GetAll().Data.ForEach(u => Console.WriteLine(u.FirstName));
        }
        private static void carTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            //Car car = new Car
            //{
            //    Name = "iX",
            //    BrandId = 1,
            //    ColorId = 2,
            //    ModelYear = 2020,
            //    DailyPrice = 500,
            //    Description = "Yeni teslim alındı."
            //};
            //carManager.Add(car);
            //carManager.Update(car);
            //carManager.Delete(car);
            carManager.GetAll().Data.ForEach(p => Console.WriteLine(p.Name));
            carManager.GetCarDetails().Data.ForEach(p => Console.WriteLine("{0} {1} {2} {3}", p.CarName, p.BrandName, p.ColorName, p.DailyPrice));
            carManager.GetCarDetails().Data.ForEach(p =>
                Console.WriteLine("{0} {1} {2} {3}", p.CarName, p.BrandName, p.ColorName, p.DailyPrice));
        }
    }
}
