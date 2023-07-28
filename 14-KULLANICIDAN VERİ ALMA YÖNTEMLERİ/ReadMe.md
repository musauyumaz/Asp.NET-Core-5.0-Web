---
modified: 2023-07-28T05:59:18.196Z
title: "25) Asp.NET Core 5.0 - Kullanıcıdan Veri Alma Yöntemleri - Form
  Üzerinden Veri Alma "
---

***
# 25) Asp.NET Core 5.0 - Kullanıcıdan Veri Alma Yöntemleri - Form Üzerinden Veri Alma 
- Veri Alma Yöntemleri
    * Form üzerinden veri alma (bind edilmiş)
    * Form üzerinden veri alma (bind edilmemiş)
    * Query String üzerinden veri alma
    * Route Parametreleri üzerinden veri alma
    * Header'lar üzerinden veri alma
    * Ajax/Client tabanlı yapılan istekler üzerinden veri alma

- Kullanıcıdan veriyi almanın tek yöntemi kullanıcının bize istek göndermesi. Tabiki de farklı yöntemler var. Fakat bizim inceleyeceğimiz kullanıcı taraflı verilen kendi rızasıyla yapmış olduğu istek neticesinde gelen dataları yakalamaktır.

- Bize kullanıcının bir istek göndermesi lazım bu datanın bu isteğin herhangi bir yerinde tutulmuş olması gerekiyor Örneğin body'sinde olabilir. Header'da olabilir. Ya da bu request'te query string değerleri olabilir. Route parametrelerinde olabilir. Yani bir şekilde gelen isteğin belirli noktalarını kullanıcı verilerini yerleştiriyor. 

- İllaki bir tetikleyici mekanizmanın olması gerekiyor Nerede çalışırsan çalış nereden veri çekmek istersen iste.

- Bir kullanıcı var ve bu kullanıcının veri girebileceği bir sayfa var o sayfayı biz genellikle html'in bize sağlamış olduğu `<form>` etiketi üzerinden tasarlarız çünkü `<form>` kullanıcının girmiş olduğu o dataları girdiği inputları kendi içerisinde tanımlamamızı sağlıyor ve bu tanımlanan inputları tek seferde belirli bir sunucuya göndermemizi sağlayabiliyor. Dolayısıyla sen bir forma girilen dataların hepsini yani oradaki input nesnelerine girilen dataların hepsini tek bir form sayesinde bir yere postalayabiliyorsun.

- `<form>` kullanıcıdan veri almamızı sağlayan input nesnelerindeki verileri server'a göndermemizi sağlayan en temel veri alma nesnelerinden birisidir. Html tabanlıdır.

- Form üzerinden veri alma iki türlüdür. Post ve Get olarak veri alabiliyoruz. Put ve Delete Html form yapılanmasında pek fazla kullanılmıyor. Dolayısıyla veri gönderirken ya da veri alırken kullanılan bir yapılanmadır.

- Kullanıcıdan veri alacaksak Form'da Post'u kullanmamız gerekiyor.

- Senin tasarladığın formun içine koymuş olduğun input'lar o form tarafından direkt hedef sunucuya post edilecektir. Tabi sen Get yapabiliyorsun ama veri göndereceksen onun Post etmen lazım.

- `<input>` değerinin `<form>`un tetiklenmesi neticesinde değerini taşıyacaksan Yani buradaki `<input>`'un bu nesnenin değerini yakalayıp ilgili server'a gönderip orada yakalayacaksam eğer bu `<input>`'a bir tane `name` değeri vermem gerekiyor. `name` `<form>` içerisindeki ilgili `<input>`ların datalarını ayırabilmek için birbirlerinden kullanılan bir parametredir. Dolayısıyla `<form>`'da `<input>`'ları `name`lerle ayırmamız gerekecektir.

- İlgili `<form>` tetiklendiği zaman hedef endpoint neresiyse `<form>` içerisindeki tüm `<input>`lar `name`lerine/`name` değerlerine/`name` isimlerine karşılık ayrılacak ve ilgili sunucuya gönderilmiş olacak bizde burada bu verileri yakalamış olacağız.

- Gelen request'teki dataların %95'ini karşılayan action'daki parametre kısmında yakalarız.

- Dataları yakalamak için `IFormCollection` dan yararlanabiliriz. `IFormCollection` `Microsoft.AspNetCore.Http` `namespace`'i altından gelen bir arayüzdür. Bu arayüz sayesinde Post edilen `<form>`un içerisindeki tüm `<input>` nesnelerinin dataları yakalanabilmektedir. Biz bu dataları `name` değerine göre ayırt edip yakalayabiliyoruz.

```C#
[HttpPost]
public IActionResult VeriAl(IFormCollection datas)
{
    string value1 = datas["txtValue1"];
    string value2 = datas["txtValue2"];
    string value3 = datas["txtValue3"];

    return View();
}
```

- Biz `name` değerleriyle eşleşmiş parametrelerle de bu `<input>`'lardaki değerleri karşılayabiliyoruz.

- İlgili gelebilecek olan `<input>`taki değeri karşılayabilecek olan bir parametre tanımlayıp onu `<input>`'un `name` değeriyle bind etmemiz gerekiyor.

```C#
[HttpPost]
public IActionResult VeriAl(string txtValue1,string txtValue2, string txtValue3)
{
    
    return View();
}
```

- Kullanıcıdan gelen değerleri bu değerlere karşılık gelecek bir tür ile bir nesnenin ya da bir `class`,`struct`,`record` olabilir bunlardan herhangi birinin instance'ı ile yakalayabilmekteyiz.

```C#
[HttpPost]
public IActionResult VeriAl(Model model)
{
  return View();
}

public class Model
{
    public string TxtValue1 { get; set; }
    public string TxtValue2 { get; set; }
    public string TxtValue3 { get; set; }
}                                           
```

- Form üzerinden bind edilmiş verileri almak için ilgili view'de `<input>`'a karşılık bir binding işlemi gerçekleştirmeniz gerekiyor.

```C#
//------------------ View ------------------
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
@model OrnekUygulama.Model.Product

<form asp-action="VeriAl" asp-controller="Product" method="post">
    <input asp-for="ProductName" type="text"  /><br />
    <input asp-for="Quantity" type="text" /><br /> 
    <button>Gönder</button>
</form>

//------------------ Controller ------------------
[HttpPost]
public IActionResult VeriAl(Product model)
{

    return View();
}
```

- Veri taşınırken yine oradaki `name` değerleri önemlidir. Sen bir `<input>` nesnesini herhangi bir türe bind ettiğinde aslında ilgili input oluşturulurken ona `name` değerleri veriliyor.

- Bind'da hangi modeli kullandıysan Post neticesinde o model türünde ilgili dataları karşılamak idealdir. Burada türe bağımlılık yoktur. Esasında bu türün bind etmiş olduğun property'lerine karşılık name değerlerinde `<input>`lar oluşturulucağından dolayı o `name` değerlerini barındıran farklı bir türle de karşılama yapabiliyorsun.

## C# Examples 
```C#
//------------------ View ------------------
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
@model OrnekUygulama.Model.Product

<form asp-action="VeriAl" asp-controller="Product" method="post">
    <input asp-for="ProductName" type="text"  /><br />
    <input asp-for="Quantity" type="text" /><br /> 
    <button>Gönder</button>
</form>
//------------------ Controller ------------------
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrnekUygulama.Model;

namespace OrnekUygulama.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult CreateProduct()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult VeriAl(IFormCollection datas)
        //{
        //    string value1 = datas["txtValue1"];
        //    string value2 = datas["txtValue2"];
        //    string value3 = datas["txtValue3"];

        //    return View();
        //}
        //[HttpPost]
        //public IActionResult VeriAl(string txtValue1,string txtValue2, string txtValue3)
        //{

        //    return View();
        //}
        //[HttpPost]
        //public IActionResult VeriAl(Model model)
        //{

        //    return View();
        //}
        [HttpPost]
        public IActionResult VeriAl(Product model)
        {

            return View();
        }
    }
    public class Model
    {
        public string TxtValue1 { get; set; }
        public string TxtValue2 { get; set; }
        public string TxtValue3 { get; set; }
    }
    public class MyClass
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
//------------------ Model ------------------
namespace OrnekUygulama.Model
{
    public class Product
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
```