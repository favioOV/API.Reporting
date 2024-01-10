using API.Application.DTOs;
using API.Application.Querys.Person;
using API.Infrastructure.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Application.Handlers.Persons
{
    public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdQuery, PersonDTO>
    {
        private readonly IPersonRepository _personRepository;

        public GetPersonByIdHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<PersonDTO> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            var person = await _personRepository.GetPersonByIdAsync(request.id/*, cancellationToken*/);

            if (person == null)
            {
                return null;
            }

            return new PersonDTO
            {
                Id = person.Id,
                Name = person.Name,
                LastName = person.LastName
            };
        }
    }
}
