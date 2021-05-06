using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FilmsWebApp.Models
{
    public class Lab2FilmsContext : DbContext
    {
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<FilmsActors> FilmsActors { get; set; }
        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<FilmsGenres> FilmsGenres { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }

        public Lab2FilmsContext(DbContextOptions<Lab2FilmsContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
