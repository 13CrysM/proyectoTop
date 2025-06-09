namespace proyectoTop.Models
{
    public class Artista
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Se inicializa con un valor predeterminado
        public string ImageUrl { get; set; } = string.Empty; // Se inicializa con un valor predeterminado
        public int Ranking { get; set; }
        public string LastAlbum { get; set; } = string.Empty; // Se inicializa con un valor predeterminado
        public List<Cancion> Canciones { get; set; } = new(); // Simplificación de inicialización
    }
}
