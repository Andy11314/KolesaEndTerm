using System.Collections.Generic;
using KolesaEndTerm.Data;
using KolesaEndTerm.Models;

namespace KolesaEndTerm.Repository
{
    public interface ICountryRepository
    {
        Country GetCountry(int id);
        IEnumerable<Country> GetAllCountries();
        Country Add(Country country);
        Country Update(Country country);
        Country Delete(int id);
    }
}