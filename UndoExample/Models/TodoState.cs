using System;
using System.Collections.Generic;
using System.Linq;

namespace UndoExample.Models
{
    public class TodoState
    {
        private readonly Stack<IEnumerable<TodoItem>> TodoBuffer = new Stack<IEnumerable<TodoItem>>();

        public IEnumerable<TodoItem> Current => TodoBuffer.Count == 0 ? new List<TodoItem>() : TodoBuffer.Peek();

        public int Count() => Current.Count(todo => !todo.IsDone);

        public bool CanUndo() => TodoBuffer.Count > 0;
        
        public void AddTodo(TodoItem item)
        {
            var newState = new List<TodoItem>(Current) { item };
            TodoBuffer.Push(newState);
        }

        public void ClearFinished()
        {
            if (Current.Any(todo => todo.IsDone))
                TodoBuffer.Push(Current.Where(todo => !todo.IsDone).ToList());
        }

        public void Undo()
        {
            if (TodoBuffer.Count > 0)
                TodoBuffer.Pop();
        }
    }
}
