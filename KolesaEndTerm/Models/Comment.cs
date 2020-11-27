using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace KolesaEndTerm.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string IdentityUserId { get; set; }
        public int CarId { get; set; }
        public string Text { get; set; }
        public IdentityUser IdentityUser;
    }
}
