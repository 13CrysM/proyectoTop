using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using proyectoTop.Models;

namespace proyectoTop.ViewModels
{
    public class CancionDetalleViewModel : INotifyPropertyChanged
    {
        private int _likes;
        private bool _mostrarVideo;
        private bool _isBusy;
        public bool IsNotBusy => !IsBusy;
        public Cancion Cancion { get; }
        public ICommand LikeCommand { get; }
        public ICommand ReproducirCommand { get; }
        public ICommand MostrarVideoCommand { get; }
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;
                    OnPropertyChanged(nameof(IsBusy));
                    OnPropertyChanged(nameof(IsNotBusy)); // Notifica también el cambio de IsNotBusy
                }
            }
        }
        public int Likes
        {
            get => _likes;
            set
            {
                if (_likes != value)
                {
                    _likes = value;
                    OnPropertyChanged(nameof(Likes));
                }
            }
        }
        public CancionDetalleViewModel(Cancion cancion)
        {
            Cancion = cancion;
            _likes = cancion.Likes; // Inicializa con el valor del modelo
            LikeCommand = new Command(() =>
            {
                Likes++;
                Cancion.Likes = Likes; // Opcional: sincronizar el modelo
            });
            ReproducirCommand = new Command(async () => await ReproducirCancion());
            MostrarVideoCommand = new Command(async () => await EjecutarMostrarVideo());
            PropertyChanged = delegate { }; // Inicializa el evento para evitar valores NULL
        }

        public bool MostrarVideo
        {
            get => _mostrarVideo;
            set
            {
                if (_mostrarVideo != value)
                {
                    _mostrarVideo = value;
                    OnPropertyChanged(nameof(MostrarVideo));
                }
            }
        }
        private async Task ReproducirCancion()
        {
            if (IsBusy) return;

            IsBusy = true;
            try
            {
                if (App.Current?.MainPage == null)
                {
                    Debug.WriteLine("MainPage es null. No se puede mostrar la alerta.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(Cancion.YoutubeId))
                {
                    await App.Current.MainPage.DisplayAlert("Aviso", "Este video no está disponible", "OK");
                    return;
                }

                var youtubeAppUri = $"vnd.youtube://{Cancion.YoutubeId}";
                var canOpenYoutubeApp = await Launcher.CanOpenAsync(youtubeAppUri);

                if (canOpenYoutubeApp)
                {
                    await Launcher.OpenAsync(youtubeAppUri);
                }
                else
                {
                    var youtubeWebUrl = $"https://youtube.com/watch?v={Cancion.YoutubeId}";
                    await Launcher.OpenAsync(youtubeWebUrl);
                }
            }
            catch (FeatureNotSupportedException)
            {
                if (App.Current?.MainPage != null)
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Esta función no es soportada en tu dispositivo", "OK");
                }
            }
            catch (UriFormatException)
            {
                if (App.Current?.MainPage != null)
                {
                    await App.Current.MainPage.DisplayAlert("Error", "El enlace de video no es válido", "OK");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al abrir YouTube: {ex}");
                if (App.Current?.MainPage != null)
                {
                    await App.Current.MainPage.DisplayAlert("Error", "No se pudo abrir YouTube", "OK");
                }
            }
            finally
            {
                IsBusy = false;
            }
        }
        private async Task EjecutarMostrarVideo()
        {
            if (IsBusy) return;

            IsBusy = true;
            try
            {
                if (App.Current?.MainPage == null)
                {
                    Debug.WriteLine("MainPage es null. No se puede mostrar la alerta.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(Cancion?.VideoUrl))
                {
                    await App.Current.MainPage.DisplayAlert("Aviso", "Este video no tiene un enlace disponible", "OK");
                    return;
                }

                MostrarVideo = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error al mostrar video: {ex}");
                if (App.Current?.MainPage != null)
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Ocurrió un problema al intentar mostrar el video", "OK");
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            // Notifica cambios en propiedades dependientes
            if (propertyName == nameof(IsBusy))
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsNotBusy)));
            }
        }
    }
}
