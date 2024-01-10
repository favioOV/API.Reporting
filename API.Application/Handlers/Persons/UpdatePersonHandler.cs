using API.Application.Commands.Person;
using API.Application.DTOs;
using API.Infrastructure.Contracts;
using MediatR;

namespace API.Application.Handlers.Persons
{
    public class UpdatePersonHandler : IRequestHandler<UpdatePersonCommand, PersonDTO>
    {
        private readonly IPersonRepository _personRepository;

        public UpdatePersonHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<PersonDTO> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _personRepository.GetPersonByIdAsync(request.Id/*, cancellationToken*/);

            if (person == null)
            {
                // Opcional: Manejar el caso de no encontrar la persona
                return null;
            }

            person.Name = request.Name;
            person.LastName = request.LastName;

            await _personRepository.UpdatePersonAsync(person, cancellationToken);

            return new PersonDTO
            {
                Id = person.Id,
                Name = person.Name,
                LastName = person.LastName
            };
        }
    }
}
