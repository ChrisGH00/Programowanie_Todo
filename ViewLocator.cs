using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Todo.ViewModels;

namespace Todo
{
    // Klasa ViewLocator implementuj�ca interfejs IDataTemplate
    public class ViewLocator : IDataTemplate
    {
        // W�a�ciwo�� okre�laj�ca, czy szablon obs�uguje recycling kontrolek
        public bool SupportsRecycling => false;

        // Metoda Build tworz�ca kontrolk� na podstawie obiektu ViewModelu
        public IControl Build(object data)
        {
            // Budowanie nazwy widoku na podstawie nazwy ViewModelu
            var name = data.GetType().FullName.Replace("ViewModel", "View");
            var type = Type.GetType(name);

            // Je�li znaleziono typ widoku, tworzy now� instancj� tego widoku
            if (type != null)
            {
                return (Control)Activator.CreateInstance(type);
            }
            else
            {
                // Je�li nie znaleziono odpowiedniego widoku, zwraca domy�lny TextBlock z informacj� o braku
                return new TextBlock { Text = "Nie znaleziono widoku dla: " + name };
            }
        }

        // Metoda Match okre�laj�ca, czy dany obiekt pasuje do tego szablonu danych
        public bool Match(object data)
        {
            // Sprawdzenie, czy obiekt jest typu ViewModelBase
            return data is ViewModelBase;
        }
    }
}
