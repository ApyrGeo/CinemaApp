using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Domain
{
    public class Hall : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int CinemaId { get; set; } 
        public Cinema Cinema { get; set; } 
        public List<Seat> Seats { get; set; } 
        public List<Projection> Projections { get; set; }
    }
}
