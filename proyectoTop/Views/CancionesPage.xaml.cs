using proyectoTop.Models;
using proyectoTop.ViewModels;

namespace proyectoTop.Views
{
    public partial class CancionesPage : ContentPage
    {
        public CancionesPage(List<Cancion> canciones)
        {
            InitializeComponent();
            BindingContext = new CancionesViewModel(canciones);
        }
    }
}