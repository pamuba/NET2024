using Microsoft.AspNetCore.Mvc;

namespace BindingDemo.Controllers
{
    public class StoreController : Controller
    {
        [Route("store/books/{id}")]
        public IActionResult Books(int? id)
        {

            //return File("/fabric.pdf", "application/pdf");
            return View();
        }
    }
}
