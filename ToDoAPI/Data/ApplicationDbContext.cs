using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.Authentication;

namespace ToDoAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> opt) : base(opt)
        {

        }

        #region DbSet
        public DbSet<ToDoItem>? ToDoItems { get; set; }
        #endregion
    }

}
