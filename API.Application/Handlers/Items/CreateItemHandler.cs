using API.Application.Commands;
using API.Application.DTOs;
using API.Domain.Entities;
using API.Infrastructure.Contracts;
using MediatR;

namespace API.Application.Handlers.Items
{
    public class CreateItemHandler : IRequestHandler<CreateItemCommand, ItemDTO>
    {
        private readonly IItemRepository _ItemRepository;

        public CreateItemHandler(IItemRepository ItemRepository)
        {
            _ItemRepository = ItemRepository;
        }

        public async Task<ItemDTO> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var Item = new Item
            {
                Nombre = request.Nombre
            };

            await _ItemRepository.SaveItemAsync(Item, cancellationToken); 

            return new ItemDTO
            {
                Id = Item.Id, 
                Nombre = Item.Nombre
            };
        }
    }
}
