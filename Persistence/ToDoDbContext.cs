using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class ToDoDbContext : DbContext, IToDoDbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }

        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
