using MagicVilla_VillaAPI.Models.Dto;

namespace MagicVilla_VillaAPI.Data
{
    public class VillaStore
    {
        public static List<VillaDTO> villaList = new List<VillaDTO> { 
                new VillaDTO { Id = 1,Name="Sunny Villa"},
                new VillaDTO { Id = 2,Name="Godrej Villa"}
            };
    }
}
