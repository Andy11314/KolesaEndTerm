using System.Collections.Generic;
using KolesaEndTerm.Data;
using KolesaEndTerm.Models;

namespace KolesaEndTerm.Repository.Impl
{
    public class CountryRepository : ICountryRepository
    {

        private readonly ApplicationDbContext _context;

        public CountryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    
        public Country GetCountry(int id)
        {
            return _context.Countries.Find(id);
        }

        public IEnumerable<Country> GetAllCountries()
        {
            return _context.Countries;
        }

        public Country Add(Country country)
        {
            _context.Countries.Add(country);
            _context.SaveChanges();
            return country;
        }

        public Country Update(Country country)
        {
            var c = _context.Countries.Attach(country);
            c.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return country;
        }

        public Country Delete(int id)
        {
            var country = _context.Countries.Find(id);
            if (country == null) return null;
            _context.Countries.Remove(country);
            _context.SaveChanges();

            return country;
        }
    }
}