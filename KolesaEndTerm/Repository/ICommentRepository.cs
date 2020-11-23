using System.Collections.Generic;
using KolesaEndTerm.Models;

namespace KolesaEndTerm.Repository
{
    public interface ICommentRepository
    {
        Comment GetComment(int id);
        IEnumerable<Comment> GetAllComments();
        Comment Add(Comment comment);
        Comment Update(Comment comment);
        Comment Delete(int id);
    }
}