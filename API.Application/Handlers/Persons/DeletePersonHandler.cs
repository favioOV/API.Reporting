using API.Application.Commands.Person;
using API.Infrastructure.Contracts;
using MediatR;

namespace API.Application.Handlers.Persons
{
    public class DeletePersonHandler : IRequestHandler<DeletePersonCommand>
    {
        private readonly IPersonRepository _personRepository;

        public DeletePersonHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            await _personRepository.DeletePersonAsync(request.Id, cancellationToken);
            return Unit.Value; // Indica que la operación se completó exitosamente
        }
    }
}
