using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsWebApp.Models
{
    public class Director
    {
        public Director()
        {
            Films = new List<Film>();
        }

        public int DirectorId { get; set; }
        public string DirectorName { get; set; }
        public DateTime DirectorBirthDate { get; set; }
        public string DirectorInfo { get; set; }

        public virtual ICollection<Film> Films { get; set; }
    }
}
