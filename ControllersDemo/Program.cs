using ControllersDemo.Controllers;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddTransient<Home>();
builder.Services.AddControllers();

var app = builder.Build();
app.UseStaticFiles();
app.MapControllers();

//app.UseRouting();

//app.UseEndpoints(endpoints => {
//    endpoints.MapControllers();
//});

app.Run();
