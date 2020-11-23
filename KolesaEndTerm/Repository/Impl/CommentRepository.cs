using System.Collections.Generic;
using KolesaEndTerm.Data;
using KolesaEndTerm.Models;

namespace KolesaEndTerm.Repository.Impl
{
    public class CommentRepository : ICommentRepository
    {
        
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public Comment GetComment(int id)
        {
            return _context.Comments.Find(id);
        }

        public IEnumerable<Comment> GetAllComments()
        {
            return _context.Comments;
        }

        public Comment Add(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return comment;
        }

        public Comment Update(Comment comment)
        {
            var c = _context.Comments.Attach(comment);
            c.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return comment;
        }

        public Comment Delete(int id)
        {
            var comment = _context.Comments.Find(id);
            if (comment == null) return null;
            _context.Comments.Remove(comment);
            _context.SaveChanges();

            return comment;
        }
    }
}