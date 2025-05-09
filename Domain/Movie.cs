using CinemaApp.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Domain
{
    public class Movie : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public decimal Price { get; set; }
        public List<Projection> Projections { get; set; }
    }
}
