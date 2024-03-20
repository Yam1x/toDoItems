using Application.Common.Mappings;
using Application.ToDoItems.Commands;
using AutoMapper;

namespace lab2.Models.ToDoItem
{
    public class AddToDoItemDto : IMapWith<AddToDoItemCommand>
    {
        public string Name { get; set; }
        public bool isComplete { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AddToDoItemDto, AddToDoItemCommand>();
        }
    }
}
