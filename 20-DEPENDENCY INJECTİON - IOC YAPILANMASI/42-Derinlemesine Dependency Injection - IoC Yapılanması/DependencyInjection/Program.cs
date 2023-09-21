using DependencyInjection.Services;
using DependencyInjection.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

//Bir servis oluştururken bunu sisteme dahil edereken nerede konfigüre edeceğim? Startup'ta ya da Program.cs'te değil mi? ConfigureServices diye bir fonksiyonum var haliyle burada sisteme yani mimariye dahil edeceğim bu uygulamada çalışacak olan bütün servisleri buradaki builder.Services üzerinden mimariye uygulamaya dahil etmiyor muyum? ediyorum. 
// IServiceCollection türü bizim container'ımızın ta kendisi.
// builder.Services'e vereceğin tüm değerler ilgili mimaride oluşturulacak container'a dahil ediliyor. Uygulamayı çalıştırdığında bu container'da ayağa kaldırılıyor. Herhangi bir controller üzerinde servise vs. ihtiyacın olduğu taktirde gelip new falan demeden ilgili nesneyi talep edebiliyorsun.

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.Add(new(typeof(ConsoleLog), new ConsoleLog()));// Bu nesne üzerinden ben bütün davranışlara göre ilgili nesnelerimi container'a verebiliyorum.
////builder.Services.Add(new(typeof(TextLog), typeof(TextLog), ServiceLifetime.Transient));
//builder.Services.Add(new(typeof(TextLog), new TextLog()));//Davranış default olarak singleton'dır.
// Biz Add() fonksiyonunu çok fazla kullanmayız. Çok efektif değil çünkü.
//builder.Services.AddSingleton<ConsoleLog>();//Bütün isteklerde bütün taleplerde aynı nesneyi/tek bir tane nesneyi kullanıp onu gönderiyor. Bu şekilde kullanıyorsan eğer vermiş olduğun tür ne olursa olsun ondan bir tane nesne oluşturur. Yok eğer vermiş olduğun tür nesne oluşturulabilir bir sınıftır belki ama constructor'ı default değildir yani parametre alan bir constructor'ı vardır. O zaman direkt kendisi nesne oluşturamayacak kendisi burada new T();'yi baz alır normalde sen ne verdiysen o T'den bir nesne oluşturmaya çalışacak. Haliyle parametre alan bir constructor'ı varsa bunu kullanamazsın çünkü runtime'da patlayacaksın.
//Constructor'ın parametre alıyorsa bu davranışı sergileyemezsin. Hata alacaksın mantıken. Yok eğer parametre almıyorsa bununla direkt koyabilirsin.
//builder.Services.AddSingleton<ConsoleLog>(p => new ConsoleLog(3)); //Constructor'da parametre varsa bunu kullanırız.

//builder.Services.AddScoped<ConsoleLog>();//Tüm isteklerde ayrı bir tane bu nesneden oluşturacak her bir isteğin talebine o nesneden gönderecek.
//builder.Services.AddScoped<ConsoleLog>(p=> new(5));

//builder.Services.AddTransient<ConsoleLog>();// Her isteğin her talebine talebe özel nesne üretip üretip nesneyi gönderecektir.
//builder.Services.AddTransient<ConsoleLog>(p => new(5));

builder.Services.AddScoped<ILog>(p => new ConsoleLog(5));// ILog isteği geldiği zaman sen ConsoleLog ekle. Biz talep ederken bu nesneyi container'dan ILog türünden talep edeceğiz. Dolayısıyla ilgili nesne bize ILog türünden gelecektir. Burada polimorfizm kuralları geçerli olacaktır. Yani bildiğimiz klasik OOP kuralları geçerli olacaktır.
// Gün geldi ConsoleLog yerine TextLog lazım olursa ilgili yere TextLog yazmanız yeterli olacaktır.
builder.Services.AddScoped<ILog>(p => new TextLog());
// Bağımlılık tersine dönmüş yani ben hangisini çağırırsam ona göre o gelecek o işlem yapacak. Yani benim buraya TextLog yazmam sistemde bütün log mekanizmasının Text'te loglama yapmasının talimatını verdiğim anlamına gelecektir.
builder.Services.AddScoped<ILog, TextLog>();
// ILog türünden container'a bir TextLog nesnesi koy.
// Parametrenin ILog'tan türemiş olması gerekiyor
// Parametrenin nesne üretilebilir constructor'ı default/boş/parametresiz olan bir nesne olması gerekiyor.

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
