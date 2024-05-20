using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelValidationDemo.Models;

namespace ModelValidationDemo.Controllers
{
    public class HomeController : Controller
    {
        //yeild + extension 
        [Route("register")]
        public IActionResult Index(Person person)
        {
            if (!ModelState.IsValid) {

                //List<string> errorsList = new List<string>();
                //foreach (var props in ModelState.Values) {
                //    foreach (var error in props.Errors) {
                //        errorsList.Add(error.ErrorMessage);
                //    }
                //}


                string errorsList = string.Join("\n", ModelState.Values.SelectMany(props =>
                props.Errors).Select(error =>
                error.ErrorMessage));
                return BadRequest(errorsList);
            }
            return Content($"{person}");
        }
    }
}

//Required
//StringLenght
//Range
