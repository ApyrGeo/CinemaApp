using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Domain
{
    public class Cinema : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int NoOfHalls { get; set; }
        public List<Hall> Halls { get; set; }

    }
}
