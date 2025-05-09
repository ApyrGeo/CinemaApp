using CinemaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Service.Observer
{
    public enum EventType
    { 
        ADD, UPDATE, DELETE
    }
    public class ChangeEvent
    {
        public EventType EventType { get; set; }
        public Entity? Entity { get; set; }
        public string? Message { get; set; }
    }
}
