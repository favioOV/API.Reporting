using MediatR;

namespace API.Application.Commands
{
    public record DeleteItemCommand(int Id) : IRequest;
}
