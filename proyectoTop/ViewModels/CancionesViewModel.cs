using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            await Application.Current.MainPage.Navigation.PushAsync(new CancionDetalle(cancion));
        }
    }
}
