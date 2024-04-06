using Microsoft.Extensions.Logging;

namespace Frontend
{
    public static class MauiProgram
    {
        /// <summary>
        /// Erstellt und konfiguriert die MAUI-App.
        /// </summary>
        /// <returns>Eine konfigurierte <see cref="MauiApp"/> Instanz.</returns>
        /// <remarks>
        /// Diese Methode konfiguriert die Hauptanwendungseinstellungen, wie die zu verwendende App-Klasse,
        /// die Schriftarten und das Logging, das im Debug-Modus aktiviert wird.
        /// </remarks>
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
