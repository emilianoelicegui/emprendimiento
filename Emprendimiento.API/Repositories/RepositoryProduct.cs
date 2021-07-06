using Domain.Layer;
using Microsoft.EntityFrameworkCore;
using Shared.Layer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emprendimiento.API.Repositories
{
    public interface IRepositoryProduct
    {
        Task<Product> Get(int idProduct);
        Task<IEnumerable<Product>> GetAllByUser(int idUser);
        Task<int> Save(Product rq);
        Task<int> GetTotalByCompany(string name, int idUser, int idCompany);
        Task<IEnumerable<Product>> GetAllByCompany(string nombre, int idUser, int? idCompany, int start, int length);
        Task<bool> Delete(int idProduct);
    }

    public class RepositoryProduct : IRepositoryProduct
    {
        private readonly ApplicationDbContext _context;


        public RepositoryProduct(ApplicationDbContext context)
        {
            _context = context;
        }

        #region GET 

        public async Task<Product> Get(int idProduct)
        {
            return await _context.Products
                       .Where(x => x.Id == idProduct)
                       .FirstAsync();
        }

        public async Task<IEnumerable<Product>> GetAllByUser(int idUser)
        {
            return await _context.Products
                       .Where(x => x.Company.User.Id == idUser)
                       .ToListAsync();
        }

        #endregion GET

        #region POST 

        public async Task<int> GetTotalByCompany(string name, int idUser, int idCompany)
        {
            var query = _context.Products
                                .Where(x => x.Company.User.Id == idUser && x.IsDelete == false && x.IdCompany == idCompany)
                                .Include(x => x.Company)
                                .AsQueryable();

            if (!name.IsNullOrEmpty())
            {
                query = query.Where(x => x.Name.Contains(name));
            }

            return await query.CountAsync();
        }

        public async Task<IEnumerable<Product>> GetAllByCompany(string name, int idUser, int? idCompany, int start, int length)
        {
            var query = _context.Products
                                .Where(x => x.Company.User.Id == idUser && x.IsDelete == false)
                                .Include(x => x.Company)
                                .AsQueryable();

            if (!name.IsNullOrEmpty())
            {
                query = query.Where(x => x.Name.Contains(name));
            }

            if (idCompany.HasValue)
            {
                query = query.Where(x => x.Company.Id == idCompany);
            }

            return await query
                    .OrderBy(x => x.Name)
                    .Skip(start)
                    .Take(length).ToListAsync();
        }
        public async Task<int> Save(Product rq)
        {
            if (rq.Id > 0)
            {
                _context.Update(rq);
                await _context.SaveChangesAsync();
            }
            else
            {
                await _context.Products.AddAsync(rq);
                await _context.SaveChangesAsync();
            }

            return rq.Id;
        }

        #endregion POST 

        #region PUT 

        public async Task<bool> Delete(int idProduct)
        {
            var product = await _context.Products.SingleAsync(x => x.Id == idProduct);

            product.IsDelete = true;

            _context.Update(product);
            await _context.SaveChangesAsync();

            return true;
        }

        #endregion PUT 
    }
}
