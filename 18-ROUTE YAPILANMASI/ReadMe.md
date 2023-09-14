---
modified: 2023-09-14T12:53:26.960Z
title: 39) Asp.NET Core 5.0 - Derinlemesine Route Yapılanması
---

# 39) Asp.NET Core 5.0 - Derinlemesine Route Yapılanması
- Route yapılanması rotalarımızı yani gelen isteklerde hangi controller'ı tetikleyeceğimizi belirlememizi sağlayan ayırt edebilmemizi sağlayan bir mekanizmadır.

- Route web uygulamalarında önemlidir. Çünkü gelen isteğin ne şekilde yapılacağını yani rotasını belirleyen yapılanmaya biz route/rota yapılanması diyoruz. Dolayısıyla client'tan bir istek gelecek bu isteğin nereye ne şekil geleceğini bu istekteki endpoint'in rotası belirleyecektir. Onun Route şablonu belirleyecektir.

- Route: Gelecek olan isteğin hangi rotaya gideceğini belirleyen şablonlardır.

<img src="1.png" width="auto">

- Hatta MVC'deki karşılığı gelen istekteki bu rota üzerinden biz hangi controller'ı ayağa kaldıracağımızı yani hangisini tetikleyeceğimizi ve ona göre işlem yapacağımızı belirliyoruz. Dolayısıyla rota isteği nereye yapacağını ne şekilde yapacağını bildiren şablon. Bu istek neticesinde hangi controller'ı ayağa kaldıracağını tabiki de bilebiliyorsun ama bunu senle ben mi yapıyoruz? Hayır Asp.Net Core MVC mimarisini kullanıyorsanız eğer `program.cs` dosyasındaki `UseRooting()` middleware'i bu işlemi gerçekleştirmektedir.

- `UseRooting()` middleware'i yapısal olarak tetiklendiği zaman gelen request'teki rotaları ayırmakta ve ilgili rotaya karşılık gelen controller hangisiyse onu ayağa kaldırmakta ve gerekli action'ı tetiklemektedir.

- Otomatik bir şekilde middleware'ler tetiklenir. Ekstradan bir işlem yapmaksızın buradaki middleware'ler zaten otomatik tetiklenir. Herhangi bir istek geldiğinde. Bu tetiklenme esnasında ilgili rota ayrıştırılıp hangi controller'ın ayağa kaldırılması gerekiyorsa o işlemi o sorumluluğu o isteğe karşı cevabı verecek controller initialize ettiriliyor ve ona göre geriye sonuç döndürülüyor. İşlemler yapıp sonuçlar döndürüyor. Tabi bu süreçte senin herhangi bir şey yapmana gerek yok. Tek yapman gereken bişey var süreçte önceden rotaları tarif etmen gerek.
 
- `UseEndpoints()` middleware'i ise kendi içerisinde rotaları tutan tarif etmemizi tanımlamamızı sağlayan bir yapılanma. İşte buradaki endpoint'te de rotalarımızı tanımlayacağız.

- Gelen rotayı ayrıştırma işlemini `UseRooting()` middleware'inde gerçekleştirirken rotaları tanımlama operasyonlarını da `UseEndpoints()` middleware'inde gerçekleştirirsin.

- `endpoints.MapDefaultControllerRoute()` bu MVC mimarisinde rotalardan default olanı/tanımlanmış/ön tanımlanmış olanı bizlere sunmaktadır ve diyor ki kardeşim benim sana default olarak sağlamış olduğum controller route'la gelen istekleri eşleştiririm ben diyor ve ona göre hangi controller'ı tetikleyeceksem buradan ayırt ederim diyor.

- `{controller=Home}/{action=Index}/{id?}` default olarak bize getirmiş olduğu rotadır. 

- Bir rota oluşturuyorsanız `{}`ler rotanın içinde parametrelere karşılık gelmektedir. İsmi controller ve action geçen varsa sistem tarafından ön tanımlı parametrelerdir. Yani burada controller'a karşılık gelenin sistem/mimari tarafından mimarinin controller'larına karşılık gelen değeri taşıdığı bilinmektedir. Aynı şekilde de action hangi controller'daysak onun altındaki herhangi bir action yani metoda karşılık geldiği sistem tarafından biliniyor. Ama bunların dışında herhangi bir parametre görürsen bil ki o custom bir parametredir. Örneğin id'de olduğu gibi.

- Mimari controller'a ve action'a verilen değerleri hangi controller ve hangi action olarak algılarken yani şunu bilecek sistemdeki controller'lara bakacak ve onun altındaki action'lara bakacak bunun dışındaki diğer parametreler ise ister default'ta olsun istersen sen kendin tanımlamış ol custom parametre olarak nitelendirilecektir. Yani `/{id?}` değerini okumak ayrıdır. Bunu sistem okumaz ön tanımlı değildir.

- `endpoints.MapDefaultControllerRoute()` şeması otomatik ön tanımlı bir rota getiriyor. Ondan bahsetmiyoruz parametre öntanımlarından bahsediyoruz.

-  Yapısal olarak `endpoints.MapDefaultControllerRoute()`'u kullanıyorsanız bu `{controller=Home}/{action=Index}/{id?}` bu formatta bir rota istiyor ve rotada hangi seviye controller hangi seviye action yazacağınızı bu formatta istiyor vermiş olduğunuz değerlere göre ilgili controller'ın altındaki action'ı tetikleyecektir. 

- `{controller=Home}` eğer ki controller boş gelirse varsayılan default olarak Home `{action=Index}` action'da boş gelirse varsayılan default olarak Index'i tetikleyecektir. 

- `{controller=Home}/{action=Index}/{id?}` bu rotaya `/` isteği gönderirsem `id` nullable olduğundan dolayı zaten göndermek zorunda değilim direkt Home altındaki Index tetiklenecektir. Benzer mantıkla `/Home` controller'ı gönderir action'ı göndermezsem Home altındaki Index yine tetiklenecektir. Benzer mantıkla `/Home/Index` direkt alenen belirtirsem belirttiğim adrese göre Home altında Index'i yine tetikleyecektir. 

- `/personel/getir` burada gidecek personel varsa controller onu ayağa kaldıracak ve getir isimli action'ı arayacak varsa invoke edecektir. Daha sonra gerekli response'u alıp ilgili kullanıcıya yönlendirecek.

- `/personel` controller var personel Home'u eziyor yani oradaki default'u eziyorsun amma velakin ikincisi olmadığından dolayı action varsayılan olarak Index'e karşılık gelecek haliyle görmesende yazmasanda burada personel controller'ının altındaki Index tetiklenecektir. 

<img src="2.png" width="auto">

- Diyelim ki ben bu rotayı özelleştirmek istiyorum örneğin controller en sonunda alınsın istiyorum mevcut parametrelerim başta alınsın istiyorum ya da farklı araya statik olacak değerle koyup URL'i ona göre şekillendirmek istiyorum böyle bir ihtiyacımız olursa default route'lar oluşturacağız.

- `endpoints.MapControllerRoute()` fonksiyonu default'un dışında customize edilmiş rotalar oluşturmanızı sağlayan bir fonksiyondur.

- Her bir controller route'un bir ismi olmalı ve unique olmalıdır.

- `endpoints.MapControllerRoute("Default","{action}/{controller}")` eğer ki sen bu route'u baz alıyorsan bundan sonraki gelecek olan istekler önce action daha sonra controller olacak şekilde gelmesi gerekir. Aksi taktirde hedef controller'ların altındaki action'ları tetikleyemezsiniz. Customize ettiğinizde sıralama hiza şekil aradaki statik değerler her şey sana bağlı.

- `endpoints.MapControllerRoute("Default","{action}/ahmet/{controller}");` => burada ise buna göndereceğin değerler kesinlikle bu şekilde olmalı=> `index/ahmet/home` action'ı bildireceksin ardından ahmet ardından controller Böyle bir link olur ama biz genellikle kullanmayız. Genel geçer kural önce controller ardından action'dı. Bu default olandı. Sen bunu özelleştirebilirsin. İstediğin gibi saçma da olsa url'ler oluşturabilirsin.

<img src="3.png" width="auto">

- Eğer ki biz bunlara default değer vermezsek boş geldikleri taktirde mimari hata verecektir. Yani controller'a sen boş bir değer gönderirsen herhangi bir değer göndermezsen hop kardeşim ben neyi çalıştıracağımı bilemeyeceğim diyecek haliyle hata verecek. Ama herhangi bir değer gönderirsen bu değerler sayesinde boş gelme durumunda bunlar direkt baz alınacağından dolayı hata verilmeyecektir.

- Özelleştirilmiş rotaları daha da özelleştirmek istiyorsanız `endpoints.MapControllerRoute("Default2", "anasayfa", new { controller = "Home", action = "Index" });` bu yöntemi kullanabilirsiniz. Burada bu metodun 3. parametresine anonim olarak verdiğimiz değerler bizi kurtaracaktır. anasayfa diye bir rota oluşturdum eğer buna bir istek geliyorsa controller'ı home olan action'ı da index olan adrese gitsin. Fiziksel bir kabuklama yapmış oluyorsun. Yani sen controller = "Home", action = "Index" i tetiklerken statik bir değerle tetiklemiş oluyorsun. Bu şekilde bir kullanımda ise url üzerinde parametre almıyorsun direkt statik bir url'e arkada yönlendirmeyi sağlamış oluyorsun. Genellikle tercih edilir mi edilmez mi bilmem ama ben tercih ediyorum web uygulamalarında belirli sayfalara yönlendirme yaparken onları statikmiş gibi gösterebilmek için bu yöntemi kullanıyorum.

- Eğer ki birden fazla endpoint oluşturacaksanız yani rota tasarlayacaksanız bu rotaları özelden genele olacak şekilde sıralayın. Çünkü ilk önce özeller kontrol edilsin ki en son genele gidebilsin yani genelin geçerli olduğu durum en sonuncu durum olsun. Onun için buradaki sıralama önemlidir.

- Tanımladığımız özel/custom rotaların her birinin ismi unique olması gerekiyor aynı anda aynı isimde birden fazla rota tanımlamamanız gerekmektedir.

- Custom ya da default farketmiyor herhangi bir rotanız mevcutsa Asp.Net Core MVc mimarisinde oluşturduğunuz url'lerin her biri uygun olan rota üzerinden oluşturulacaktır.

```C#
@Html.ActionLink("Anasayfa","Index","Home")

<a asp-action="Index" , asp-controller="Home">Anasayfa</a>

// Eğer ki bir link oluşturursanız oluşturulacak link uygun olan bir rota tarafından kabuklanacaktır. Yani ya kardeşim ben bu adreslere bir link oluşturacağım buna en uygun rota hangisidir diye bakacak ve ona göre buradaki adresi oluşturacaktır.
```
- Oluşturmak için talep ettiğimiz url yapılanmasında TagHelper olur ya da HtmlHelper üzerinden talep ettiğiniz url hedef controller ve action fiziksel olarak burada rotaya sahip olduğundan dolayı otomatik olarak o controller ve action'a yönlendirilecektir.

- Dolayısıyla sizin tanımlamış olduğunuz rotaların mimari tarafından url oluştururken ve bunun gibi ekstradan işlemler yaparken baz alındığını görmüş olduk. Çünkü bir yere yönlendirme yaparkende yönlendirilecek adresi oluşturmak için tek tek elinle manuel çalışma yapmana gerek yok. Anasayfaya mı yönlendireceksin sen yine Home Index'le ilgili bir url oluşturabilirsin zaten sistemin/mimarin yine anasayfayı çıktı olarak verecektir.

- Oluşturduğumuz rotalarda tabikide farklı değerler taşıyabilmek için parametreler oluşturabilmekteyiz. `{}`ler üzerinden taşınan değerler bizim için parametre olarak değerlendiriliyor. Parametreden kasıt değişken. Yani oluşturmuş olduğun linkin üzerinde `home/index/1` 1 değeri arka planda bir id'ye karşılık gelecek şekilde bir parametre olarak nitelendiriliyor. Benzer mantıkla biz istek yaparken default'ta controller isimleri ve action isimleri değişebiliyor. Çünkü statik değer değil orası bir controller ve action parametresi olduğu için farklı controller ve action isimlerini bildirebiliyoruz. 

- Her ne kadar custom bir parametre tanımlayacak olsakta esasında ön tanımlı parametrelerle birebir aynı şekilde custom parametre tanımlayabiliyorsunuz. Burada istediğiniz kadar parametre tanımlayabilirsiniz. `endpoints.MapControllerRoute("Default3","{controller=Home}/{action=Index}/{id?}/{x?}/{y?}");`

- İlgili url üzerinde parametrelerimiz eğer nullable değilse mecbur o parametrelere belli bir değer girilmesi gerekecektir. Kah default olarak girilebilir kah manuel bir şekilde girilmesi gerekecektir. Ama gelen istekte kesinlikle o parametreye değerin gelmesi gerekecek. Ortadan birisi nullable olması çok mantıklı hareket olmayacaktır. O yüzden buradaki formatlandırma da dikkatli olunması gerekir.

- Url'den gelen parametrelerdeki değerlerin türleri normal şartlarda sistem tarafından belli olmaz yani bütün türlerin değerlerini taşıyabilecek bir parametre oluşturmuş oluyorsunuz. Dolayısıyla sen buradaki parametreye herhangi bir türde değer verebiliyorsun.

- Biz burada istediğimiz türde parametre verebiliyoruz. İlgili action tetiklendiğinde ilgili parametreleri yakalamak istiyorsanızda bu parametrelerin isimlerine karşılık gelen parametreler barındırabilir. Bu parametre isimlerine karşılık gelen property isimleri olan bir class'lada karşılama yapabilir. Biz genellikle url üzerinden gelen dataları karşılarken çok böyle profesyonel bir çalışma ya da kompleks bir çalışma yapmıyorsak direkt action'larda parametre olarak yakalıyoruz.

- Buradaki parametrelerin değerlerinin geleceği türleri bilemeyeceğimizden dolayı gönderilen değerleri en geniş türle karşılamanız doğru olacaktır. `string`le karşılamak daha doğru olacaktır. Çünkü ne gönderirsen gönder `string` oradaki değeri karşılayacak.

- Route'lardaki parametreleri belirli değerler/türlerle kısıtlayabiliyoruz. Örneğin id kesinlikle `int` olacak diyorum ve o rotada id `int`ten başka şansı kalmıyor. İşte biz buna Route Constraint'leri diyoruz.

- `{o:int?}` => Senin parametren süslü parantezin içerisinde dolayısıyla bunun içerisine vermiş olduğun örneğin o isimli parametre isminin yanına gelip türünü bildiriyorsun. İşte bu ifade sayesinde o parametresinin alacağı değerleri hangi türde olacağını bildirmiş oluyorsun. Hem türünü bildirip hem de türünü bildireceksek tür? yapacaksın

<img src="4.png" width="auto">

- `short`, `byte` tanımlaması yapamamaktayız. Bunlarla alakalı çok fazla teferruata gerek yok. Çünkü siz belirli parametrelerde sayısal değer taşıyacaksanız buraya `int` yazabiliyorsunuz ama `short` yazamıyorsunuz aslında. `short`'u çünkü `int` kapsadığından dolayı `int` ile karşılanmanız gerekecektir. Benzermantıkla örneğin bir parametrenin sadece `string` parametre almasını istiyorsan diğer türleri almasını istemiyorsam buraya gelip sadece `string` yazmanız doğru olmayacaktır çünkü yazmadığınız taktirde zaten bütün türler esasında `string`le ifade edilebileceğinden dolayı sen zaten buna direkt `string` özelliği tanımlamış oluyorsun.

- Burada dikkat etmen gereken nokta constraint uygularken sayısal değerlerde sadece `int` kullanabiliyoruz. `int` dışında başka bir sayısal ifadenin kullanılmadığını hata verdiğini görüyoruz gözlemliyoruz. 

- Sayısal ifadelerde `int` kullanabiliyorsun ama ondalıklı sayılarda daha farklı ondalıklı türlerde `decimal`'ı `double`'ı ve `float`'ı kullanabiliyorsun. Uniquidentifier türlerde `guid`'i kullanabiliyorsunuz. Tarihsel formatlarda tarihsel bir değer olacaksa girilecek değer `datetime`'ı kullanabiliyorsunuz. `alpha` sadece ingilizce karakterlerde ingilizce harflerden a'dan z'ye kadar olanları yalnız bunları küçük harf ya da büyük harf olacak şekilde kullanmamızı sağlayabiliyor.

<img src="5.png" width="auto">

- `{x:length(12)}` => Bir parametrenin kaç karakter olacağına kadar ifadeler de bildirebiliyoruz. Bu şekilde bir bildirim yaptığınızda buraya gelecek metinsel ifadenin 12 karakter olacağını bildirmiş oluyorsunuz.
    * `length(12)` => Bu değerler kaç karakter olması gerektiğini bildirebiliyoruz.

<img src="6.png" width="auto">

- Regex constraint'ler uygulayabiliriz.

- `{x:alpha:length(12)?}` Belirli constraint'lerde kombin yapabiliyoruz. İlgili parametre `int` olsun yahut `alpha`'nın dışında da şu kadar karakter olsun. Hem alfanumerik hem de 12 karakter olmak zorunda x parametresine gelen değer.

- `IRouteConstraint` interface'i üzerinden custom rotalar oluşturabiliyoruz.

- Rotadaki parametrelere custom constraint oluşturacaksak eğer `IRouteConstraint` interface'ini kullanmamız gerekiyor. Haliyle bu interface'i kullanmak sadece varolan bir sistemi kullanmak değil bunu bir concrete'ini yani somut nesnesine ihtiyacımız olacak.

- Custom olarak oluşturduğumuz constraint'i sistemde kullanabilmek için yapmamız gereken işlem oluştrudğumuz constrainti uygulamaya configure olarak eklemek

```C#
//**************** Custom Constraint ****************
namespace RouteYapilanmasi.Constraints
{
    public class CustomConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            return true;
        }
    }
}
//**************** Program.cs ****************
builder.Services.Configure<RouteOptions>(options =>
{
    options.ConstraintMap.Add("custom", typeof(CustomConstraint));
});
```

- Uygulamalarımızdaki rotaları program.cs dosyasında merkezi bir hale getirip tutabilmekteyiz. Dolayısıyla rotalarımızın hepsini tek bir alanda tanımlayarak yönetebilmekteyiz. Ama bu bir yöntemdir bir tercihtir. Bir de bunun dışında ayrıyetten attribute'larla controller bazlı controller'lara özel route tanımlamaları gerçekleştirebilmekteyiz.

- Bu şekilde yapmış olduğumuz yöntem konvensiyonel yani geleneksel olarak geçmekte. Program.cs üzerinde yapılan rotalar merkezi hale getiriliyor. Biz buna geleneksel yaklaşım diyoruz. Bir de attribute ile yaklaşım var. Controller bazlı attribute üzerinden yürütülen route operasyonudur.

- Controller bazlı rota tanımlama sürecinde herhangi bir konvensiyonel rota tanımına ihtiyacımız olmayacaktır.

- Herhangi bir controller kendine ait gelecek olan istekte kendisini tetikletebileceği rotayı kendi üzerinde belirleyebilmektedir. Bunun içinde `[Route]` attribute'unu kullanmaktayiz. `[Route]` attribute'u sayesinde controller bazlı rotalarımızın şemalarını belirleyebiliyoruz.

- Bir controllera gelecek olan isteğin öncelikle controller seviyesinde hangi formatta olduğunu bildirmem lazım daha sonra da action'ı ayırt edebilmem lazım. Bunun için özelleştirilmiş bir metinsel değer de kullanabilirsiniz. Ya da ön tanımlı olan parametreleri de kullanabilirsiniz.

- Attribute tabanlı bir routing kullanıyorsan ön tanımlı özel parametrelerimiz köşeli parantezlerle tanımlanmakta `[controller]/[action]/{id?}` ama varsa bir özel parametreniz/kendime ait/custom parametrelerimiz `{}` ile tanımlanmalıdır.

<img src="7.png" width="auto">

- Her ne kadar `[Route]` attribute'u ile routing operasyonu gerçekleştiriyor olsak bile program.cs'te `endpoints.MapControllers()` demeniz lazım. Bu da kardeşim controller'larda gelen isteği controller'lardaki rotalarla eşleştir demiş oluyorsunuz.

- .Net Core yapılanmasında standart framework'teki API'larla MVC yapılanmasındaki controller'lar ayrıydı ama .Net Core'da bunlar birleştirildi. Yani sen MVC'de kullanmış olduğun controller'ı bizzat API'da da kullanıyorsun.

- Action'ı özelleştirmek için action bazlı tanımlama yapmamız gerekmektedir. Çünkü bir controller'da birden fazla action bulunabilir.

- Genellikle MVC yapılanmasında konvensiyonelin kullanıldığını görürsünüz. Yani geleneksel olarak bütün rota şablonları program.cs dosyasında merkezi olarak yönetilir. Ama API yapılanmalarında özellikle servis yapılanmalarında vs tüm API'lar controller bazlı route şablonlarının yapıldığını göreceksiniz.

- Temel MVC mimarisinde konvensiyonel yaklaşımı sergilerken API'larda geleneksel olarak değil Attribute üzerinden routing işlemlerini yapıyor olacağız.

## C# Examples
```C#
//************************* Controller *************************
using Microsoft.AspNetCore.Mvc;
using RouteYapilanmasi.Models;
using System.Diagnostics;

namespace RouteYapilanmasi.Controllers
{
    //[Route("[controller]/[action]")]
    [Route("ana")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Route("in/{id?}")]
        public IActionResult Index(int? id)
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

//************************* Program.cs *************************
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

//************************* Index *************************
@{
    ViewData["Title"] = "Home Page";
}

<div class="text-center">
    <h1 class="display-4">Welcome</h1>
    <p>Learn about <a href="https://docs.microsoft.com/aspnet/core">building Web apps with ASP.NET Core</a>.</p>
</div>


@Html.ActionLink("Anasayfa","Index","Home")

<a asp-action="Index" , asp-controller="Home">Anasayfa</a>

//************************* Custom Constraint *************************
namespace RouteYapilanmasi.Constraints
{
    public class CustomConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            var idValue = values[routeKey];
            return true;
        }
    }
}
```