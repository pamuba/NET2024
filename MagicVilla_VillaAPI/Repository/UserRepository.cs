﻿using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MagicVilla_VillaAPI.Repository
{
	public class UserRepository : IUserRepository
	{
		public ApplicationDbContext _db { get; }
		private string secretKey;
		public UserRepository(ApplicationDbContext db, IConfiguration configuration)
        {
			_db = db;
			secretKey = configuration.GetValue<string>("ApiSettings:Secret");
		}

		public bool IsUniqueUser(string username)
		{
			var user = _db.LocalUsers.FirstOrDefault(x => x.UserName == username);
			if (user == null)
			{
				return true;
			}
			return false;
		}

		public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
		{
			var user = _db.LocalUsers.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDTO.UserName.ToLower()
			&& u.Password == loginRequestDTO.Password);

			if (user == null)
				return null;

			//if the user is found then generate the token
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(secretKey);

			var tokenDiscriptor = new SecurityTokenDescriptor {
				Subject = new ClaimsIdentity(new Claim[] { 
					new Claim(ClaimTypes.Name,user.Id.ToString()),
					new Claim(ClaimTypes.Role,user.Role)
				}),
				Expires = DateTime.UtcNow.AddDays(7),
				SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(tokenDiscriptor);
			LoginResponseDTO loginResponseDTO = new LoginResponseDTO() { 
				Token = tokenHandler.WriteToken(token),
				User = user
			};
			return loginResponseDTO;
		}
		//Is this the same library jwt.io ? or .net's own implementation?

		public async Task<LocalUser> Register(RegistrationRequestDTO registrationRequestDTO)
		{
			LocalUser user = new() { 
				UserName = registrationRequestDTO.UserName,	
				Password = registrationRequestDTO.Password,
				Name = registrationRequestDTO.Name,
				Role = registrationRequestDTO.Role
			};
			await _db.LocalUsers.AddAsync(user);
			await _db.SaveChangesAsync();
			user.Password = "";
			return user;
		}
	}
}
