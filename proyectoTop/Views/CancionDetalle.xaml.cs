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

    private async void OnPlayClicked(object sender, EventArgs e)
    {
        var stream = await FileSystem.OpenAppPackageFileAsync("video.html");
        using var reader = new StreamReader(stream);
        string htmlContent = reader.ReadToEnd();

        videoWebView.Source = new HtmlWebViewSource
        {
            Html = htmlContent
        };

        videoWebView.IsVisible = true;
    }
}