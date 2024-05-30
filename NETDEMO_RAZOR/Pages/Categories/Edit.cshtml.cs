using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NETDEMO_RAZOR.Data;
using NETDEMO_RAZOR.Models;

namespace NETDEMO_RAZOR.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        //[BindProperty]
        public Category Category { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0 ) {
                Category = _db.categories.Find(id);
            }
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid) {
                _db.categories.Update(Category);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully.";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}