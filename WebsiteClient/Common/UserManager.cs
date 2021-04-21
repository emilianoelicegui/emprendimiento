using Domain.Dto.Layer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Shared.Layer;
using System.Threading.Tasks;


namespace WebsiteClient.Common
{
    public static class UserManager
    {
        public static async Task<UserDto> RefreshLoginAsync(this HttpContext _httpContext, UserDto user)
        {
            var userContext = await GetUserContext(_httpContext);

            if(user.Company != userContext.Company)
            {
                //actualizo la company en el modelo actual (session)
                userContext.Company = user.Company;
            }

            return userContext;
        }

        public static async Task<UserDto> GetUserContext(this HttpContext _httpContext)
        {
            
            return new UserDto()
            {
                Id =        _httpContext.User.FindFirst("Id").Value.ToInt(),
                Name =      _httpContext.User.FindFirst("Name").Value,
                Surname =   _httpContext.User.FindFirst("Surname").Value,
                Email =     _httpContext.User.FindFirst("Email").Value,
                Token =     _httpContext.User.FindFirst("Token").Value,

                Rol =       new RolDto
                            {
                                Id = _httpContext.User.FindFirst("IdRol").Value.ToInt(),
                                Name = _httpContext.User.FindFirst("Rol").Value
                            },

                Company =   new CompanyLoginDto
                            {
                                Id = 2,
                                NameFantasy = "Eh lo q hay"
                            }
            };
        }
    }
}
