using MediatR;

namespace Application.ToDoItems.Commands
{
    public class UpdateToDoItemCommand : IRequest
    {
        public Guid Id {  get; set; }
        public string Name { get; set; }
        public bool isComplete { get; set; }
    }
}
