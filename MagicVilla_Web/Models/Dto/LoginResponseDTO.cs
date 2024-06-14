namespace MagicVilla_Web.Models.Dto
{
	public class LoginResponseDTO
	{
		//will contain all info of the user
		public UserDTO User { get; set; }
        //token to authenticate the user or the identity
        public string Token { get; set; }
    }
}
