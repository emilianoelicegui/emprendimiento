using AutoMapper;
using Domain.Dto.Layer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repositories.Layer;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.Layer.Auth
{
    public interface IAuthService
    {
        Task<LoginResponseDto> Authenticate(LoginRequestDto rq);
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

        public async Task<LoginResponseDto> Authenticate(LoginRequestDto rq)
        {
            var sr = new ServiceResponse();
            var response = new LoginResponseDto();

            var secretKey = _configuration.GetValue<string>("SecretKey");
            var key = Encoding.ASCII.GetBytes(secretKey);

            try
            {
                var user = await _repositoryAuth.Authenticate(rq);

                if (user == null || user.IsDelete || user.IsLocked)
                {
                    sr.AddError("El usuario no existe o se encuentra bloqueado");

                    return response;
                }

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] {
                        new Claim("id", user.Id.ToString()),
                        new Claim("email", user.Email),
                        new Claim("idRol", user.Rol.Id.ToString())
                    }),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenCreated = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(tokenCreated);

                var result = new LoginResponseDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    Email = user.Email,
                    Rol = _mapper.Map<RolDto>(user.Rol),
                    Token = token
                };

                //sr.Data = response;
                response = result;

            }
            catch (Exception ex)
            {
                sr.AddError(ex);
            }

            return response;
        }
    }

    }
