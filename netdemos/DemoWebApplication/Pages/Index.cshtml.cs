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
    public class IndexModel : PageModel
    {
        private readonly CustomIDataProtection protector;

        public IndexModel(CustomIDataProtection customIDataProtection)
        {
            protector = customIDataProtection;
        }

        public void OnGet()
        {
            DomainModel dm = new DomainModel();
            dm.BankId = 2020202020;
            dm.DecodeId = protector.Decode(dm.BankId.ToString());
            ViewData["BankData"] = dm;
        }
    }
}
