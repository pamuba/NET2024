using BindingDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace BindingDemo.Controllers
{
    public class HomeController : Controller
    {
        [Route("bookstore/{bookid?}/{isloggedin?}")]
        public IActionResult Index([FromQuery]int? bookid, [FromRoute] bool? isloggedin, Book book)
        {
            //bookid = fromroute
            //author = fromquery

            if (!Request.Query.ContainsKey("bookid")) {
                //Status Code Results
                //return new BadRequestResult();
                return BadRequest("Book id is not supplied");
                
                //Response.StatusCode = 400;
                //return Content("Book id is not supplied");
            }
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"]))) {
                return BadRequest("Book id cannot be null or empty");
                //Response.StatusCode = 400;
                //return Content("Book id cannot be null or empty");
            }

            //int bookid = Convert.ToInt32(ControllerContext.HttpContext.Request.Query["bookid"]);
            if (bookid <= 0) {
                return BadRequest("Book id cannot be less than or equal to zero");
                //Response.StatusCode = 400;
                //return Content("Book id cannot be less than or equal to zero");
            }
            if (bookid >1000)
            {
                return NotFound("Book id cannot be greater than 1000");
                //Response.StatusCode = 400;
                //return Content("Book id cannot be greater than 1000");
            }
            if (Convert.ToBoolean(Request.Query["isloggedin"]) == false) {
                //return Unauthorized("User must be authenticated");

                //return StatusCode(403,"Custom Error Msg");
                //Response.StatusCode = 401;
                //return Content("User must be authenticated");
            }
            //return new RedirectToActionResult("Books","Store", new { },true);
            //return RedirectToActionPermanent("Books", "Store", new { id = bookid });
            //return File("/fabric.pdf", "application/pdf");

            //return new LocalRedirectResult($"/store/books/{bookid}");
            //return LocalRedirect($"/store/books/{bookid}");

            //return new RedirectResult($"https://visualstudio.microsoft.com/msdn-platforms/");
            return Redirect($"https://visualstudio.microsoft.com/msdn-platforms/");

        }
    }
}

//NotFoundResult()
//StatusCodeResult()

//bookstore
//302 or 301
//store/books

//RedirectToActionResult
//LocalRedirectResult
//RedirectResult

//POST
//Form Fields
//Form-urlencooded
//from-data

//Request Body
//GET
//Route Data
//Query string parameters

// HTTP Request-> Routing -> Model Binding -> Action Fns
