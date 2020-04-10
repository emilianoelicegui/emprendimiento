using Persistence.Layer;
using Services.Layer.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Layer
{
    public interface IMenuService
    {

    }
    public class MenuService : IMenuService
    {
        private readonly ApplicationDbContext _context;

        public MenuService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse> GetMenues()
        {
            var result = new ServiceResponse();

            try
            {

            }
            catch
            {

            }
        }
    }
}
