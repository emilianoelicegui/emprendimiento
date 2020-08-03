using Domain.Dto.Layer;
using Domain.Layer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Emprendimiento.API.Repositories
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
            var user = await _context.Users
                       .Where(x => x.Email == rq.Email && x.Password == rq.Password)
                       .Include(u => u.Rol)
                       .Include(c => c.Companys)
                       .FirstOrDefaultAsync();

            if (user != null)
            {
                user.LastStart = DateTime.Now;
                await _context.SaveChangesAsync();
            }

            return user;
        }

    }
}
