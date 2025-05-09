using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Domain
{
    public class Admin : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }
    }
}
