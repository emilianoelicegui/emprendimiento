using Domain.Dto.Layer;
using Domain.Layer;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories.Layer
{
    public interface IRepositoryProduct
    {
        Task<Product> Get(int idProduct);
        Task<IEnumerable<Product>> GetAllByCompany(int idCompany);
        Task<IEnumerable<Product>> GetAllByUser(int idUser);
        Task<int> Save(Product rq);
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
                       .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetAllByCompany(int idCompany)
        {
            return await _context.Products
                       .Where(x => x.Company.Id == idCompany)
                       .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllByUser(int idUser)
        {
            return await _context.Products
                       .Where(x => x.Company.User.Id == idUser)
                       .ToListAsync();
        }

        #endregion GET

        #region POST 

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
