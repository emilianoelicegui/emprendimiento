using AutoMapper;
using Domain.Dto.Layer;
using Domain.Layer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repositories.Layer;
using Shared.Layer;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.Layer.Auth
{
    public interface IAuthService
    {
        Task<ServiceResponse> Authenticate(LoginRequestDto rq);
    }

    public class AuthService : IAuthService
    {
        private readonly IRepositoryAuth _repositoryAuth;
        private readonly IRepositoryGeneric _repositoryGeneric;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthService(IRepositoryAuth repositoryAuth, IRepositoryGeneric repositoryGeneric, IConfiguration configuration, IMapper mapper)
        {
            _repositoryAuth = repositoryAuth;
            _repositoryGeneric = repositoryGeneric;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<ServiceResponse> Authenticate(LoginRequestDto rq)
        {
            var sr = new ServiceResponse();

            var secretKey = _configuration.GetValue<string>("SecretKey");
            var key = Encoding.ASCII.GetBytes(secretKey);

            try
            {
                var CompanyDto = new Company();
                var user = await _repositoryAuth.Authenticate(rq);

                if (user == null || user.IsDelete || user.IsLocked)
                {
                    sr.AddError("El usuario no existe o se encuentra bloqueado");

                    return sr;
                }

                if (user.Companys.IsNullOrEmpty())
                {
                    sr.AddError("El usuario no tiene sucursales activas");

                    return sr;
                }
                else
                {
                    CompanyDto = user.Companys.Where(x => x.IsPrincipal == true).FirstOrDefault() != null ?
                                 user.Companys.Where(x => x.IsPrincipal == true).First() :
                                 user.Companys.First();
                }

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] {
                        new Claim("id", user.Id.ToString()),
                        new Claim("email", user.Email.Trim()),
                        new Claim("idRol", user.Rol.Id.ToString()),
                        new Claim("idCompany", CompanyDto.Id.ToString())
                    }),
                    Expires = DateTime.Now.AddHours(6),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenCreated = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(tokenCreated);

                var response = new LoginResponseDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    Email = user.Email,
                    Rol = _mapper.Map<RolDto>(user.Rol),
                    Company = _mapper.Map<CompanyLoginDto>(CompanyDto),
                    Token = token
                };

                sr.Data = response;
            }
            catch (Exception ex)
            {
                sr.AddError(ex);
            }

            return sr;
        }
    }

    }
