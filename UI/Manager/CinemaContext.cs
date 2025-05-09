using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.UI.Manager
{
    public class CinemaContext(int cinemaId)
    {
        public int CinemaId { get; set; } = cinemaId;
    }
}
