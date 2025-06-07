using proyectoTop.Models;
using proyectoTop.ViewModels;

namespace proyectoTop.Views;

public partial class ListaArtistas : ContentPage
{
    public ListaArtistas()
    {
        InitializeComponent();
        BindingContext = new ArtistasViewModel();

    }
    private async void OnArtistTapped(object sender, EventArgs e)
    {
        if (sender is Frame frame && frame.BindingContext is Artista artista)
        {
            await Navigation.PushAsync(new CancionesPage(artista.Canciones));
        }
    }
}