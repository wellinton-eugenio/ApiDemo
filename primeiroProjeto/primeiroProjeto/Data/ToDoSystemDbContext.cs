using Microsoft.EntityFrameworkCore;
using primeiroProjeto.Data.Map;
using primeiroProjeto.Models;

namespace primeiroProjeto.Data
{
    public class ToDoSystemDbContext : DbContext
    {
        public ToDoSystemDbContext(DbContextOptions<ToDoSystemDbContext> options)
            : base(options)
        {

        }

        public DbSet<UsersModel> Users { get; set; }
        public DbSet<ToDoModel> ToDo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new ToDoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
