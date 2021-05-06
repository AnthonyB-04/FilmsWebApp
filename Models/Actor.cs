using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsWebApp.Models
{
    public class Actor
    {
        public Actor()
        {
            FilmsActors = new List<FilmsActors>();
        }

        public int ActorId { get; set; }
        public string ActorName { get; set; }
        public DateTime ActorBirthDate { get; set; }
        public string ActorInfo { get; set; }

        public virtual ICollection<FilmsActors> FilmsActors { get; set; }
    }
}
