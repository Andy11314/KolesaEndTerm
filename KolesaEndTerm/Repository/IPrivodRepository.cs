using System.Collections.Generic;
using KolesaEndTerm.Models;

namespace KolesaEndTerm.Repository
{
    public interface IPrivodRepository
    {
        Privod GetPrivod(int id);
        IEnumerable<Privod> GetAllPrivods();
        Privod Add(Privod privod);
        Privod Update(Privod privod);
        Privod Delete(int id);
    }
}