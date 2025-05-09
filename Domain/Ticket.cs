using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Domain
{
    public class Ticket : Entity
    {
        public int Id { get; set; }
        public DateTime BuyDate { get; set; }
        public int UserId { get; set; } 
        public User User { get; set; }  
        public int ProjectionId { get; set; }  
        public Projection Projection { get; set; } 
        public int SeatId { get; set; }  
        public Seat Seat { get; set; }
    }
}
