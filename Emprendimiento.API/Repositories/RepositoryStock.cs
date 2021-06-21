using Domain.Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emprendimiento.API.Repositories
{
    public interface IRepositoryStock
    {
        Task<int> Save(Stock stock);
    }

    public class RepositoryStock : IRepositoryStock
    {
        private readonly ApplicationDbContext _context;

        public RepositoryStock(ApplicationDbContext context)
        {
            _context = context;
        }

        #region 

        public async Task<int> Save(Stock stock)
        {
            try
            {
                _context.Database.BeginTransaction();

                if (stock.Id > 0)
                {
                    _context.Stocks.Update(stock);
                }
                else
                {
                    _context.Stocks.Add(stock);
                }

                var product = _context.Products.Where(x => x.Id == stock.ProductId).First();

                product.StockUnits = product.StockUnits + stock.Units;
                _context.Products.Update(product);

                await _context.SaveChangesAsync();

                _context.Database.CommitTransaction();

                return stock.Id;
            }
            catch(Exception ex)
            {
                _context.Database.RollbackTransaction();
                throw new Exception(ex.Message);
            }

        }

        #endregion
    }
}
