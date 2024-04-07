using Android.App;
using Android.Runtime;
using System;

namespace Frontend
{
    /// <summary>
    /// Die Hauptanwendungsklasse für eine MAUI-App unter Android. Diese Klasse wird initialisiert,
    /// bevor irgendeine andere Klasse oder Aktivität genutzt wird.
    /// </summary>
    /// <remarks>
    /// Diese Klasse erbt von <see cref="MauiApplication"/> und konfiguriert die Anwendung beim Start.
    /// Sie verwendet die <see cref="MauiProgram.CreateMauiApp"/>-Methode, um die App zu initialisieren und zu konfigurieren.
    /// </remarks>
    [Application]
    public class MainApplication : MauiApplication
    {
        /// <summary>
        /// Konstruktor, der von der Android-Runtime aufgerufen wird, um die Anwendung zu initialisieren.
        /// </summary>
        /// <param name="handle">Ein <see cref="IntPtr"/>, der das native Android-Objekt repräsentiert.</param>
        /// <param name="ownership">Die Übergabe des Besitzes des Objekts an die Xamarin-Runtime.</param>
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
        }

        /// <summary>
        /// Erstellt die MAUI-App-Instanz, die von dieser Anwendung verwendet wird.
        /// </summary>
        /// <returns>Eine konfigurierte <see cref="MauiApp"/>-Instanz.</returns>
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}
