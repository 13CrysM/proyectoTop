using System.Collections.ObjectModel;
using System.Windows.Input;
using proyectoTop.Models;
using proyectoTop.Views;

namespace proyectoTop.ViewModels
{
    public class CancionesViewModel
    {
        public ObservableCollection<Cancion> Canciones { get; set; }
        public ICommand CancionSeleccionadaCommand { get; }
        public CancionesViewModel(List<Cancion> canciones)
        {
            Canciones = new ObservableCollection<Cancion>(canciones);
            CancionSeleccionadaCommand = new Command<Cancion>(OnCancionSeleccionada);
        }
        private async void OnCancionSeleccionada(Cancion cancion)
        {
            if (cancion == null) return;

            var mainPage = Application.Current?.MainPage;
            if (mainPage?.Navigation != null)
            {
                await mainPage.Navigation.PushAsync(new CancionDetalle(cancion));
            }
            else
            {
                // Manejo de error o lógica alternativa si MainPage o Navigation son nulos
                Console.WriteLine("Error: MainPage o Navigation son nulos.");
            }
        }
    }
}
