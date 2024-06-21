using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Logging.Serilog;
using Avalonia.ReactiveUI;

namespace Todo
{
    // Klasa główna programu
    class Program
    {
        // Główna metoda programu
        public static void Main(string[] args) => BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);

        // Metoda konfiguracji aplikacji Avalonia
        public static AppBuilder BuildAvaloniaApp()
        {
            // Konfiguracja i inicjalizacja aplikacji Avalonia
            return AppBuilder.Configure<App>()
                .UsePlatformDetect()   // Użycie mechanizmu wykrywania platformy
                .LogToDebug()          // Logowanie do debugu
                .UseReactiveUI();      // Użycie ReactiveUI do reaktywnego interfejsu użytkownika
        }
    }
}
