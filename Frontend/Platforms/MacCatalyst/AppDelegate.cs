using Foundation;
using Microsoft.Maui;

namespace Frontend
{
    /// <summary>
    /// Die Hauptklasse für die Verwaltung des Lebenszyklus und der Konfiguration der Anwendung auf iOS.
    /// </summary>
    /// <remarks>
    /// Die <see cref="AppDelegate"/> Klasse erbt von <see cref="MauiUIApplicationDelegate"/> und
    /// implementiert den App-Lebenszyklus und andere wichtige Ereignisse. Mit dem <see cref="Register"/> Attribut
    /// wird die AppDelegate-Klasse bei der iOS-App registriert, so dass sie als Einstiegspunkt für die Anwendung dient.
    /// </remarks>
    [Register("AppDelegate")]
    public class AppDelegate : MauiUIApplicationDelegate
    {
        /// <summary>
        /// Überschreibt die Methode, um die .NET MAUI-App zu erstellen.
        /// </summary>
        /// <returns>Eine <see cref="MauiApp"/>, die die Konfiguration und Dienste der App definiert.</returns>
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}
