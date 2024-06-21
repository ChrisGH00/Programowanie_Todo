using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using Todo.Models;
using Todo.Services;

namespace Todo.ViewModels
{
    // ViewModel dla głównego okna aplikacji
    public class MainWindowViewModel : ViewModelBase
    {
        // Pole prywatne przechowujące aktualnie wyświetlany ViewModel
        ViewModelBase content;

        // Konstruktor przyjmujący obiekt bazy danych jako parametr
        public MainWindowViewModel(Database db)
        {
            // Ustawienie początkowej zawartości na listę zadań
            Content = List = new TodoListViewModel(db.GetItems());
        }

        // Właściwość do pobierania i ustawiania aktualnie wyświetlanego ViewModelu
        public ViewModelBase Content
        {
            get => content;
            private set => this.RaiseAndSetIfChanged(ref content, value);
        }

        // Właściwość przechowująca ViewModel listy zadań
        public TodoListViewModel List { get; }

        // Metoda dodająca nowy element do listy zadań
        public void AddItem()
        {
            var vm = new AddItemViewModel();

            // Subskrypcja na wynik dodania nowego elementu lub anulowania operacji
            Observable.Merge(
                vm.Ok,
                vm.Cancel.Select(_ => (TodoItem)null))
                .Take(1)
                .Subscribe(model =>
                {
                    if (model != null)
                    {
                        // Dodanie nowego elementu do listy zadań, jeśli operacja nie została anulowana
                        List.Items.Add(model);
                    }

                    // Powrót do widoku listy zadań
                    Content = List;
                });

            // Ustawienie zawartości na ViewModel dodawania nowego elementu
            Content = vm;
        }
    }
}
