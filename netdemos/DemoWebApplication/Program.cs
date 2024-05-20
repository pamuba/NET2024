using DemoWebApplication.Security;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<CustomIDataProtection>();
builder.Services.AddSingleton<UniqueCode>();

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints => {
    endpoints.Map("", async (context) => {
        await context.Response.WriteAsync("In the Root");
    });
    endpoints.MapPost("map1", async (context) => {
        await context.Response.WriteAsync("In Map 1");
    });
    endpoints.Map("map2", async (context) => {
        await context.Response.WriteAsync("In Map 2");
    });
    
});


app.Run(async (context) => {
    await context.Response.WriteAsync($"Rquest Received at: {context.Request.Path}");
});

app.Run();
