using Domain.Layer;
using Persistence.Layer;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Repositories.Layer
{
    public interface IRepositoryMenu
    {
        IEnumerable<Menu> GetMenues();
    }

    public class RepositoryMenu : IRepositoryMenu
    {
        private readonly ApplicationDbContext _context;


        public RepositoryMenu(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Menu> GetMenues()
        {
            return _context.Menues
                    .Include(x => x.Rol)
                    .AsQueryable();
        }

    }
}
