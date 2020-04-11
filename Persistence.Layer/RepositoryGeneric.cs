using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Domain.Dto.Layer;
using Domain.Layer;
using System.Threading.Tasks;

namespace Repositories.Layer
{
    public interface IRepositoryGeneric
    {
        Task<Menu> GetMenu();
        Task<IEnumerable<Menu>> GetMenus(int idRol);
        Task<Rol> GetRol(int idRol);
        IEnumerable<Rol> GetRoles();
    }

    public class RepositoryGeneric : IRepositoryGeneric
    {
        private readonly ApplicationDbContext _context;


        public RepositoryGeneric(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Menu> GetMenu()
        {
            return await _context.Menus.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Menu>> GetMenus(int idRol)
        {

            var list = await _context.Menus
                         .Where(x => !x.IsDelete && x.IdRol == idRol)
                         .Include(x => x.Rol)
                         .ToListAsync();

            return list;
        }

        public async Task<Rol> GetRol(int idRol)
        {
            return await _context.Roles
                        .Where(x => x.Id == idRol)
                        .Include(x => x.Menus)
                        .FirstOrDefaultAsync();
        }

        public IEnumerable<Rol> GetRoles()
        {
            var result = _context.Roles
                .OrderByDescending(c => c.Id);

            return result;
            //return await _context.Roles
            //             //.Where(x => !x.IsDelete)
            //             //.Include(x => x.Menus)
            //             .ToListAsync();
        }

    }
}
