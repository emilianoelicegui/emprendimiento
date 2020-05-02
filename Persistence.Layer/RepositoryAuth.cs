using Domain.Dto.Layer;
using Domain.Layer;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories.Layer
{
    public interface IRepositoryAuth
    {
        Task<User> Authenticate(LoginRequestDto rq);
    }

    public class RepositoryAuth : IRepositoryAuth
    {
        private readonly ApplicationDbContext _context;

        public RepositoryAuth(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> Authenticate(LoginRequestDto rq)
        {
            return await _context.Users
                       .Where(x => x.Email == rq.Email && x.Password == rq.Password)
                       .Include(u => u.Rol)
                       .Include(r => r.Rol.Menus)
                       .FirstOrDefaultAsync();
        }

    }
}
