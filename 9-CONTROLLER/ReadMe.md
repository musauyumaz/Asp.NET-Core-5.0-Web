---
modified: 2023-06-15T11:18:56.957Z
title: 15) Asp.NET Core 5.0 - Action Türleri Nelerdir?
---

***
# 15) Asp.NET Core 5.0 - Action Türleri Nelerdir?
- Client'tan gelen request'i controller karşılar. Controller request'in mahiyetine uygun olan/bu işlemi yapacak olan action'a yönlendiriyor yani ilgili fonksiyon tetikleniyor bu fonksiyon ihtiyaca binaen bütün operasyonu/aksiyonu alıyor. Gerektiği taktirde model'a gidiyor Model'da ilgili veri üretiliyor ve elde ediyor. Gerekirse View'e gidiyor View'de ilgili veriyi makyajını yapıyor tekrar elde ediyor ve en nihayetinde client'a istediği veriyi bir şekilde döndürmüş oluyor. İşte buradaki operasyonu action üstlenir. Controller sadece bu action'ların tutulduğu bir sınıf bizim nazarımızda.

<img src="1.png" width="auto">

- Bir developer geri dönüş türlerine uygun değer üretmemiz gerekiyorsa bu değerleri üretecek fonksiyonlar bizim base class'ımız tarafından bizlere sunulmaktadır.

- Sen hangi türde client'a değer döndüreceksen bu türe uygun fonksiyonu çağırman yeterli ekstradan bişey yapmana gerek yok.

## ViewResult
- Response olarak bir View dosyasını(.cshtml) render etmemizi sağlayan action türüdür.

- View'i render ettikten sonra sonuç ViewResult olarak elde ediliyor. ve bunu client'a gönderiyorduk.

- Bir action fonksiyonu ViewResult geriye döndürüyorsa bu bir View render etmek ve ilgili render edilen sonucu ViewResult'u client'a göndermek ister.

- ViewResult'ta View'i render etmek istiyorsanız base `class`taki `View()` fonksiyonunu kullanmanız yeterli olacaktır.

- `View()` fonksiyonu bildiğiniz üzere ilgili controller ismine karşılık gelen Views klasörü altındaki bir klasörün içerisindeki action metodunun ismine karşılık gelen .cshtml'i render eden otomtik bu path dizinini baz alıp çalışan ve oradaki render ettiği View'i bize sonucunu ViewResult olarak döndüren bir fonksiyondur.

```C#
public ViewResult GetProducts()
{
    ViewResult result = View();
    return result;
}
```

<img src="2.png" width="auto">

## PartialViewResult
- Yine bir View dosyasını(.cshtml) render etmemizi sağlayan bir action türüdür.

- ViewResult'tan temel farkı, client tabanlı yapılan Ajax isteklerinde kullanıma yatkın olmasıdır.

- Teknik fark ise ViewResult _ViewStart.cshtml dosyasını baz alır. Lakin PartialViewResult ise ilgili dosyayı baz almadan render edilir.

- Sen ViewResult kullanıyorsan bu ViewResult backend'de client'tan yapılan istek client tabanlı değilse biz ViewResult kullanıyoruz. Eğer ki Client tabanlıysa ajax teknolojisiyle gerçekleştiriliyorsa sen PartialViewResult kullanarak sonucu üretmelisin.

- Web sayfanın genelini sana oluşturan ViewResult ama bu web sayfandaki belirli bir local noktayı sana oluşturacak olan PartialViewResult.

- _ViewStart.cshtml içerisinde layout dediğimiz genel tasarımını tutan bir başlangıç View'idir. Dolayısıyla ViewResult bu başlangıç View'iyle beraber render edildiği için genel sayfayı render eder. Sen genel sayfayı değil belirli bir alanı render edip onun çıktısını o alanda kullanmak istiyorsan sayfanın genelini render etmeden parçasını belirli bir parçasına odaklı render işlemi yapmak istiyoean yani _ViewStart.cshtml dosyasını baz almak istemiyorsan PartialViewResult kullanman gerekiyor.

```C#
public PartialViewResult GetProducts()
{
    PartialViewResult result = PartialView();
    return result;
}
```

<img src="3.png" width="auto">

## JsonResult
- Üretilen datayı JSON türüne dönüştürüp döndüren bir action türüdür.

- Sen Client'a gelen istek neticesinde bir .json formatında değer döndüreceksen JsonResult döndürebilirsin.

- `Json()` fonksiyonu kendisi otomatik Json'a dönüşüm yaptığı için sen ekstradan bişey yapmana gerek yok. Json dönüşümlerinin sorumluluğunu biz üstlenmeyiz.

- JsonResult kullanıyorsan eğer sonuç sana .json formatında sayfanın formatıda .json olarak yüklenecektir. Onun için biz genellikle isteklerimizi JsonResult'ta bu şekilde yapmayız client tabanlı yaparız. Client tabanlı alırsın ki gelen .json nesneyi hani tarayıcıda manuel bir şekilde istek yaparak bütün herşeyi .json formatta görmektense Client tabanlı alıp client'ta işlemeyi tercih ederiz.

```C#
public JsonResult GetProducts()
{
    JsonResult result = Json(new Product
    {
        Id = 5,
        ProductName="Terlik",
        Quantity = 15
    });
    return result;
}
```

<img src="4.png" width="auto">

## EmptyResult
- Bazen gelen istekler neticesinde herhangi bir şey döndürmek istemeyebiliriz. Böyle bir durumda EmptyResult action türü kullanılabilir.

- Client'tan istek geldi istek işlendi ama kullanıcıya bir değer döndürmek istemiyorum tamam kardeşim bitti isteğini aldım ben senin yani tamam bitti bile demek istemiyorum böyle bir durumda geriye boş bir result döndürebilirsiniz. Geriye boş bir result döndürmek hani cevapsız gibi düşünmeyin response var ama result'u yok. 

- Response'u vardır ama Response'un içerisinde result döndürmemiş oluruz.

- HTTP Protokolü üzerinden sen request yaptığın zaman o Allah'ın emri bir tane response olacak. İyi ya da kötü bir response olur. Ama bu response içerisinde result taşır taşımaz.

- EmptyResult'un birde muadili vardır. `void` keywordüyle de aynı işlemi yapabilirsiniz. `void` keywordüyle de yine response oluşturmadan/olmadan gerekli çalışmayı yapabiliyorsunuz. Bu da aynı mahiyettedir. Muadili diyebiliriz.

```C#
public EmptyResult GetProducts()
{
    return new EmptyResult();
}

public void GetProducts()
{
}
```

<img src="5.png" width="auto">

## ContentResult
- İstek neticesinde cevap olarak metinsel bir değer döndürmemizi sağlayan action türüdür.

- Bunu da genellikle Client tabanlı çalışmalarda kullanırız.

- ContentResult sonucu sana text/plain olarak gönderir. 

- Formatı HTML'den ziyade bir text'tir.

- ContentResult, JsonResult gibi result'ları genellikle Client tabanlı tercih ederiz. O şekildeki operasyonlarda kullanırız çünkü ben normal bir web sitesinin web sayfasının formatınız bozmak istemem. Kullanıcıya bir değer döndüreceksem HTML'i render edilmediği bir sayfa olarak döndürmek istemem.

- ContentResult, JsonResult bunları biz genelde ajax tabanlı işlemlerde tercih ediyoruz.

```C#
public ContentResult GetProducts()
{
    ContentResult result = Content("Sebepsiz boş yere ayrılacaksan....");
    return result;
}
```

<img src="6.png" width="auto">

## ViewComponentResult
- İsteğe cevap olarak bir ViewComponent Render etmemizi sağlayan action türüdür.

- ViewComponent performanslı bir yapıdır.

<img src="7.png" width="auto">

## ActionResult
- Gelen istek neticesinde geriye döndürülecek action türleri değişkenlik gösterebildiği durumlarda kullanılan bir action türüdür.

- ActionResult, tüm action türlerini karşılayan ana türdür.

- Bütün Result türlerinin base `class`ıdır.

- Action türlerinin atasıdır.

- Farklı türleri döndürebilmen için sana ortak türleri sana sağlayan ActionResult türüdür.

- ActionResult ortak bir tür sağlar. Dolayısıyla genellikle ActionResult'u kullanır ve tercih ederiz.

- IActionResult ise ActionResult'un bir `interface`i arayüzü. IActionResult, ActionResult bunların hepsinin base'idir. Dolayısıyla ortak tür sağlamak istiyorsanız ve daha hızlı bir şekilde polimorfizm kurallarına dayanarak çalışma sergileme istiyorsanız IActionResult, ActionResult'u kullanabilirsiniz

<img src="8.png" width="auto">

## C# Examples
```C#
public class ProductController : Controller
{
    #region ViewResult
    public ViewResult GetProducts()
    {
       ViewResult result = View();
       return result;
    }
    #endregion
    #region PartialViewResult
    public PartialViewResult GetProducts()
    {
       PartialViewResult result = PartialView();
       return result;
    }
    #endregion
    #region JsonResult
    public JsonResult GetProducts()
    {
       JsonResult result = Json(new Product
       {
           Id = 5,
           ProductName="Terlik",
           Quantity = 15
       });
       return result;
    }
    #endregion
    #region EmptyResult
    public EmptyResult GetProducts()
    {
       return new EmptyResult();
    }
    #endregion
    #region ContentResult
    public ContentResult GetProducts()
    {
       ContentResult result = Content("Sebepsiz boş yere ayrılacaksan....");
       return result;
    }
    #endregion
    #region ActionResult
    public ActionResult GetProducts()
    {
        if (true)
        {
            //......
            return Json(new object());
        }
        else if (true)
        {
            return Content("asfasasdasd");
        }
        return View();
    }
    #endregion
    #region IActionResult

    #endregion
}
```