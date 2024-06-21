using System;

namespace Todo.Models
{
    // Reprezentuje pojedynczy element listy rzeczy do zrobienia
    public class TodoItem
    {
        // Opis zadania
        public string Description { get; set; }

        // Flaga oznaczająca, czy zadanie jest wykonane
        public bool IsChecked { get; set; }
    }
}
