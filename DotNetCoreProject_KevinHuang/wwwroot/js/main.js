$(document).ready(function () {
    console.log("ready!");
    GetTodos();
});

function GetTodos() {
    $.ajax({
        url: "/api/todo",
        type: "get",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            console.log(data);
            RenderTodos(data);
        },
        error: function () {
            alert("ERROR GetTodos");
        }
    });
}

function AddTodo() {
    var title = $('#todo-title-input').val();
    var content = $('#todo-content-input').val();
    var data = {
        "Title": title,
        "Content": content
    }
    $.ajax({
        url: '/api/todo',
        type: 'post',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(data),
        success: function (result) {
            console.log(result);
            GetTodos();
        },
    });
}

function ChangeTodoStatus(id) {
    console.log(id)
    $.ajax({
        url: '/api/todo/' + id,
        type: 'put',
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            console.log(result);
            GetTodos();
        },
    });
}

function DeleteTodo(id) {
    console.log(id);
    $.ajax({
        url: '/api/todo/' + id,
        type: 'delete',
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            console.log(result);
            GetTodos();
        },
    });
}

//畫面js
function RenderTodos(data) {
    $('#todolist-ul').empty();
    for (i = 0; i < data.length; i++) {
        var html = `<li 
                    ${data[i].status ? 'class="checked"' : ''} 
                    onclick="ChangeTodoStatus(${data[i].id})"
                    >
                        <div class="todo-title">${data[i].title}</div>
                        <div class="todo-content">${data[i].content}</div>
                        <a class="close" onclick="DeleteTodo(${data[i].id})">x</a>
                    </li>`;
        $('#todolist-ul').append(html);
    }
}