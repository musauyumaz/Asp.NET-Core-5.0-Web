using MiddlewareExample.Extensions;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

#region Run
//app.Run(async context =>
//{
//    await Console.Out.WriteLineAsync("Run Middleware");
//});
#endregion
#region Use
//app.Use(async (context, next) =>
//{
//await Console.Out.WriteLineAsync("Start Use Middleware");
//await next.Invoke();
//await Console.Out.WriteLineAsync("Stop Use Middleware");
//});
//app.Run(async context =>
//{
//    await Console.Out.WriteLineAsync("Run Middleware");
//}); 
#endregion
#region Map
//app.Use(async (context, next) =>
//{
//    await Console.Out.WriteLineAsync("Start Use Middleware 1");
//    await next.Invoke();
//    await Console.Out.WriteLineAsync("Stop Use Middleware 1");
//});
//app.Map("/weatherforecast", builder =>
//{
//    builder.Run(async c => c.Response.WriteAsync("Run middleware'i tetiklendi"));
//});
//app.Map("/home", builder =>
//{
//    builder.Use(async(context, task) =>
//    {
//        await Console.Out.WriteLineAsync("Start Use Middleware 1");
//        await task.Invoke();
//        await Console.Out.WriteLineAsync("Stop Use Middleware 1");
//    });
//});

//app.Run(async context =>
//{
//    await Console.Out.WriteLineAsync("Run Middleware");
//});
#endregion
#region MapWhen
//app.MapWhen(c => c.Request.Method == "GET", builder =>
//{
//    builder.Use(async (context, task) =>
//    {
//        await Console.Out.WriteLineAsync("Start Use Middleware 1");
//        await task.Invoke();
//        await Console.Out.WriteLineAsync("Stop Use Middleware 1");
//    });
//});
#endregion

app.UseStaticFiles();

app.UseRouting();

app.UseHello();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
