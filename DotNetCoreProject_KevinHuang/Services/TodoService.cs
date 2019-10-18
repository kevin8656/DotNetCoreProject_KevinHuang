using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreProject_KevinHuang.Models;

namespace DotNetCoreProject_KevinHuang.Services
{
    public class TodoService
    {
        private readonly dotnetcoreContext _context = new dotnetcoreContext();
        public List<Todo> GetTodos()
        {
            return _context.Todo.ToList();
        }

        public string AddTodo(Todo todo)
        {
            try
            {
                _context.Todo.Add(todo);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return "Add Todo Fail.";
            }
            return "Add Todo Success.";
        }

        public string UpdateTodo(int id)
        {
            try
            {
                var oldTodo = _context.Todo.FirstOrDefault(x => x.Id == id);
                if (oldTodo != null)
                {
                    oldTodo.Status = !oldTodo.Status;
                }
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return "Update Todo Fail.";
            }
            return "Update Todo Success.";
        }

        public string DeleteTodo(int id)
        {
            var todo = _context.Todo.FirstOrDefault(x => x.Id == id);
            if (todo == null) return "Delete Todo Success.";
            _context.Todo.Remove(todo);
            _context.SaveChanges();

            return "Delete Todo Success.";
        }
    }
}
