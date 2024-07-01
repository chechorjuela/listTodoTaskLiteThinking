using ApplicationTask.Application.Features.TaskTodo.Commands.DeleteTask;
using ApplicationTask.Application.Features.TaskTodo.Commands.UpdateTask;
using ApplicationTask.Application.Features.TaskTodo.Queries;
using AutoMapper;

namespace ApplicationTask.Application.Features.Common.Mappers;

public class AutoMappingProfile : Profile
{
    public AutoMappingProfile()
    {
        this.CreateMap<CreateTaskTodoCommandModel, CreateTaskTodoCommand>();
        this.CreateMap<UpdateTaskTodoCommandModel, UpdateTaskTodoCommand>();
        this.CreateMap<DeleteTaskTodoCommandModel, DeleteTaskTodoCommand>();

    }
}