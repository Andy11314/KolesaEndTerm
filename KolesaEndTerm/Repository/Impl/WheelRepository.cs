using System.Collections.Generic;
using KolesaEndTerm.Data;
using KolesaEndTerm.Models;

namespace KolesaEndTerm.Repository.Impl
{
    public class WheelRepository : IWheelRepository
    {
        private readonly ApplicationDbContext _context;

        public WheelRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public Wheel GetWheel(int id)
        {
            return _context.Wheels.Find(id);
        }

        public IEnumerable<Wheel> GetAllWheels()
        {
            return _context.Wheels;
        }

        public Wheel Add(Wheel wheel)
        {
            _context.Wheels.Add(wheel);
            _context.SaveChanges();
            return wheel;
        }

        public Wheel Update(Wheel wheel)
        {
            var c = _context.Wheels.Attach(wheel);
            c.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return wheel;
        }

        public Wheel Delete(int id)
        {
            var wheel = _context.Wheels.Find(id);
            if (wheel == null) return null;
            _context.Wheels.Remove(wheel);
            _context.SaveChanges();

            return wheel;
        }
        
    }
}