using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsWebApp.Models
{
    public class Genre
    {
        public Genre()
        {
            FilmsGenres = new List<FilmsGenres>();
        }

        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public string GenreDescription { get; set; }

        public virtual ICollection<FilmsGenres> FilmsGenres { get; set; }
    }
}
