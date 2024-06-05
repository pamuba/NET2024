using MagicVilla_VillaAPI.Models.Dto;

namespace MagicVilla_VillaAPI.Data
{
    public class VillaStore
    {
        public static List<VillaDTO> villaList = new List<VillaDTO> { 
                new VillaDTO { Id = 1,Name="Sunny Villa", Occupancy=4, Sqft= 100},
                new VillaDTO { Id = 2,Name="Godrej Villa", Occupancy=3, Sqft= 100}
            };
    }
}
