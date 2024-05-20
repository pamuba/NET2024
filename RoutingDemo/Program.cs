using Microsoft.AspNetCore.Http;
using RoutingDemo;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRouting(options => {
    options.ConstraintMap.Add("months", typeof(MonthsCustomConstraint));
});
var app = builder.Build();

// req -> GetEndPoint() -> UseRouting() -> GetEndPoint()
//      null
//MS.AspNetCore.Http.EndPoint


app.Use(async (context, next) => {
    Microsoft.AspNetCore.Http.Endpoint endpoint = context.GetEndpoint();
    await next(context);
});

//Enables Routing
app.UseRouting();


app.Use(async (context, next) => {
    Microsoft.AspNetCore.Http.Endpoint endpoint = context.GetEndpoint();
    await next(context);
});

//create the endpoints
#pragma warning disable ASP0014 


app.UseEndpoints(endpoints => {
    endpoints.Map("files/{filename}.{extension}", async context =>
    {
        string filename = Convert.ToString(context.Request.RouteValues["filename"]);
        string extension = Convert.ToString(context.Request.RouteValues["extension"]);
        await context.Response.WriteAsync("In Files:  -> {filename} - {extension}");
    });
    endpoints.Map("employee/profile/{empname:minlength(3):maxlength(6)=bill}", async context =>
    {
        string? employeename = Convert.ToString(context.Request.RouteValues["empname"]);
        await context.Response.WriteAsync($"In Employee Profile :  -> {employeename}");
    });

    endpoints.Map("product/details/{id:range(10,199)?}", async context =>
    {
        int id = Convert.ToInt32(context.Request.RouteValues["id"]);
        if (context.Request.RouteValues.ContainsKey("id"))
        {
            await context.Response.WriteAsync($"In Product Profile :  -> {id}");
        }
        else {
            await context.Response.WriteAsync($"Provide the ID");
        }
    });

    endpoints.Map("daily-report/{reportdate:datetime?}", async context =>
    {
        DateTime datereport = Convert.ToDateTime(context.Request.RouteValues["reportdate"]);
        
        if (context.Request.RouteValues.ContainsKey("reportdate"))
        {
            await context.Response.WriteAsync($"In Daily Report : -> {datereport.ToShortDateString()}");
        }
        else
        {
            await context.Response.WriteAsync($"Provide the Date");
        }
    });
    endpoints.Map("profit-report/{year:int:min(2020)}/{month:months}", async context =>
    {
        int year = Convert.ToInt32(context.Request.RouteValues["year"]);
        string? month = Convert.ToString(context.Request.RouteValues["month"]);

        if (month == "jan" || month == "feb")
        {
            await context.Response.WriteAsync($"In Report Jan and FEB");
        }
        else
        {
            await context.Response.WriteAsync($"In Report MAR");
        }
    });
});

app.Run(async context => {
    
    await context.Response.WriteAsync($"NOT MATCHED -- Reques Received at: {context.Request.Path}");
});




#pragma warning restore ASP0014 
app.Run();


//RoutingDemo - Enables routing + selects an endpoint based on the url path and HTTp methods
//UseEndpoints - executes the appropriate endpoint based the endpoint selected by UseRouting
//RouteParams
//files/sample.txt
//employee/profile/john

