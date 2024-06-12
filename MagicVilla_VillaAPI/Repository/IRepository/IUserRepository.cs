using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;

namespace MagicVilla_VillaAPI.Repository.IRepository
{
	//registering the user to the DB
	public interface IUserRepository
	{
		bool IsUniqueUser(string username);
		Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
		Task<LocalUser> Register(RegistrationRequestDTO registrationRequestDTO);
	}
}
