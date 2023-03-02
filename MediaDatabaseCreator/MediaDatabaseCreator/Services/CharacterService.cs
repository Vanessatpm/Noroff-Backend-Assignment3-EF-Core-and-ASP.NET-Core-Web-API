using MediaDatabaseCreator.Model;
using Microsoft.EntityFrameworkCore;

namespace MediaDatabaseCreator.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly FilmDbContext _context;

        public async Task<Character> AddAsync(Character obj)
        {
             return await _context.Characters.AddAsync(obj);
        }

        public void Delete(int obj)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Character>> GetAllAsync()
        {
            return await _context.Characters.ToArrayAsync();   
        }

        public Task<Character> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Character> UpdateAsync(Character obj)
        {
            throw new NotImplementedException();
        }
    }
