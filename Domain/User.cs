﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Domain
{
    public class User : Entity 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; } 
        public List<Ticket> Tickets { get; set; }
    }
}
