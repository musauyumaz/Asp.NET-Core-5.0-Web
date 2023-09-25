using Microsoft.AspNetCore.Builder;

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
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name:"yonetim",
        areaName: "yonetim_paneli",//Area attribute'unda yazılmış bu değere sahip olan controller'larda geçerli olacaktır.
        // bu area değerine sahip tüm controller'lar buradaki pattern tarafından pattern'daki rotayı benimseyeceklerdir.
        pattern:"admin/{controller=Home}/{action=Index}"
        );//yonetim_paneli area değerin sahip olan bütün controller'lar bu rotadan değer alabileceklerdir. Bu rota üzerinden istek alabileceklerdir.

    endpoints.MapAreaControllerRoute(
       name: "fatura",
       areaName: "fatura_paneli",
       pattern: "fatura/{controller=Home}/{action=Index}");

   //endpoints.MapControllerRoute(
   //        name: "areaDefault",
   //        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"// bu şekilde gelen bir rotada eğer ki en başta area geliyorsa hangi area'ysa onun altındaki controller'ı ve action'ı tetiklesin demiş oluyorum.
   //        // exists => elimizdeki area'larla eşleştirmeyi sağlaması için bu constraint'i uygularız.
   //        //Bu rotada hangi area bildirilmişse o tetiklenmiş olacaktır.
   //        );

   endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
