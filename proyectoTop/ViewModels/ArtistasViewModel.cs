using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using proyectoTop.Models;
using proyectoTop.Services;
using proyectoTop.Views;

namespace proyectoTop.ViewModels
{
    public class ArtistasViewModel : INotifyPropertyChanged
    {
        public List<Artista> Artistas { get; set; } = new List<Artista>(); // Initialize to avoid null

        public ArtistasViewModel()
        {
            CargarArtistas();
            ArtistaSeleccionadoCommand = new Command<Artista>(OnArtistaSeleccionado);
        }

        private void CargarArtistas()
        {
            // Cargar los artistas desde el servicio de datos
            Artistas = Datos.GetTop10Artists()
                .OrderBy(a => a.Ranking)
                .ToList();
            OnPropertyChanged(nameof(Artistas)); // Notificar el cambio de propiedad
        }

        public ICommand ArtistaSeleccionadoCommand { get; }

        private async void OnArtistaSeleccionado(Artista artista)
        {
            if (artista == null || artista.Canciones == null || !artista.Canciones.Any()) return;

            // Navega a la nueva vista pasando la lista de canciones del artista
            if (Application.Current?.MainPage?.Navigation != null)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new CancionesPage(artista.Canciones));
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
