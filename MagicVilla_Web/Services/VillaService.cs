using MagicVilla_Web.Models;
using MagicVilla_Web.Models.Dto;
using MagicVilla_Web.Services.IServices;
using static MagicVilla_Utility.SD;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MagicVilla_Web.Services
{
    public class VillaService : BaseService, IVillaService
    {
        public IHttpClientFactory _clientFactory { get; }
        private string villaUrl;
        public VillaService(IHttpClientFactory clientFactory, IConfiguration configuration):base(clientFactory)
        {
            _clientFactory = clientFactory;
            villaUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");
        }
        public Task<T> CreateAsync<T>(VillaCreateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = ApiTypes.POST,
                Data = dto,
                Url = villaUrl + "/api/VillaAPI"
            }); 
        }

        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = ApiTypes.DELETE,
                Url = villaUrl + "/api/VillaAPI/" + id
            }); 
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = ApiTypes.GET,
                Url = villaUrl + "/api/VillaAPI"
            });
        }

        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = ApiTypes.GET,
                Url = villaUrl + "/api/VillaAPI/" + id
            }); 
        }

        public Task<T> UpdateAsync<T>(VillaUpdateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = ApiTypes.PUT,
                Data = dto,
                Url = villaUrl + "/api/VillaAPI/" + dto.Id
            }); ;
        }
    }
}
