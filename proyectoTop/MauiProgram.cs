using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

namespace proyectoTop
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit() // 👈 Necesario para que funcionen los controles del toolkit
                .UseMauiCommunityToolkitMediaElement() // ✅ Necesario
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("DeathRattle-e9pPg.otf", "DeathRatle");
                    fonts.AddFont("Outfit-Regular.ttf", "Outfit");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
