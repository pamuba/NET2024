using Microsoft.AspNetCore.Mvc;
using ViewComponentDemo.Models;

namespace ViewComponentDemo.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("about")]
        public IActionResult About()
        {
            return View();
        }
        [Route("person-list")]
        public IActionResult LoadPersonsList() {
            PersonGridModel personGridModel = new PersonGridModel()
            {
                GridTitle = "Persons List",
                Persons = new List<Person> {
                    new Person(){ PersonName="Jill" , JobTitle="Manager"},
                    new Person(){ PersonName="Jack" , JobTitle="Salse"},
                    new Person(){ PersonName="Mill" , JobTitle="QA"}
                }
            };
            //return new ViewComponentResult();
            return  ViewComponent("Grid",new { x=1,y=2, grid = personGridModel });
        }
    }
}
