using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using System;

namespace Frontend
{
    /// <summary>
    /// Die Startklasse für die .NET MAUI-Anwendung.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Der Einstiegspunkt der Anwendung.
        /// </summary>
        /// <param name="args">Die Startargumente der Anwendung.</param>
        static void Main(string[] args)
        {
            MauiApp.CreateBuilder()
                .UseMauiApp<App>() 
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .Build() 
                .Run(); 
        }
    }
}
