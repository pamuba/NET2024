using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoWebApplication.Security;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoWebApplication.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly CustomIDataProtection protector;

        public PrivacyModel(CustomIDataProtection customIDataProtection)
        {
            protector = customIDataProtection;
        }
        public void OnGet(string id)
        {
            ViewData["BDId"] = protector.Encode(id);
        }
    }
}