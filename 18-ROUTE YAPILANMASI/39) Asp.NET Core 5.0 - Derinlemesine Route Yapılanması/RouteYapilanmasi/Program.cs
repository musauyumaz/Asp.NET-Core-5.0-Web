using Microsoft.Extensions.DependencyInjection;
using RouteYapilanmasi.Constraints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.Configure<RouteOptions>(options =>
{
    options.ConstraintMap.Add("custom", typeof(CustomConstraint));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints => //Buradaki sıralama önemlidir. Özelden --> Genele
{
    //endpoints.MapControllerRoute("Default3", "{controller=Home}/{action=Index}/{id:custom}/{x:alpha:length(12)?}/{y:int?}");
    //endpoints.MapControllerRoute("Default2", "anasayfa", new { controller = "Home", action = "Index" });
    //endpoints.MapControllerRoute("Default", "{controller=Personel}/{action=Index}");
    //endpoints.MapControllerRoute("Default","{controller=Personel}/musa/{action=Index}");
    //endpoints.MapControllerRoute("Default","{action}/ahmet/{controller}");
    //endpoints.MapControllerRoute("Default","{action}/{controller}");
    //endpoints.MapDefaultControllerRoute();
    endpoints.MapControllers();
});

app.Run();
