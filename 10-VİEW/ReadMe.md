---
modified: 2023-06-21T10:38:20.598Z
title: 17) Asp.NET Core 5.0 - View Yapılanması ve View'e Veri Taşıma
  Kontrolleri(ViewBag,ViewData,TempData)
---

***
# 17) Asp.NET Core 5.0 - View Yapılanması ve View'e Veri Taşıma Kontrolleri(ViewBag,ViewData,TempData)
- View dediğimiz Controller'da üretilen datanın görselleştirildiği Javascript, CSS kullanarak ve bunun gibi ekstradan UI tabanlı teknolojileri kullanılarak verinin görselleştirildiği render edildiği bir katman ve bu katmana özel geliştirilmiş bir özel formatta/uzantıda dosyadır View dediğimiz yapılanma.

- .cshtml bizim View dosyalarımızın uzantısıdır. Yani Controller'da üretilen değerin görselleştirileceği dosyaların uzantısı .cshtml'dir.

- C# ile HTML'in birleştirilmiş halidir .cshtml siz HTML'i C#'la kodlayabiliyorsunuz çıktı olarak render sadece HTML veren bir yapılanmadır.

- View dosyalarınız isz render ettikten sonra C# kodlarını göremezsiniz. Çıktı olarak sadece HTML verecektir.

- HTML'in içerisinde C# kodları yazmamızı sağlayan Razor teknolojisidir.

- View dosyası bizim için datalarımızı verilerimizi görselleştirebileceğimiz CSS ile HTML ile belirli makyajlar uygulayabileceğimiz bir dosya. 

- Projede View dosyaları genellikle Views klasörü altında bulunurlar. ASP.NET Core mimarisinde MVC'de action'ların karşılıkları olan View dosyalarını belirli bir ezbere bir format üzerinden bulmaktadır. Views klasörünün altında Controller isminde bir klasör vardır ve onun altında da action ismine karşılık gelen .cshmtl uzantılı dosyalar ilgili action'ının view dosyası olarak direkt default olarak kabul edilirler.

- View'ları da istersek farklı bir klasöre koyabiliriz ama bu sefer View fonksiyonunda senin View'larını yerleştirdiğin dizini belirterek ilgili View'i tetikleyebilirsin.

- Editör dediğin zaten senin için dosyaları hazır bir şekilde oluşturabilme yeteneğine sahiptir.

- Razor .cshtml içerisinde C# kodlarını yazmamızı sağlayan bir teknoloji. 

- Controller'dan View'e 4 farklı şekilde veri gönderebilmekteyiz. Bu 4 farklı şekilden biri Model bazlı veri göndermekken diğer 3'ü veri taşıma kontrolleriyle veri göndermektir. Model bazlı veri göndermeyle beraber biz ekstradan kullanıcıdan veri alabilirken veri taşıma kontrolleriyle sadece Controller'dan View'e veri gönderme operasyonlarını gerçekleştirebiliriz.

## Model Bazlı Veri Gönderimi
```C#
List<Product> products = new()
{
    new()  { Id = 1,ProductName="A Product", Quantity = 10},
    new() { Id = 2, ProductName = "B Product", Quantity = 15 },
    new() { Id = 3, ProductName = "C Product", Quantity = 20 },
};
#region Model Bazlı Veri Gönderimi
return View(products);
#endregion
```

- Request neticesinde üretilen datayı View'e gönderip orada render edebilmek için burada Model Bazlı Veri Gönderimi yöntemini kullanacaksak hem Controller'da hem de View'da bazı ayarlar yapmalıyız.

- Controller'da Model bazlı verinin gönderilmesi gerekiyor. Bunun için biz `View()` fonksiyonundan yararlanırız.

- Eğer ki bir veriyi View'e model bazlı gönderecekseniz `View()` fonksiyonunu direkt `return` etmeniz yeterli olacaktır. `View()` fonksiyonu ilgili action'a karşılık gelen View'i render edecek bir yandan da sizin datayı göndermenizi sağlayacaktır.

- View'e model bazlı veri geliyorsa Bu View'e gelen Model'ı bildirmemiz gerekir. View'e gelecek olan Model'ın hangi türde olduğunu bizim bildirmemiz gerekiyor. Bunuda `@model` keywordüyle sağlıyoruz. 

- Controller'dan View'e veri geliyorsa burada sadece `@model` keywordünün bu View'e gelecek olan datanın hangi türde olduğunu bildiriyoruz.
```C#
@model List<OrnekUygulama.Models.Product>

<ul>
    @foreach (var product in Model)
    {
        <li>@product.ProductName</li>
    }
</ul>
```

- Türünü bildirdikten sonra ise gelen datayı yakalayabilmek için ise `@Model` keywordünü kullanırız. `@Model`, `@model`'de bildirilen türe bürünür.

- Gelen nesneyi kullanabilmek View'da onu karşılayabilmek için doğru türü girmeniz gerekiyor ki doğru bir şekilde referans edebilesiniz.

- Render edilirken ilgili C# kodları ayıklanmakta sadece render'ın sonucu yani C#'ın sonucu HTML çıktısı bize döndürülmektedir.

## Veri Taşıma Kontrolleri
### ViewBag
- View'e gönderilecek/taşınacak datayı `dynamic` şekilde tanımlanan bir değişkenle taşımamızı sağlayan bir veri taşıma kontrolüdür.

- `ViewBag` `dynamic`tir.

- `ViewBag` ile yapmuş olduğumuz bu çalışma View'de erişilebilir hale gelecektir. Sen action'daki çalışma neticesinde hangi View'i render ediyorsan o View'e `ViewBag`le ilgili veri gönderilmiş olacaktır.

- Gelecek olan data `dynamic` olduğu için runtime'da şekillenecek/türü belli olacak. Bizim development aşamasında da türü belirleyebilmemiz için ilgili dönüşümü sağlamamız gerekiyor.

```C#
List<Product> products = new()
{
    new()  { Id = 1,ProductName="A Product", Quantity = 10},
    new() { Id = 2, ProductName = "B Product", Quantity = 15 },
    new() { Id = 3, ProductName = "C Product", Quantity = 20 },
};
ViewBag.products = products;
```

```C#
@model List<OrnekUygulama.Models.Product>

<ul>
    @foreach (var product in ViewBag.products as List<OrnekUygulama.Models.Product>)
    {
        <li>@product.ProductName</li>
    }
</ul>
```

### ViewData
- `ViewData` kontrolüde action'daki datayı aynen `ViewBag`te olduğu gibi direkt View'e taşıyan bir kontroldür. 

- `ViewData` ilgili datayı Boxing ederek taşır. Bu yüzden View'de senin datayı unboxing edip kullanman gerekecektir.

```C#
List<Product> products = new()
{
    new()  { Id = 1,ProductName="A Product", Quantity = 10},
    new() { Id = 2, ProductName = "B Product", Quantity = 15 },
    new() { Id = 3, ProductName = "C Product", Quantity = 20 },
};
ViewData["products"] = products;
```

```C#
@model List<OrnekUygulama.Models.Product>

<ul>
    @foreach (var product in ViewData["products"] as List<OrnekUygulama.Models.Product>)
    {
        <li>@product.ProductName</li>
    }
</ul>
```

### TempData
- `ViewData`da olduğu gibi actiondaki datayı View'e taşımamızı sağlayan bir kontroldür.

- Veriyi `ViewData`da olduğu gibi birebir Boxing'e tabi tutar. View'de senin Unboxing yapmanı bekler.

- Biz action'ları kendi aralarında yönlendirme yapabiliyoruz. Örneğin Index action'ı operasyonu bittikten sonra hani direkt kullanıcıya herhangi bir response göndermeden önce başka bir action'a redirect işlemi gerçekleştirebiliyoruz/yönlendirebiliyoruz. O action'daki operasyonunda gerçekleşmesini sağlayabiliyoruz. böyle bir durumda farklı bir action'a yönlendirme söz konusu olduğunda siz `ViewBag` ya da `ViewData`'la veri taşıyamazken `TempData`yla verileri rahatlıkla taşıyabilirsiniz. Çünkü arkada `TempData` dediğimiz yapılanma esasında bir cookie kullanıyor. cookie üzerinden veriyi taşır.
 
- Yönlendirme yaptığımız zamanlarda bir action'da elde edilen dataları farklı bir action'a göndermek istiyorsak burada `TempData`yı kullanmamız gerekecek. Aksi taktirde diğer veri taşıma kontrolleriyle action'lar arasında veri taşımamız pekte mümkün değildir.

- `TempData`da yönlendirme esnasında eğer kompleks type yani bir nesne/koleksiyon kullanıyorsanız bu nesneyi bir şekilde Serialize etmeniz gerekmektedir. Aksi taktirde hata alacaksınızdır.

- `TempData` cookie değeri üzerinden veriyi taşıyor. Haliyle cookie'ye ilgili verinin dönüştürülebilmesi/serialize edilebilmesi gerekiyor. Serialize edilebilmesi için basit türlerde sıkıntı yok ama kompleks type'da çalışıyorsanız  kompleks type'ın serialize edilebilmesi ekstradan bir maliyet ve bunu normalde gerçekleştiremediğinden dolayı patlamalar meydana geliyor.

```C#
TempData["x"] = 5;
ViewBag.x = 5;
ViewData["x"] = 5;

var v1 = ViewBag.x;
var v2 = ViewData["x"];
var v3 = TempData["x"];

<h3>TempData</h3>
<ul>
    @foreach (var product in TempData["products"] as List<OrnekUygulama.Models.Product>)
    {
        <li>@product.ProductName</li>
    }
</ul>
```

## C# Examples
```C#
public class ProductController : Controller
{
    public IActionResult Index()
    {
        List<Product> products = new()
        {
             new()  { Id = 1,ProductName="A Product", Quantity = 10},
             new() { Id = 2, ProductName = "B Product", Quantity = 15 },
             new() { Id = 3, ProductName = "C Product", Quantity = 20 },
        };
        #region Model Bazlı Veri Gönderimi
        return View(products);
        #endregion
        #region Veri Taşıma Kontrolleri
        #region ViewBag
        //View'e gönderilecek/taşınacak datayı dynamic şekilde tanımlanan bir değişkenle taşımamızı sağlayan bir veri taşıma kontrolüdür.
        ViewBag.products = products;
        #endregion
        #region ViewData
        //ViewBag`te olduğu gibi actiondaki datayı View'e taşımamızı sağlayan bir kontroldür.
        ViewData["products"] = products;
        #endregion
        #region TempData
        //ViewData`da olduğu gibi actiondaki datayı View'e taşımamızı sağlayan bir kontroldür.
        TempData["products"] = products;
        TempData["x"] = 5;
        ViewBag.x = 5;
        ViewData["x"] = 5;
        string data = JsonSerializer.Serialize(products);
        TempData["products"] = data;
        #endregion
        #endregion
        return RedirectToAction("Index2", "Product");
    }
    public IActionResult Index2()
    {
        var v1 = ViewBag.x;
        var v2 = ViewData["x"];
        var v3 = TempData["x"];
        string data = TempData["products"].ToString();
        List<Product> products = JsonSerializer.Deserialize<List<Product>>(data);
        return View();
    }
}

//VİEW
@model List<OrnekUygulama.Models.Product>

<ul>
    @foreach (var product in Model)
    {
        <li>@product.ProductName</li>
    }
</ul>

<h3>ViewBag</h3>
<ul>
    @foreach (var product in ViewBag.products as List<OrnekUygulama.Models.Product>)
    {
        <li>@product.ProductName</li>
    }
</ul>

<h3>ViewData</h3>
<ul>
    @foreach (var product in ViewData["products"] as List<OrnekUygulama.Models.Product>)
    {
        <li>@product.ProductName</li>
    }
</ul>

<h3>TempData</h3>
<ul>
    @foreach (var product in TempData["products"] as List<OrnekUygulama.Models.Product>)
    {
        <li>@product.ProductName</li>
    }
</ul>
```

***
# 18) Asp.NET Core 5.0 - View'e Tuple Nesne Gönderimi ve Kullanımı
- Tuple nesnesi içerisine birden fazla veriyi/değeri/nesneyi referans edebilen ve semantik açıdan dilin bize kazandırmış olduğu bir söz dizimine/sytnax'a sahip olan bir nesnedir.

- Biz birden fazla veriyi ya da nesneyi bir bütün olarak kullanabilmek için ViewModel dediğimiz Model'ları tasarlarız. Ya da bunun yerine isterseniz dilin bize kazandırmış olduğu tuple syntax'ını da kullanıp bu söz dizimi üzerinden de hızlı bir şekilde ViewModelvari değerler üretebilirsiniz. 

- Tuple nesneleride bizim için esasında bir ViewModel mahiyetinde çalışabilen yapılardır.

- Elimizde eğer birden fazla nesne varsa bunu View'e iki farklı yöntemle gönderebiliriz. Birisi Tuple bir diğeri ise ViewModel.

- ViewImports dosyasında ASP.NET Core MVC uygulamalarında ortak namespace'lerimizi tek çatı altından yönetmemizi sağlar.

- ViewModel ile data gönderme;
```C#
//---------- ViewModels ----------
public class UserProduct
{
    public User User { get; set; }
    public Product Product { get; set; }
}

//---------- Models ----------
public class Product
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
}
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
}

//---------- Controllers ----------
public class ProductController : Controller
{
    public IActionResult GetProducts()
    {
        Product product = new()
        {
            Id = 1,
            ProductName = "A Product",
            Quantity = 15
        };

        User user = new()
        {
            Id = 1,
            Name = "Musa",
            LastName = "Uyumaz"
        };

        UserProduct userProduct = new()
        {
            Product = product,
            User = user
        };
        return View(userProduct);
    }
}
//---------- Views ----------
@model OrnekUygulama.Models.ViewModels.UserProduct

<h3>@Model.Product.ProductName</h3>
<h3>@Model.User.Name</h3>
```

- Referans olarak tuple nesnesini birebir bir şekilde bildirmeniz gerekiyor.

- Birden fazla veriyi fazlasıyla veri taşıma kontrolleriyle taşınıyor bu da ekstradan yüksek maliyet demektir. Böyle durumlarda ViewModel ya da Tuple nesnenisini kullanmanız gerekecektir.

## C# Examples
```C#
//---------- Controllers ----------
public class ProductController : Controller
{
    public IActionResult GetProducts()
    {
        Product product = new()
        {
            Id = 1,
            ProductName = "A Product",
            Quantity = 15
        };

        User user = new()
        {
            Id = 1,
            Name = "Musa",
            LastName = "Uyumaz"
        };

        //UserProduct userProduct = new()
        //{
        //    Product = product,
        //    User = user
        //};
        //return View(userProduct);

        (Product product, User user) userProduct = (product, user);
        return View();
    }
}

//---------- Views ----------
@*@model OrnekUygulama.Models.ViewModels.UserProduct

<h3>@Model.Product.ProductName</h3>
<h3>@Model.User.Name</h3>*@

@model (OrnekUygulama.Models.Product product,OrnekUygulama.Models.User user)

<h3>@Model.product.ProductName</h3>
<h3>@Model.user.Name</h3>

//---------- Models ----------
public class Product
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
}
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
}
```