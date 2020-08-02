using Domain.Dto.Layer;
using Domain.Layer;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories.Layer
{
    public interface IRepositoryCompany
    {
        Task<Company> Get(int idCompany);
        Task<IEnumerable<Company>> GetAllByUser(int idUser);
    }

    public class RepositoryCompany : IRepositoryCompany
    {
        private readonly ApplicationDbContext _context;


        public RepositoryCompany(ApplicationDbContext context)
        {
            _context = context;
        }

        #region GET

        public async Task<Company> Get(int idCompany)
        {
            return await _context.Companies
                       .Where(x => x.Id == idCompany)
                       .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Company>> GetAllByUser(int idUser)
        {
            return await _context.Companies
                       .Where(x => x.IdUser == idUser)
                       .OrderBy(x => x.NameFantasy)
                       .ToListAsync();
        }

        #endregion GET

    }
}
