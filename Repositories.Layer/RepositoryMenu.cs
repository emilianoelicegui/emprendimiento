using Persistence.Layer;

namespace Repositories.Layer
{
    public interface IRepositoryMenu
    {
    }

    public class RepositoryMenu : IRepositoryMenu
    {
        private readonly ApplicationDbContext _context;


        public RepositoryMenu(ApplicationDbContext context)
        {
            _context = context;
        }
    }

    }
