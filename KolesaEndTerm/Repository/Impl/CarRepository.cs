using System.Collections.Generic;
using KolesaEndTerm.Data;
using KolesaEndTerm.Models;

namespace KolesaEndTerm.Repository.Impl
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _context;

        public CarRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public Car GetCar(int id)
        {
            return _context.Cars.Find(id);
        }

        public IEnumerable<Car> GetAllCars()
        {
            return _context.Cars;
        }

        public Car Add(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
            return car;
        }

        public Car Update(Car car)
        {
            var c = _context.Cars.Attach(car);
            c.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return car;
        }

        public Car Delete(int id)
        {
            var car = _context.Cars.Find(id);
            if (car == null) return null;
            _context.Cars.Remove(car);
            _context.SaveChanges();

            return car;
        }
    }
}