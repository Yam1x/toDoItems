using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.ToDoItems.Queries
{
    public class ToDoItemVm : IMapWith<TodoItem>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool isComplete { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TodoItem, ToDoItemVm>();
        }
    }
}
