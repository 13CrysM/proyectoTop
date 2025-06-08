using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace proyectoTop.Models
{
    public class Cancion
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public int ReleaseYear { get; set; }
        public string Duration { get; set; }
        public string Lyrics { get; set; }
        public int Likes { get; set; } = 0;
        public string AudioUrl { get; set; } // URL del archivo de audio
        public string YoutubeId { get; set; }
    }
}
