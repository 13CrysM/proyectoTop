namespace proyectoTop.Models
{
    public class Cancion
    {
        public required string Title { get; set; }
        public required string ImageUrl { get; set; } // Se agregó el modificador 'required'
        public int ReleaseYear { get; set; }
        public required string Duration { get; set; } // Se agregó el modificador 'required'
        public required string Lyrics { get; set; }
        public int Likes { get; set; } = 0;
        public required string VideoUrl { get; set; }
        public required string YoutubeId { get; set; }
    }
}
