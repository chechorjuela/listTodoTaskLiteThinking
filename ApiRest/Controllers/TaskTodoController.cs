using ApplicationTask.Application.Features.TaskTodo.Commands.DeleteTask;
using ApplicationTask.Application.Features.TaskTodo.Commands.UpdateTask;
using ApplicationTask.Application.Features.TaskTodo.Queries;
using ApplicationTask.Application.Features.TaskTodo.Queries.GetTaskTodo;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controllers;

public class TaskTodoController : BaseController
{
    [HttpGet]
    [Produces(typeof(GetTaskTodoQueryDto))]
    [ActionName(nameof(GetAll))]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetTaskTodoQuery();
        var response = await this.Mediator.Send(query);
        return this.FromResult(response);
    }
    
    [HttpPost]
    [Produces(typeof(GetTaskTodoQueryDto))]
    [ActionName(nameof(Create))]
    public async Task<IActionResult> Create(CreateTaskTodoCommandModel model)
    {
        var command = this.Mapper.Map<CreateTaskTodoCommand>(model);
        var response = await this.Mediator.Send(command);
        return this.FromResult(response);
    }

    [HttpPut]
    [Route("Update")]
    [Produces(typeof(UpdateTaskTodoCommandDto))]
    [ActionName(nameof(Update))]
    public async Task<IActionResult> Update(UpdateTaskTodoCommandModel model)
    {
        var command = this.Mapper.Map<UpdateTaskTodoCommand>(model);
        var response = await this.Mediator.Send(command);
        return FromResult(response);
    }
    
    [HttpDelete]
    [Route("Delete")]
    [Produces(typeof(DeleteTaskTodoCommandDto))]
    [ActionName(nameof(Delete))]
    public async Task<IActionResult> Delete(DeleteTaskTodoCommandModel model)
    {
        var command = this.Mapper.Map<DeleteTaskTodoCommand>(model);
        var response = await this.Mediator.Send(command);
        return FromResult(response);
    }
}