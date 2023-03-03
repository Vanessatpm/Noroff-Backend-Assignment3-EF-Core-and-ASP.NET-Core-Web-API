using MediaDatabaseCreator.Model;
using MediaDatabaseCreator.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace MediaDatabaseCreator.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly FilmDbContext _context;

        public CharacterService(FilmDbContext context)
        {
            _context = context;
        }


        public async Task<Character> AddAsync(Character obj)
        {
            await _context.Characters.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public Task<Character?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Character>> GetAllAsync()
        {
            return await _context.Characters.ToListAsync();
        }

        public async Task<Character?> GetByIdAsync(int id)
        { 
                return await _context.Characters.FindAsync(id);
        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync(int id)
        {
            return (await _context.Characters
                .Where(c => c.CharacterId== id)
                .Include(c => c.Movies)
                .FirstAsync()).Movies;
        }

        public async Task<Character> UpdateAsync(Character obj)
        {
             _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return obj;
        }
    }
}