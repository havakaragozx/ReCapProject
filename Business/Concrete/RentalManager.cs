using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id));
        }


        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IResult Add(Rental customer)
        {
            var result = CheckReturnDate(customer.CarId);
            if (!result.Success) return new ErrorResult(result.Message);

            _rentalDal.Add(customer);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Update(Rental customer)
        {
            _rentalDal.Update(customer);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IResult Delete(Rental customer)
        {
            _rentalDal.Delete(customer);
            return new SuccessResult(Messages.RentalDeleted);
        }
        public IDataResult<Rental> CheckReturnDate(int carId)
        {
            var result = _rentalDal.GetAll(x => x.CarId == carId && x.ReturnDate == null);
            if (result.Count > 0) return new ErrorDataResult<Rental>(Messages.RentalUndeliveredCar);
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.CarId == carId));
        }
    }
}
