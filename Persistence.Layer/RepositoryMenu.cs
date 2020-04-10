using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Domain.Dto.Layer;
using Domain.Layer;

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
            return _context.Menus
                    .Include(x => x.Rol)
                    .AsQueryable();
        }

    }
}
