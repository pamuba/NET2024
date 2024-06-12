using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MagicVilla_VillaAPI.Controllers
{
	[Route("api/UserAuth")]
	[ApiController]
	public class UsersController : Controller
	{
		protected APIResponse _response;
		public IUserRepository _userRepository { get; }
		public UsersController(IUserRepository userRepository)
		{
			_userRepository = userRepository;
			this._response = new();
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
		{
			var loginResponse = _userRepository.Login(model);
			if (loginResponse.User == null || string.IsNullOrEmpty(loginResponse.Token)) {
				//return BadRequest(new { message = "Usernaem or Password is Wrong"});
				_response.StatusCode = HttpStatusCode.BadRequest;
				_response.IsSuccess = false;
				_response.ErrorMessages.Add("Usernaem or Password is Wrong");
				return BadRequest(_response);
			}
			_response.StatusCode = HttpStatusCode.OK;
			_response.IsSuccess = true;
			_response.Result = loginResponse;
			return Ok(_response);
		}
		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO model)
		{
			return View();
		}
	}
}
