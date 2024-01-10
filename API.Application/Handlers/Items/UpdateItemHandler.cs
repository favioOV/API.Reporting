using API.Application.Commands;
using API.Application.DTOs;
using API.Infrastructure.Contracts;
using MediatR;

namespace API.Application.Handlers.Items
{
    public class UpdateItemHandler : IRequestHandler<UpdateItemCommand, ItemDTO>
    {
        private readonly IItemRepository _ItemRepository;

        public UpdateItemHandler(IItemRepository ItemRepository)
        {
            _ItemRepository = ItemRepository;
        }

        public async Task<ItemDTO?> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var Item = await _ItemRepository.GetItemByIdAsync(request.Id, cancellationToken);

            if (Item == null)
            {
                return null;
            }

            Item.Nombre = request.Nombre;

            await _ItemRepository.UpdateItemAsync(Item, cancellationToken);

            return new ItemDTO
            {
                Id = Item.Id,
                Nombre = Item.Nombre,
            };
        }
    }
}
