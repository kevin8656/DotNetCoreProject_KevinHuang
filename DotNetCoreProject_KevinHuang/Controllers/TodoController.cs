using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreProject_KevinHuang.Models;
using DotNetCoreProject_KevinHuang.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreProject_KevinHuang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoService _todoService = new TodoService();//引入TodoService

        #region 取得所有Todo資料(待辦事項)
        [HttpGet]
        public List<Todo> Get()
        {
            return _todoService.GetTodos(); ;
        }
        #endregion

        #region 新增Todo資料(待辦事項)
        [HttpPost]
        public string AddTodo([FromBody]Todo todo)
        {
            return _todoService.AddTodo(todo); ;
        }
        #endregion

        #region 更新Todo資料(待辦事項)
        [HttpPut("{Id}")]
        public string UpdateTodo(int id)
        {
            return _todoService.UpdateTodo(id);
        }
        #endregion

        #region 刪除Todo資料(待辦事項)
        [HttpDelete("{Id}")]
        public string DeleteTodo(int id)
        {
            return _todoService.DeleteTodo(id);
        }
        #endregion
    }
}