using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Todo.ViewModels;

namespace Todo
{
    // Klasa ViewLocator implementuj¹ca interfejs IDataTemplate
    public class ViewLocator : IDataTemplate
    {
        // W³aœciwoœæ okreœlaj¹ca, czy szablon obs³uguje recycling kontrolek
        public bool SupportsRecycling => false;

        // Metoda Build tworz¹ca kontrolkê na podstawie obiektu ViewModelu
        public IControl Build(object data)
        {
            // Budowanie nazwy widoku na podstawie nazwy ViewModelu
            var name = data.GetType().FullName.Replace("ViewModel", "View");
            var type = Type.GetType(name);

            // Jeœli znaleziono typ widoku, tworzy now¹ instancjê tego widoku
            if (type != null)
            {
                return (Control)Activator.CreateInstance(type);
            }
            else
            {
                // Jeœli nie znaleziono odpowiedniego widoku, zwraca domyœlny TextBlock z informacj¹ o braku
                return new TextBlock { Text = "Nie znaleziono widoku dla: " + name };
            }
        }

        // Metoda Match okreœlaj¹ca, czy dany obiekt pasuje do tego szablonu danych
        public bool Match(object data)
        {
            // Sprawdzenie, czy obiekt jest typu ViewModelBase
            return data is ViewModelBase;
        }
    }
}
