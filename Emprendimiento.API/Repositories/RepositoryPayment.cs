}using Domain.Layer;
using Microsoft.EntityFrameworkCore;
using Shared.Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emprendimiento.API.Repositories
{
    public interface IRepositoryPayment
    {
        Task<IEnumerable<Payment>> GetAllByCompany(string nombre, int idUser, int? idCompany, int start, int length);
    }

    public class RepositoryPayment : IRepositoryPayment
    {
        private readonly ApplicationDbContext _context;


        public RepositoryPayment(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Payment>> GetAllByCompany(string nombre, int idUser, int? idCompany, int start, int length)
        {
            var query = _context.Payments
                                .Where(x => x.Client.Company.IdUser == idUser)
                                .Include(x => x.Client)
                                .ThenInclude(x => x.Company)
                                .AsQueryable();

            if (!nombre.IsNullOrEmpty())
            {
                query = query.Where(x => x.Client.Name.Contains(nombre));
            }

            if (idCompany.HasValue)
            {
                query = query.Where(x => x.Client.Company.Id == idCompany);
            }

            return await query
                    .OrderBy(x => x.Client.Name)
                    .Skip(start)
                    .Take(length).ToListAsync();
        }
    }
}
