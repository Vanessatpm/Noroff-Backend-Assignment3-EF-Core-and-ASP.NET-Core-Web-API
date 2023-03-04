using MediaDatabaseCreator.Model;
using MediaDatabaseCreator.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace MediaDatabaseCreator.Services.Franchises
{
    public class FranchiseService : IFranchiseService
    {
        private readonly FilmDbContext _context;

        public FranchiseService(FilmDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Franchise>> GetAllAsync()
        {
            return await _context.Franchises.ToListAsync();
        }

        public async Task<Franchise?> GetByIdAsync(int id)
        {
            return await _context.Franchises.FindAsync(id);
        }
        //*************
        public async Task<IEnumerable<Franchise>?> GetAllMoviesAsync(int id)
        {
            //var franchise = await GetByIdAsync(id);
            //if (franchise == null)
            //{
            //    return null;
            //}
            // TODO: fetch movies. //return await franchise.Movies.ToListAsync();
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Character>?> GetAllCharactersAsync(int id) { 
            throw new NotImplementedException();
        }

        //**************

        public async Task<Franchise> AddAsync(Franchise obj)
        {
            await _context.Franchises.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task<Franchise> UpdateAsync(Franchise obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            // TODO:
            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!FranchiseExists(id))
            //    {
            //        throw error

            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return obj;
        }

        public async Task<Franchise?> DeleteAsync(int id)
        {
            var franchise = await GetByIdAsync(id);
            if (franchise != null) {
                _context.Franchises.Remove(franchise);
                await _context.SaveChangesAsync();
            }
            return franchise;
        }

        //TODO:
        //private bool FranchiseExists(int id)
        //{
        //    return _context.Franchises.Any(e => e.FranchiseId == id);
        //}

    }
}
