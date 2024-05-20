using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NETDEMO_RAZOR.Data;
using NETDEMO_RAZOR.Models;

namespace NETDEMO_RAZOR.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public List<Category> CategoryList { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
    
        public void OnGet()
        {
            CategoryList = _db.categories.ToList();
        }
    }
}
