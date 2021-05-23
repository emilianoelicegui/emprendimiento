using Domain.Layer;
using Microsoft.EntityFrameworkCore;
using Shared.Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emprendimiento.API.Repositories
{
    public interface IRepositorySale
    {
        Task<Sale> Get(int idSale);
        Task<IEnumerable<Sale>> GetAllByUser(int idUser);
        Task<IEnumerable<Sale>> GetAllByCompany(int idUser, int? idCompany, int start, int length);

        Task<int> Save(Sale rq);

        Task<bool> Delete(int idSale);
    }
    public class RepositorySale : IRepositorySale
    {
        private readonly ApplicationDbContext _context;

        public RepositorySale(ApplicationDbContext context)
        {
            _context = context;
        }

        #region GET 

        public async Task<Sale> Get(int idSale)
        {
            return await _context.Sales
                       .Where(x => x.Id == idSale)
                       .FirstAsync();
        }

        public async Task<IEnumerable<Sale>> GetAllByUser(int idUser)
        {
            return await _context.Sales
                       .Where(x => x.Company.User.Id == idUser)
                       .ToListAsync();
        }

        #endregion GET

        #region POST 

        public async Task<IEnumerable<Sale>> GetAllByCompany(int idUser, int? idCompany, int start, int length)
        {
            var query = _context.Sales
                                .Where(x => x.Company.User.Id == idUser)
                                .Include(x => x.Company)
                                .AsQueryable();

            if (idCompany.HasValue)
            {
                query = query.Where(x => x.Company.Id == idCompany);
            }

            return await query
                    .OrderBy(x => x.Date)
                    .Skip(start)
                    .Take(length).ToListAsync();
        }

        public async Task<int> Save(Sale rq)
        {
            if (rq.Id > 0)
            {
                _context.Update(rq);
                await _context.SaveChangesAsync();
            }
            else
            {
                await _context.Sales.AddAsync(rq);
                //await _context.ItemSales.AddRangeAsync(rq.ItemSales);
                await _context.SaveChangesAsync();
            }

            return rq.Id;
        }

        #endregion POST 

        #region PUT 

        public async Task<bool> Delete(int idSale)
        {
            var sale = await _context.Sales.SingleAsync(x => x.Id == idSale);

            //sale.IsDelete = true;

            _context.Update(sale);
            await _context.SaveChangesAsync();

            return true;
        }

        #endregion PUT 
    }
}
