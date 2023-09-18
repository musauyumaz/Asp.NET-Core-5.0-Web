using CustomRouteHandler.Handlers;

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
    //endpoints.Map("example-route", async c =>
    //{
    //    //https://localhost:5001/example-route endpoint'e gelen herhangi bir istek Controller'dan ziyade direkt olarak buradaki fonksiyon tarafından karşılanacaktır.
    //    // Bu rotaya bir istek gönderdiğimizde ki bu istek Get olabilir Post olabilir Put olabilir herşey olabilir. Yani bu isteklerin hepsini burada sağlayabiliyorsunuz o da var. Bu istekler neticesinde istek metotların herhangi birisiyle buradaki fonksiyonu tetikleyip işlemi gerçekleştirebiliyorsun. Ne olmuş oluyor controller tetiklenmemiş oluyor ne olmuş oluyor herhangi bir controller initialize etmediğimizden dolayı ekstradan bir maliyeti de ortadan kaldırmış oluyoruz. Tabi buradaki operasyonu farklı bir sınıfa koyarsak o sınıftan initalize operasyonu sağlayacağız o da ekstradan maliyet geri dönmüş olacak ama en azından yapacağın operasyonda artık controller action controller'ın ekstradan oradan view getiriyor yok başka bir nimetleri var onları getiriyor ya bunların hiçbirini ben kullanmıyorum kardeşim ben sadece buraya gelen istek neticesinde bir operasyon yapacağım bırak sadeleştir. Sadece o operasyona odaklanmak istiyorum diyorsan işte bu şekilde çalışabilirsin.
    //});

    endpoints.Map("image/{imagename}", new ImageHandler().Handler(app.Environment.WebRootPath));

    endpoints.Map("example-route",new ExampleHandler().Handler());

    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
