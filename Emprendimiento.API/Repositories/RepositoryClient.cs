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
        Task<Client> GetClientDebtor(int idClient);
        Task<IEnumerable<Client>> GetAllByUser(int idUser);
        Task<int> GetTotalByCompany(string filter, int idCompany);
        Task<IEnumerable<Client>> GetAllByCompany(string filter, int idCompany, int start, int length);
        
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

        public async Task<Client> GetClientDebtor(int idClient)
        {
            return await _context.Clients.Where(x => x.Id == idClient)
                                 .Include(x => x.Sales)
                                 .Include(x => x.Payments)
                .FirstAsync();
        }

        public async Task<IEnumerable<Client>> GetAllByUser(int idUser)
        {
            return await _context.Clients.Include(c => c.Company)
                    .Where(x => x.Company.IdUser == idUser)
                    .OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<int> GetTotalByCompany(string filter, int idCompany)
        {
            var query = _context.Clients.Include(c => c.Company).AsQueryable();

            if (filter != null)
            {
                query = query.Where(x => x.IdCompany == idCompany &&
                       x.Name.Contains(filter) ||
                       x.Surname.Contains(filter) ||
                       x.Dni.ToString().Contains(filter) ||
                       x.Cuit.ToString().Contains(filter));
            }

            return await query.CountAsync();
        }

        public async Task<IEnumerable<Client>> GetAllByCompany(string filter, int idCompany, int start, int length)
        {
            var query = _context.Clients.Include(c => c.Company).AsQueryable();

            if (filter != null)
            {
                query = query.Where(x => x.IdCompany == idCompany &&
                       x.Name.Contains(filter) ||
                       x.Surname.Contains(filter) ||
                       x.Dni.ToString().Contains(filter) ||
                       x.Cuit.ToString().Contains(filter));
            }

            return await query
                    .OrderBy(x => x.Name)
                    .Skip(start)
                    .Take(length).ToListAsync();
        }

        #endregion GET

        #region POST

        public async Task<int> Save(Client client)
        {
            if (client.Id == null)
            {
                _context.Add(client);
            }
            else
            {
                _context.Update(client);
            }

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
