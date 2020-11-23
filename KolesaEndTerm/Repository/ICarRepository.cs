using System.Collections.Generic;
using KolesaEndTerm.Models;

namespace KolesaEndTerm.Repository
{
    public interface ICarRepository
    {
        Car GetCar(int id);
        IEnumerable<Car> GetAllCars();
        Car Add(Car car);
        Car Update(Car car);
        Car Delete(int id);
    }
}