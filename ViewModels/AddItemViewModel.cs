using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive;
using Todo.Models;

namespace Todo.ViewModels
{
    // ViewModel dla widoku dodawania nowego elementu TodoItem
    class AddItemViewModel : ViewModelBase
    {
        // Pole prywatne przechowujące opis
        string description;

        public AddItemViewModel()
        {
            // Utwórz obserwowalną właściwość, która jest włączona, jeśli opis nie jest pusty
            var okEnabled = this.WhenAnyValue(
                x => x.Description,
                x => !string.IsNullOrWhiteSpace(x));

            // Utwórz komendę Ok, która tworzy nowy element TodoItem, jeśli okEnabled jest prawdziwe
            Ok = ReactiveCommand.Create(
                () => new TodoItem { Description = Description },
                okEnabled);

            // Utwórz komendę Cancel, która nie wykonuje żadnej akcji
            Cancel = ReactiveCommand.Create(() => { });
        }

        // Właściwość do pobierania i ustawiania opisu zadania
        public string Description
        {
            get => description;
            set => this.RaiseAndSetIfChanged(ref description, value);
        }

        // Komenda Ok, która tworzy nowy element TodoItem
        public ReactiveCommand<Unit, TodoItem> Ok { get; }

        // Komenda Cancel, która nie wykonuje żadnej akcji
        public ReactiveCommand<Unit, Unit> Cancel { get; }
    }
}
