using System;
using System.Collections.Generic;
using Todo.Models;

namespace Todo.Services
{
    // Reprezentuje bazę danych dla elementów listy rzeczy do zrobienia
    public class Database
    {
        // Zwraca kolekcję elementów TodoItem
        public IEnumerable<TodoItem> GetItems() => new[]
        {
            new TodoItem { Description = "Wyprowadzić psa" },
            new TodoItem { Description = "Pójść na zakupy" },
        };
    }
}
