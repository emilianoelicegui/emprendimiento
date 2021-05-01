using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Domain.Dto.Layer;
using Domain.Layer;
using System.Threading.Tasks;

namespace Emprendimiento.API.Repositories
{
    public interface IRepositoryGeneric
    {
        Task<Menu> GetMenu();
        Task<IEnumerable<Menu>> GetMenus(int idRol);
        Task<Rol> GetRol(int idRol);
        Task<IEnumerable<Rol>> GetRoles();
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
            var menuRol = await _context.MenuRol
                        .Where(x => x.IdRol == idRol)
                        .Include(x => x.Menu)
                        .ToListAsync();

            var list = menuRol.Select(x => x.Menu).ToList(); 

            return list;
        }

        public async Task<Rol> GetRol(int idRol)
        {
            return await _context.Roles
                        .Where(x => x.Id == idRol)
                        .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Rol>> GetRoles()
        {
            return await _context.Roles
                .OrderByDescending(c => c.Id).ToListAsync();
        }

    }
}
