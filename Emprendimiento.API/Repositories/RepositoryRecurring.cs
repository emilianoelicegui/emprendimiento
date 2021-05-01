using Domain.Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emprendimiento.API.Repositories
{
    public interface IRepositoryRecurring
    {
        Task UpdateDolarBlueValue(DolarBlueValue dolarBlueValue);
    }

    public class RepositoryRecurring : IRepositoryRecurring
    {
        private readonly ApplicationDbContext _context;

        public RepositoryRecurring(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task UpdateDolarBlueValue(DolarBlueValue dolarBlueValue)
        {
            _context.Add(dolarBlueValue);
            await _context.SaveChangesAsync();
        }
    }
}
