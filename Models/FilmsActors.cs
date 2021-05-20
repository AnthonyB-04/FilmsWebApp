using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsWebApp.Models
{
    public class FilmsActors
    {
        public int FilmsActorsId { get; set; }
        public int FilmId { get; set; }
        public int ActorId { get; set; }

        public virtual Film Film { get; set; }
        public virtual Actor Actor { get; set; }
    }
}
