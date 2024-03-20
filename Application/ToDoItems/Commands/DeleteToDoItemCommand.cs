using MediatR;

namespace Application.ToDoItems.Commands
{
    public class DeleteToDoItemCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
