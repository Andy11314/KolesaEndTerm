using System.Collections.Generic;
using KolesaEndTerm.Models;

namespace KolesaEndTerm.Repository
{
    public interface ICategoryRepository
    {
        Category GetCategory(int id);
        IEnumerable<Category> GetAllCategory();
        Category Add(Category category);
        Category Update(Category category);
        Category Delete(int id);
    }
}