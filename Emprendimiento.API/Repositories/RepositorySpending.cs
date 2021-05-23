using Domain.Layer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emprendimiento.API.Repositories
{
    public interface IRepositorySpending
    {
        Task<IEnumerable<SpendingType>> GetAllTypes();
        Task<IEnumerable<Spending>> GetAllByUser(int idUser);
        Task<IEnumerable<Spending>> GetAllByCompany(int? idCompany, int start, int length);
        Task<int> Save(Spending spending);
    }

    public class RepositorySpending : IRepositorySpending
    {
        private readonly ApplicationDbContext _context;

        public RepositorySpending(ApplicationDbContext context)
        {
            _context = context;
        }

        #region GET

        public async Task<IEnumerable<SpendingType>> GetAllTypes()
        {
            return await _context.SpendingTypes.ToListAsync();
        }

        public async Task<IEnumerable<Spending>> GetAllByUser(int idUser)
        {
            return await _context.Spendings.Include(s => s.Company)
                    .Where(x => x.Company.IdUser == idUser)
                    .OrderBy(x => x.Date).ToListAsync();
        }

        public async Task<IEnumerable<Spending>> GetAllByCompany(int? idCompany, int start, int length)
        {
            var query = _context.Spendings
                .Include(s => s.SpendingType)
                .Include(s => s.Company).AsQueryable();

            if (idCompany.HasValue)
            {
                query = query.Where(x => x.Company.Id == idCompany);
            }

            return await query
                    .OrderBy(x => x.Date)
                    .Skip(start)
                    .Take(length).ToListAsync();
        }

        #endregion GET

        #region POST

        public async Task<int> Save(Spending spending)
        {
            _context.Add(spending);
            await _context.SaveChangesAsync();

            return spending.Id;
        }

        #endregion POST
    }
}
