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
        private readonly TodoService _todoService = new TodoService();
        [HttpGet]
        public List<Todo> Get()
        {
            return _todoService.GetTodos(); ;
        }
        [HttpPost]
        public string AddTodo([FromBody]Todo todo)
        {
            return _todoService.AddTodo(todo); ;
        }
        [HttpPut("{Id}")]
        public string UpdateTodo(int id)
        {
            return _todoService.UpdateTodo(id);
        }
        [HttpDelete("{Id}")]
        public string DeleteTodo(int id)
        {
            return _todoService.DeleteTodo(id);
        }
    }
}