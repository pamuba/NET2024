using MiddlewareDemo.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyMiddlewareClass>();
var app = builder.Build();



//app.UseMiddleware<MyMiddlewareClass>();
app.Use();
app.UseSecondMiddleware();


//non-blocking request
//lambda -> RequestDelegate
app.Use(async (HttpContext context, RequestDelegate next) => {
    await context.Response.WriteAsync("Hello from Middlware 1\n");
    await next(context);
    //after logic
});


//app.Use(async (HttpContext context, RequestDelegate next) => {
//    await context.Response.WriteAsync("Hello from Middlware 2\n");
//    await next(context);
//    //after logic
//});

app.UseWhen(
    context => context.Request.Query.ContainsKey("username"),
    app => {
        app.Use(async (context, next) =>
        {
            await context.Response.WriteAsync("Hello from Use When\n");
            await next(context);
        });
        app.Use(async (context, next) =>
        {
            await context.Response.WriteAsync("Hello from Use When Second Time\n");
            await next(context);
        });
    }
 );


app.Run(async (HttpContext context) => {
    await context.Response.WriteAsync("Hello from Middlware 3\n");
});

app.Run();
