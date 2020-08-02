using Domain.Dto.Layer;
using Domain.Layer;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emprendimiento.API.Repositories
{
    public interface IRepositoryProvider
    {
        Task<Provider> Get(int idProvider);
        Task<IEnumerable<Provider>> GetAllByUser(int idUser);
        Task<int> Save(Provider rq);
        Task<bool> Delete(int idProvider);
    }

    public class RepositoryProvider : IRepositoryProvider
    {
        private readonly ApplicationDbContext _context;


        public RepositoryProvider(ApplicationDbContext context)
        {
            _context = context;
        }

        #region GET 

        public async Task<Provider> Get(int idProvider)
        {
            return await _context.Providers
                       .Where(x => x.Id == idProvider)
                       .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Provider>> GetAllByUser(int idUser)
        {
            return await _context.Providers
                       .Where(x => x.User.Id == idUser)
                       .ToListAsync();
        }

        #endregion GET

        #region POST 

        public async Task<int> Save(Provider rq)
        {
            if (rq.Id > 0)
            {
                _context.Update(rq);
                await _context.SaveChangesAsync();
            }
            else
            {
                await _context.Providers.AddAsync(rq);
                await _context.SaveChangesAsync();
            }

            return rq.Id;
        }

        #endregion POST 

        #region PUT 

        public async Task<bool> Delete(int idProvider)
        {
            var provider = await _context.Providers.SingleAsync(x => x.Id == idProvider);

            provider.IsDelete = true;

            _context.Update(provider);
            await _context.SaveChangesAsync();

            return true;
        }

        #endregion PUT 
    }
}
