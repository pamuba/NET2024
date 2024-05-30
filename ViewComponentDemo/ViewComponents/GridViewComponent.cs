using Microsoft.AspNetCore.Mvc;
using ViewComponentDemo.Models;

namespace ViewComponentDemo.ViewComponents
{
    [ViewComponent]
    public class GridViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int x, int y, PersonGridModel grid) {
            //PersonGridModel personGridModel = new PersonGridModel()
            //{
            //    GridTitle = "Persons List",
            //    Persons = new List<Person> { 
            //        new Person(){ PersonName="Jill" , JobTitle="Manager"},
            //        new Person(){ PersonName="Jack" , JobTitle="Salse"},
            //        new Person(){ PersonName="Mill" , JobTitle="QA"}
            //    }
            //};
            //ViewData["Grid"] = personGridModel;
            return View(grid); //invoke a pratial view Views/Shared/Grid/Default.cshtml
        }
    }
}
