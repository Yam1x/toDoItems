using Application.Interfaces;
using Application.ToDoItems.Commands;
using Application.ToDoItems.Queries;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.ToDoItems.Handlers
{
    public class ToDoItemsHandler : IRequestHandler<AddToDoItemCommand, Guid>, IRequestHandler<GetToDoItemsList, ToDoItemsListVm>, IRequestHandler<GetToDoItem, ToDoItemVm>, IRequestHandler<UpdateToDoItemCommand>, IRequestHandler<DeleteToDoItemCommand>
    {
        private readonly IToDoDbContext _dbContext;
        private readonly IMapper _mapper;

        public ToDoItemsHandler(IToDoDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(AddToDoItemCommand request, CancellationToken cancellationToken)
        {
            var item = new TodoItem()
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                isComplete = request.isComplete
            };
            await _dbContext.TodoItems.AddAsync(item);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return item.Id;
        }

        public async Task<ToDoItemsListVm> Handle(GetToDoItemsList request, CancellationToken cancellationToken)
        {
            var items = await _dbContext.TodoItems.
                ProjectTo<ToDoItemVm>(_mapper.ConfigurationProvider).
                ToListAsync(cancellationToken);
            
            return new ToDoItemsListVm { ToDoItems = items };
        }

        public async Task<ToDoItemVm> Handle(GetToDoItem request, CancellationToken cancellationToken)
        {
            var item = await _dbContext.TodoItems.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

            if (item == null)
            {
                throw new Exception("Задача не найдена");
            }
            return _mapper.Map<ToDoItemVm>(item);
        }

        public async Task Handle(UpdateToDoItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _dbContext.TodoItems.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

            if (item == null)
            {

                throw new Exception("Задача не найдена");
            }
            if (request.Name != null)
            {
                item.Name = request.Name;
            }
            item.isComplete = request.isComplete;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Handle(DeleteToDoItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _dbContext.TodoItems.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

            if (item == null)
            {
                throw new Exception("Задача не найдена");
            }

            _dbContext.TodoItems.Remove(item);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
