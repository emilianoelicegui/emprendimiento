﻿using AutoMapper;
using Domain.Dto.Layer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repositories.Layer;
using System;
using System.IdentityModel.Tokens.Jwt;
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
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthService(IRepositoryAuth repositoryAuth, IConfiguration configuration, IMapper mapper)
        {
            _repositoryAuth = repositoryAuth;
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
                var user = await _repositoryAuth.Authenticate(rq);

                if (user == null || user.IsDelete || user.IsLocked)
                {
                    sr.AddError("El usuario no existe o se encuentra bloqueado");

                    return sr;
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

                var response = new LoginResponseDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    IdRol = user.IdRol,
                    Rol = _mapper.Map<RolDto>(user.Rol),
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
