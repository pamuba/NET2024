﻿using static MagicVilla_Utility.SD;

namespace MagicVilla_Web.Models
{
    public class APIRequest
    {
        public ApiTypes ApiType { get; set; } = ApiTypes.GET;
        public  string Url { get; set; }
        public  object  Data { get; set; }
        public string Token { get; set; }
    }
}
