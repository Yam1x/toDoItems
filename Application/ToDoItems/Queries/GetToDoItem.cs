using MediatR;

namespace Application.ToDoItems.Queries
{
    public class GetToDoItem : IRequest<ToDoItemVm>
    {
        public Guid Id { get; set; }
    }
}
