using Microsoft.Maui.Controls;

namespace Frontend
{
    /// <summary>
    /// Die Hauptklasse für die .NET MAUI-Anwendung.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="App"/> Klasse.
        /// </summary>
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}
