using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Todo.Models;

namespace Todo.ViewModels
{
    // ViewModel dla widoku listy zadań
    public class TodoListViewModel : ViewModelBase
    {
        // Konstruktor przyjmujący kolekcję elementów TodoItem jako parametr
        public TodoListViewModel(IEnumerable<TodoItem> items)
        {
            // Inicjalizacja kolekcji elementów zadań
            Items = new ObservableCollection<TodoItem>(items);
        }

        // Kolekcja elementów zadań
        public ObservableCollection<TodoItem> Items { get; }
    }
}
