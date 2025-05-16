using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CinemaApp.Domain
{
    public class Ticket : Entity
    {
        public int Id { get; set; }
        public DateTime BuyDate { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }  
        public int ProjectionId { get; set; }
        [JsonIgnore]
        public Projection Projection { get; set; } 
        public int SeatId { get; set; }
        [JsonIgnore]
        public Seat Seat { get; set; }

        public string Code { get; set; }

        public override string ToString()
        {
            return $"Ticket: {Id}, Projection: {ProjectionId}, Seat: {SeatId}, User: {UserId}";
        }
    }
}
