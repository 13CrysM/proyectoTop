using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using proyectoTop.Models;

namespace proyectoTop.ViewModels
{
    public class CancionDetalleViewModel : INotifyPropertyChanged
    {
        private int _likes;
        public Cancion Cancion { get; }

        public CancionDetalleViewModel(Cancion cancion)
        {
            Cancion = cancion;
            _likes = cancion.Likes; // Inicializa con el valor del modelo
            LikeCommand = new Command(() =>
            {
                Likes++;
                Cancion.Likes = Likes; // Opcional: sincronizar el modelo
            });
            ReproducirCommand = new Command(ReproducirCancion);

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
        private void ReproducirCancion()
        {/*
            // Aquí va la lógica de reproducción.
            // Por ejemplo, si usas un archivo local o remoto:
            // await AudioPlayer.Current.PlayAsync("url_o_archivo.mp3");

            // Para fines de prueba:
            App.Current.MainPage.DisplayAlert("Reproducir", $"Reproduciendo: {Cancion.Title}", "OK");*/

            /*try
            {
                var audioManager = AudioManager.Current;

                // Abre el archivo desde Resources/Raw
                using var audioStream = await FileSystem.OpenAppPackageFileAsync(Cancion.AudioUrl);

                var player = audioManager.CreatePlayer(audioStream);
                player.Play();
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", $"No se pudo reproducir el audio: {ex.Message}", "OK");
            }*/
            App.Current.MainPage.DisplayAlert("Reproducir", $"Reproduciendo: {Cancion.Title}", "OK");

        }
        public ICommand LikeCommand { get; }
        public ICommand ReproducirCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
