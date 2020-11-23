using System.Collections.Generic;
using KolesaEndTerm.Data;
using KolesaEndTerm.Models;

namespace KolesaEndTerm.Repository.Impl
{
    public class PrivodRepository : IPrivodRepository
    {
        private readonly ApplicationDbContext _context;

        public PrivodRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public Privod GetPrivod(int id)
        {
            return _context.Privods.Find(id);
        }

        public IEnumerable<Privod> GetAllPrivods()
        {
            return _context.Privods;
        }

        public Privod Add(Privod privod)
        {
            _context.Privods.Add(privod);
            _context.SaveChanges();
            return privod;
        }

        public Privod Update(Privod privod)
        {
            var c = _context.Privods.Attach(privod);
            c.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return privod;
        }

        public Privod Delete(int id)
        {
            var privod = _context.Privods.Find(id);
            if (privod == null) return null;
            _context.Privods.Remove(privod);
            _context.SaveChanges();

            return privod;
        }
    }
}