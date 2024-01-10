using API.Application.Commands;
using API.Infrastructure.Contracts;
using MediatR;

namespace API.Application.Handlers.Items
{
    public class DeleteItemHandler : IRequestHandler<DeleteItemCommand>
    {
        private readonly IItemRepository _ItemRepository;

        public DeleteItemHandler(IItemRepository ItemRepository)
        {
            _ItemRepository = ItemRepository;
        }

        public async Task<Unit> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            await _ItemRepository.DeleteItemAsync(request.Id, cancellationToken);
            return Unit.Value; // Indica que la operación se completó exitosamente
        }
    }
}
