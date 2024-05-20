using Microsoft.AspNetCore.Mvc;
using ControllersDemo.Models;
namespace ControllersDemo.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        [Route("hello")]
        [Route("/")]
        public ContentResult Index()
        {

            return Content("<h1>From the Index in Home Controller</h1>", "text/html");
            

            //return  new ContentResult()
            //{
            //    Content = "From the Index in Home Controller",
            //    ContentType = "text/plain"
            //};
        }
        [Route("about")]
        public string About()
        {
            return "From the About in Home Controller";
        }
        [Route("contact-us/{mobile:regex(^\\d{{10}}$)}")]
        public string Contact()
        {
            return "From the Contact in Home Controller";
        }

        //TO DO return JSON Data
        //https://jsonplaceholder.typicode.com/posts
        //HttpClient
        [Route("person")]
        public JsonResult Person() {
            Person person = new Person() { 
                Id = Guid.NewGuid(), FirstName="John", LastName="Smith", Age=33
            };

            return new JsonResult(person);
            //return "{\"key\":\"value\"}";
        }
        [Route("file-download")]
        public FileContentResult FileDownlaod() {
            //return new PhysicalFileResult("C:\\Users\\Partha.bora\\Desktop\\fabric.pdf", "application/pdf");
            //return PhysicalFile("C:\\Users\\Partha.bora\\Desktop\\fabric.pdf", "application/pdf");

            byte[] bytes = System.IO.File.ReadAllBytes("C:\\Users\\Partha.bora\\Desktop\\fabric.pdf");
            //return new FileContentResult(bytes, "application/pdf");
            return File(bytes, "application/pdf");
        }
    }
}

//it represents string (text data)
//Controller controls the transcation scope and  and manages the session related information for the request

//302 status Code
//   /bookstore
//    /store/books


//1. Reading Requests
//2. Validations
//3. Invokes the Models
//4. Preparing Responses

//ContentResult can represent any type of response that depends on the MIME type
// Content-Type + Content
//FileResult - VirutalFileResult, PhysicalFileResult, FileContentResult