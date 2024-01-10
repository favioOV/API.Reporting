using API.Application.DTOs;
using MediatR;

namespace API.Application.Commands
{
    public record UpdateItemCommand(int Id, string Nombre) : IRequest<ItemDTO>;
}
