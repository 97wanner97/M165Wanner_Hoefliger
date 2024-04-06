using Android.App;
using Android.Content.PM;
using Android.OS;

namespace Frontend
{
    /// <summary>
    /// Die Hauptaktivität für die MAUI-Anwendung, die beim Start ausgeführt wird.
    /// </summary>
    /// <remarks>
    /// Diese Klasse erbt von <see cref="MauiAppCompatActivity"/> und definiert die Einstiegspunkt-Aktivität
    /// der Anwendung. Sie spezifiziert das Thema, ob sie der Haupt-Launcher ist und wie sie auf bestimmte
    /// Konfigurationsänderungen reagiert, wie Bildschirmgröße und Ausrichtung.
    /// </remarks>
    [Activity(
        Theme = "@style/Maui.SplashTheme", 
        MainLauncher = true, 
        ConfigurationChanges =
            ConfigChanges.ScreenSize |
            ConfigChanges.Orientation |
            ConfigChanges.UiMode |
            ConfigChanges.ScreenLayout |
            ConfigChanges.SmallestScreenSize |
            ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
       
    }
}
