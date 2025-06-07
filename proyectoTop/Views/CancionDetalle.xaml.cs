using proyectoTop.Models;
using proyectoTop.ViewModels;

namespace proyectoTop.Views;

public partial class CancionDetalle : ContentPage
{
    public CancionDetalle(Cancion cancion)
    {
        InitializeComponent();
        BindingContext = new CancionDetalleViewModel(cancion);
    }
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        Media.Pause();
    }
}