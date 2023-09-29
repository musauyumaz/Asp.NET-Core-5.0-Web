using ConfigurationExample.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Konfigürasyon Verilerini Options Pattern İle Okuma
builder.Services.Configure<MailInfo>(builder.Configuration.GetSection("MailInfo"));// Bu fonksiyonda GeSection ile gerekli değeri veriyoruz. appsettings'teki hangi nesneyi hedef göstereceksen hangi bölümü yani ayarı/konfigürasyonu hedef göstereceksen onun ismini bildiriyorsun. Altındakileri Zaten bildirmiş olduğun generic türe dönüşüm yapılıp IoC container'ına ilgili nesne verilmiş olacaktır.
                                                                                   //Birden fazla konfigürasyonel değeri program.cs üzerinden bu şekilde farklı türlerdeki class'lara yapılandırıp istediğimiz zaman lazım olanı çağırabilirsiniz. 
#endregion

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
