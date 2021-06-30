using System;
using Microsoft.EntityFrameworkCore;

namespace restapidemo
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<Fruit> Fruits { get; set; }

        public DbSet<City> tblCities { get; set; }

        public DbSet<Visit> visits { get; set; }
    }
}