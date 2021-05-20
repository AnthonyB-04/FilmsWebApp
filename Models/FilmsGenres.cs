using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsWebApp.Models
{
    public class FilmsGenres
    {
        public int FilmsGenresId { get; set; }
        public int FilmId { get; set; }
        public int GenreId { get; set; }

        public virtual Film Film { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
