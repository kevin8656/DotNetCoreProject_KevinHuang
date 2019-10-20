using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreProject_KevinHuang.Models;

namespace DotNetCoreProject_KevinHuang.Services
{
    public class TodoService
    {
        private readonly dotnetcoreContext _context = new dotnetcoreContext();//引入EF Core套件自動產生的資料庫設定檔案
        #region 取得所有Todo資料
        public List<Todo> GetTodos()
        {
            return _context.Todo.ToList();
        }
        #endregion

        #region 新增Todo資料
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
        #endregion

        #region 更新Todo資料
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
        #endregion

        #region 刪除Todo資料 
        public string DeleteTodo(int id)
        {
            var todo = _context.Todo.FirstOrDefault(x => x.Id == id);
            if (todo == null) return "Delete Todo Success.";
            _context.Todo.Remove(todo);
            _context.SaveChanges();

            return "Delete Todo Success.";
        }
        #endregion
    }
}
