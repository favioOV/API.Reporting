using API.Domain.Entities;
using API.Infrastructure;
using API.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;

namespace API.Application.Services
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ReportContext _context;

        public PersonRepository(ReportContext context)
        {
            _context = context;
        }

        public async Task<Person?> GetPersonByIdAsync(int? id/*, CancellationToken cancellationToken*/)
        {
            return await _context.Persons.FirstOrDefaultAsync(p => p.Id == id/*, cancellationToken*/);
        }

        public async Task<IEnumerable<Person>> GetAllPersonsAsync(/*CancellationToken cancellationToken*/)
        {
            return await _context.Persons.ToListAsync(/*cancellationToken*/);
        }

        public async Task SavePersonAsync(Person person, CancellationToken cancellationToken)
        {
            await _context.Persons.AddAsync(person, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdatePersonAsync(Person person, CancellationToken cancellationToken)
        {
            _context.Persons.Update(person);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeletePersonAsync(int id, CancellationToken cancellationToken)
        {
            var person = await _context.Persons.FindAsync(new object[] { id }, cancellationToken);
            if (person != null)
            {
                _context.Persons.Remove(person);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}