using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoTop.Models
{
    public class Artista
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Ranking { get; set; }
        public string LastAlbum { get; set; }
        public List<Cancion> Canciones { get; set; }

        public Artista()
        {
            Canciones = new List<Cancion>();
        }
    }
}
