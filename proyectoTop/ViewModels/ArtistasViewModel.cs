using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
