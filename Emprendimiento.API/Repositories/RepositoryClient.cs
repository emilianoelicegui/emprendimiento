using Domain.Layer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emprendimiento.API.Repositories
{
    public interface IRepositoryClient
    {
        Task<Client> Get(int idClient);
        Task<IEnumerable<Client>> GetAllByUser(int idUser);
        Task<IEnumerable<Client>> GetAllByCompany(int idCompany);
        
        Task<int> Save(Client spending);

        Task<bool> Delete(int idClient);
    }

    public class RepositoryClient : IRepositoryClient
    {
        private readonly ApplicationDbContext _context;

        public RepositoryClient(ApplicationDbContext context)
        {
            _context = context;
        }

        #region GET

        public async Task<Client> Get(int idClient)
        {
            return await _context.Clients.Where(x => x.Id == idClient)
                .FirstAsync();
        }

        public async Task<IEnumerable<Client>> GetAllByUser(int idUser)
        {
            return await _context.Clients.Include(c => c.Company)
                    .Where(x => x.Company.IdUser == idUser)
                    .OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<IEnumerable<Client>> GetAllByCompany(int idCompany)
        {
            return await _context.Clients.Where(x => x.IdCompany == idCompany)
                .OrderBy(x => x.Name).ToListAsync();
        }

        #endregion GET

        #region POST

        public async Task<int> Save(Client client)
        {
            _context.Add(client);
            await _context.SaveChangesAsync();

            return client.Id;
        }

        #endregion POST

        #region PUT

        public async Task<bool> Delete(int idClient)
        {
            var product = await _context.Clients.SingleAsync(x => x.Id == idClient);

            product.IsDelete = true;

            _context.Update(product);
            await _context.SaveChangesAsync();

            return true;
        }

        #endregion PUT

    }
}
