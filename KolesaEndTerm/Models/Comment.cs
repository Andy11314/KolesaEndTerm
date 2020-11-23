using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolesaEndTerm.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public string Text { get; set; }
    }
}
