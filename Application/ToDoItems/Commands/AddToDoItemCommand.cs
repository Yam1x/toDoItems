using MediatR;

namespace Application.ToDoItems.Commands
{
    public class AddToDoItemCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } 
        public bool isComplete { get; set; }
    }
}
