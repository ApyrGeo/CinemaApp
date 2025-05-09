using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Domain
{
    public class Seat : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HallId { get; set; }
        public Hall Hall { get; set; } 
        public List<Ticket> Tickets { get; set; }
    }
}
