using API.Application.DTOs;
using MediatR;

namespace API.Application.Commands
{
    public record CreateItemCommand(string Nombre) : IRequest<ItemDTO>;
}