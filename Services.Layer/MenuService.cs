using Repositories.Layer;
using Services.Layer.Dto;
using System;

namespace Services.Layer
{
    public interface IMenuService
    {
        ServiceResponse GetMenues();
    }
    public class MenuService : IMenuService
    {
        private readonly IRepositoryMenu _repositoryMenu;

        public MenuService(IRepositoryMenu repositoryMenu)
        {
            _repositoryMenu = repositoryMenu;
        }

        public ServiceResponse GetMenues()
        {
            var sr = new ServiceResponse();

            try
            {
                sr.Data = _repositoryMenu.GetMenues();
            }
            catch (Exception ex)
            {
                sr.AddError(ex);
            }

            return sr;
        }
    }
}
