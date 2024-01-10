using MediatR;

namespace API.Application.Commands.Person
{
    public record DeletePersonCommand(int Id) : IRequest;
}
