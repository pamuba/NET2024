using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelValidationDemo.Models;

namespace ModelValidationDemo.CustomModelBinders
{
    public class PersonModelBinder : IModelBinder
    {
        //process XML Data
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            Person person = new Person();

            if (bindingContext.ValueProvider.GetValue("FirstName").Length > 0) {
                person.PersonName = bindingContext.ValueProvider.GetValue("FirstName").FirstValue;

            }
            if (bindingContext.ValueProvider.GetValue("LastName").Length > 0)
            {
                person.PersonName += " " + bindingContext.ValueProvider.GetValue("LastName").FirstValue;
            }
            if (bindingContext.ValueProvider.GetValue("Email").Length > 0)
            {
                person.Email = bindingContext.ValueProvider.GetValue("Email").FirstValue;
            }
            bindingContext.Result = ModelBindingResult.Success(person);
            return Task.CompletedTask;
        }

    }
}
