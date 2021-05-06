using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsWebApp.Models
{
    public class Film
    {
        public Film()
        {
            FilmsActors = new List<FilmsActors>();
            FilmsGenres = new List<FilmsGenres>();
        }

        public int FilmId { get; set; }
        public string FilmTitle { get; set; }
        public int Year { get; set; }
        public string RunningTime { get; set; }
        public string Description { get; set; }
        public int DirectorId { get; set; }

        public virtual Director Director { get; set; }
        public virtual ICollection<FilmsActors> FilmsActors { get; set; }
        public virtual ICollection<FilmsGenres> FilmsGenres { get; set; }
    }
}
