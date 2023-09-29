---
modified: 2023-09-29T09:00:52.904Z
title: 45) Asp.NET Core 5.0 - appsettings.json Dosyası Nedir? Ne İse Yarar?
---

# 45) Asp.NET Core 5.0 - appsettings.json Dosyası Nedir? Ne İse Yarar?
- Asp.Net Core uygulamalarını yapılandırmamızı sağlayan appsettings.json dosyası üzerine konuşuyor olacağız.

<img src="1.png" width = "auto">

## appsettings.json Dosyası Nedir? Ne İşe Yarar?​
- Asp.Net core uygulamalarında/ herhangi bir uygulamada çalışmamızı sergilerken yapacağımız operasyona göre yahut ortama göre yazılımın parametrelerine göre konfigürasyonlar yapmak isteyebiliriz. Dolayısıyla sen eğer ki Asp.Net Core uygulamasında çalışıyorsan Asp.Net Core'un yapılandırılmasını yani konfigürasyonunu sağlayan bir dosyadır.

- APPSETTINGS.JSON DOSYASI, ASP.NET CORE UYGULAMALARINI YAPILANDIRMA ARAÇLARINDAN BİRİSİDİR.

- Birden fazla yapılandırma aracımız vardır.

<img src="2.png" width = "auto">

## Yapılandırma Ne Demektir?
- Yapılandırma, bir uygulamanın herhangi bir ortamda gerçekleştireceği davranışlarını belirlememizi sağlayan statik değerin tanımlanmasıdır.

- Ben günlük hayatta yapacağım eylemlere göre kendimi nasıl ayarlıyorsam/yapılandırıyorsam yazılımda yapacağı eyleme ve o eylemlerin ortamına göre kendini yapılandırıp ayarlayabilmektedir. Örneğin Musa akşam yemeğine gidecek. Haliyle ne yapıyorum akşam yemeğine giderken yani o ortama giderken o ortamla ilgili giyiniyorum parfüm sıkıyorum saçlarımı ona göre tarıyorum yani hazırlanıyorum kendimi yapılandırıyorum.

- Yapılandırma dediğiniz sizin yapacağınız eyleme göre ortama göre değişiklik gösterebilir. Benzer mantıkla ortama eyleme göre değişiklik gösterdiği gibi sizin aksiyon alacağınız operasyon neyse o operasyona göre de farklı yapılandırma değerleriniz olabilir. Şimdi yemeğe gidicem benim ortamım yemek ortamı ona göre giyindim. Amma velakin yemeğe giderken kullanacağım taşıt araba mı olacak otobüs mü olacak taksiyle mi gidicem motorla mı gidicem yoksa ata mı binip gidicem artık bunu da hangi parametreyi seçeceğimi de yapılandırıp ona göre belirlemem lazım.

- Yapılandırma genellikle algoritmanın dışında lakin algoritmada kullanılacak olan değerleri belirleme sürecidir.

<img src="3.png" width = "auto">

- Benim yemeğe gidebilmek için ata ya da arabaya binip binmeyeceğimin kararını vermek algoritmam değil. Ama algoritmamda kullanılacak parametreyi belirleyen bir parametredir/değerdir. Akşam yemeğine gidebilmem gittikten sonra orada yemeği yemem bir işin fiiliyatı algoritmadır. Ama giymiş olduğum takım elbise ya da saçlarımın ne tarafa tarandığı vs. Bunlar oradaki ortamla ilgili belirli değerlerdir. Lakin yapılacak eylemle ilgili yani yemeği yemeyle ilgili şeyler değildir.

- Eski Asp.NET uygulamalarında kullanılan web.config yahut Global.asax gibi dosyalar standart framework'ün yapılandırmasında kullanılan ortamlardı.

- Bizim için Startup/Program.cs dosyası da bir konfigürasyon/yapılandırma dosyasıdır.

<img src="4.png" width = "auto">

## Konfigürasyon Değerleri Kodun İçerisinde Tanımlanmamalı!
- Şimdi siz kod geliştiriyorsunuz geliştireceğiniz kodda bazen mail göndermen gerekecek bazen yeri gelecek  veritabanına bağlanman gerekecek bazen yeri gelecek bir mesaj kuyruk sistemine değer göndermen gerekecek vs. vs. vs. Farklı mimarilerle distrubuted çalışmanız gerekecek vs. Böyle bir durumda bu operasyonlardan örneğin mail. Mail gönderme operasyonu yaparken senin maile mailin şifresine kime gönderileceğine ihtiyacın var vs. Şimdi statik olan değerler kodun içerisine saklanmaması lazım. Mail göndereceğin kodun içerisine gelipte mail'i gönderecek olan mail adresinle onun şifresinin yazılması ve bunun kodun içine gömmek best practice açısından doğru değildir. Alenen yanlıştır. Tamam kod derlenir çalışır ama yanlışsa yanlış bitti yani 2 + 2 = 5 değildir gibi bişey.

- Kodun içerisine veritabanına bağlantı yolu yazılamaycak işte mail göndereceksin mail gönderici ve şifresi yazılmayacak kullanıcı adı şifre yazılmayacak. Bu şekilde yazılması gereken değerler kodun dışında yönetilebilir yani yapılandırılabilir/konfigüre edilebilir şekilde bunların oluşturulup kodun içinde kullanılması gerekecek.

- Senin bir projen var. Elinde bir tane connection string'in var. Sen şimdi elindeki bu kullanacağın veritabanına yani bağlantı sağlaman gereken veritabanının veritabanı bağlantı sözcüğünü kodun içerisinde her yerde kullanman gerektiğini düşün Her veritabanına ihtiyacın olduğu yerde bunu kullandığını düşün. Şimdi bu kodun ne kadar yönetilebilir olacağını bir düşünsene. 

- Statik değerler kodun içerisine yazılırsa;
    * Yönetilebilirlik düşer. 
        + Bir gün veritabanı bilgin değişebilir. Veritabanının connection string'i yer değiştirebilir. Yani başka bir sunucuya taşıyabilirim Haliyle connection string değerlerim değişebilir. Yahut ismi değişebilir. Sunucu adı değişebilir. Parametreler değişebilir. Şimdi sen her değişiklikte bu connection string değerini kullandığın alanlara gidip tek tek ameleus şeklinde yani bir yazılımcısın ama hiç alakan yokmuş gibi gidipte tüm değerleri burada içine yazdıktan sonra yani bir yazılımcılık özelliği kalmıyor. Sen sadece Kod yazan bir adam olmuş oluyorsun. Halbuki yazılım geliştiren adam elindekileri daha efektif daha verimli bir şekilde kullanan adamdır. Sen bu değerleri her gördüğün yerde yazdığın zaman her bir değişikliği ilgili yazmış olduğun yerlerde tek tek gidip uygulaman gerekiyor. Biz buna ameleus felsefesi diyoruz yani bildiğiniz felsefeye sahip ama çok verimli bir felsefe değil. Elindeki statik değerleri sen kodun içerisine gidip manuel yazarsan birgün değişiklik gerektiği zaman inanılmaz derecede rezil rüsva bir şekilde gidip tek tek kodun içerisinden ilgili alanları bulup değiştirmen gerekecek. Haliyle yönetilebilirlik düşecektir. İnsanlık hali. eğer ki sen bütün iradeyi insanın yeteneğine o anki havasına o anki havanın şartlarına bırakıyorsan elbette ki insan olduğu için hata yapacak unuttuğu noktalar olacak. Haliyle sen bu uygulamayı derlediğin zaman production'a çıktığın zaman kullanıcı önünde hata alma riskin artacak. Nihayetinde değişikliği her yerde uyguladığını zannetsende gözünden kaçabilen yerler olacak. İster istemez kaçtığı zamanda her türlü rezilliği ya da kulağını çınlatan diyaloglara maruz kalacaksın.

<img src="6.png" width = "auto">

- Kodun içerisine statik yapılan tanımlamalar kodun kodsal özelliğini yitirmesini sağlar. Yani sen bu kodun içerisine tanımlama mı yapıyorsun yoksa bu kod yazılımsal bir işleve sahip olan bir kod mu? Baktığın zaman kodun şıklığı da önemli Hatta temiz kod deriz biz buna clean code. Clean code'luğunu da bozar yani oradaki kodun temizliğini arınmışlığını orada etkilemiş olacaksın bozmuş olacaksın dolayısıyla ilgili kodun içerisinde çıktı olamdığı sürece ya da algoritmanın bir neticesi olmadığı sürece metinsel, algoritmada o sırada dış parametreye göre kullanıalcak değerler hiçbir zaman kullanılmayacak.

- Veritabanı bilgisini kodun içinde kullanamacağım istersen bunu git veritabanına kaydet istersne git not defterine koy not defteri üzerinden bunları çek farketmiyor. Önemli olan merkezi bir yere yerleştir ve yerleştirdiğin merkezi yerden sana lazım olan konfigürasyonu yani ilgili değeri yani statik değeri tanımlamayı lazım olan noktalarda tek elden çek.

- Adamlar demiş ki ya kardeşim böyle bir durumda senin gidipte herhangi bir text dosyasından bunu çekmene gerek yok. Ya da veritabanına gidipte sırf bunun için bir bağlantı sağlayıp veritabanından çekmene gerek yok sen bunu gel bizim appsettings dediğimiz json dosyası üzerinden sağla. Yani buradaki connection string appsettings.json dosyası üzerinde olacak ve uygulamada sen bu dosya üzerinde yapmış olduğun connection string tanımlaması her lazım olan noktada ilgili dosyadan/kaynaktan/appsettings.json'dan çekeceksin.

- Uygulamada mail göndereceksin bu mailin kullanıcı adı ve şifresi uygulamanın bir ayarı/yapılandırması/konfigürasyonu değil mi? Benzer mantıkla uygulama içerisinde veritabanlarına bağlanıp işlem yapman lazım bu veritabanı connection string dediğimiz değer uygulamanın bir konfigürasyonu değil mi? Diyelim ki oauth 2.0 protokolüyle google üzerinden giriş yapman gerekiyor. Google sana client secret değeri veriyor. birde password veriyor verdiği değerler bu uygulama nihayetinde böyle aksiyonda bulunuyorsa bu değerler uygulamanın konfigürasyon değerleri değil mi? Uygulamanın çalışabilmesi için bu değerlerle çalıştırabilirsin. Bu değerler kilit noktalarda görev görüyor. Haliyle konfigürasyon değerleri oluyor.

- Konfigürasyon amaçlı kullandığınız yani statik tanımlama yaptığınız hiçbir değeri kodun içerisine gömmeyeceksiniz harici bir dosyaya koyacaksınız. İşte Asp.Net Core uygulamalarında bu harici dosya yani konfigürasyon değerlerini barındıran dosya appsettings.json dosyasıdır.

- Best practices açısından kodun içerisine username, password, connection string vs. gibi statik tanımlamalar yapılmamalıdır!

<img src="5.png" width = "auto">

## Asp.NET Core'da ki appsettings.json Dışındaki Yapılandırma Araçları Nelerdir? ​
- Appsettings.json | appsettings.{Environment}.json

- Secrets.json(Secret Manager Tools)

- Environment Variables

<img src="7.png" width = "auto">

## appsettings.json Dosyasının Asp.NET Core Uygulamasındaki Davranışı 
- Bir Asp.Net Core uygulaması üzerinde appsettings.json dosyaları varsa eğer tabikide yeterli değil. Sizin bu dosyaları sisteme dahil edebilmeniz lazım. Yani uygulama ayağa kalktığında bu dosya içerisindeki konfigürasyonlardan beslenebilmesi için bu dosyaların sistem tarafından/mimari tarafından tanımlanmış olması gerekecek. Bu dosyayı program.cs dosyasında tanımlayacağız. 

- Program.cs'teki çağırılan fonksiyonlar default olarak uygulamanın ana dizinindeki appsettings.json ve appsettings.{environment}.json ilgili dosyaları çeken uygulamaya önbellek olarak yükleyen bir donanıma sahip. Yani siz uygulamada appsettings.json dosyası görüyorsanız bu uygulamayı ayağa kaldırdığınızda sistemde varolan appsettings.json ve türevleri olan tüm dosyalar önbelleğe yüklenecektir. Yüklenecek olan dosyanın kendisi değil içeriğidir yani konfigürasyonlar. Dolayısıyla yüklenen bu konfigürasyonlar önbelleğe yüklendiği zaman artık mimari yani ayağa kalkan web uygulaması yüklenen bu konfigürasyonlar üzerinden davranışını şekillendirecek.

- Özelleştirilmiş bir .json dosyasını uygulamaya dahil etmek istiyorsanız program.cs-içerisinde ilgili dosyanın bildirilmesi gerekiyor. `ConfigureAppConfiguration(b => b.AddJsonFile("hilmi.json"))` isimli fonksiyonu çağırıp ilgili özel .json dosyasını konfigürasyon dosyası olarak sisteme dahil edebiliriz. appsettings.json ismindeyse bunu bildirmenize gerek yok mimaride arka planda appsettings.json özel tanımlanmış bir isim olduğundan dolayı otomatik bulunup eklenmekte ve uygulama ayağa kaldırılırken ilgili konfigürasyon dosyası içindeki bütün konfigürasyonlar önbelleğe yüklenmektedir. Oradan da uygulama davranışını belirlemektedir.

```C#
//*************** Program.cs ************************
builder.Configuration.AddJsonFile("hilmi.json");
```

## appsettings.json Konfigürasyonu
- Nasıl Veri Eklenir?

- Eklenen Veri Nasıl Okunur?
    * IConfiguration Arayüzü Nedir?
    * Indexer İle Veri Okuma Nasıl Yapılır?
    * GetSection Metodu İle Veri Okuma Nasıl Yapılır?
        + Get Metoduyla Verileri Uygun Nesneyle Eşleştirme
    * : Operatörü Nedir?

<img src="8.png" width = "auto">

## appsettings.json'a Veri Ekleme
- appsettings.json dosyasında bir javascript objesi var yani bir json formatında bir yapılanma. Biz konfigürasyonlarımızı bu formatta tutmaktayız. Bu konfigürasyonda key ve value tarzında çalışıyorsun. Ve bu value değerleri de obje olarak tanımlanabilmektedir. Yani içerisinde de ayrı ayrı objeler tanımlayabilmekteyiz. Key-value davranışı söz konusudur.

```JSON
{
    "OrnekMetin": "sebepsiz boş yere ayrılacaksan...",//Sistemde anlamlı bir konfigürasyon olacatır. Nihayetinde sen bunu sistemde erişip kullanacak halde tanımlamış oldun.
    "Person": {
        "Name": "Musa",
        "Surname": "Uyumaz"
    }
}
```

## appsettings.json'dan Veri Okuma
- appsettings.json'da herhangi bir konfigürasyona erişmek istiyorsan eğer `IConfiguration` arayüzünü kullanabilirsin.

## IConfiguration Arayüzü Nedir?
- Asp.NET Core IoC provider'ında bulunan bir servistir. Bu servis uygulamadaki appsettings.json dosyasını okumakta ve içerisindeki value'ları bizlere getirmektedir. Dolayısıyla IoC'den bu servisi herhangi bir controller'da/sınıfta dependency injection ile talep edebilir ve appsettings.json dosyasındaki konfigürasyonları kullanabiliriz.

- `IConfiguration` .NET çekirdeğinde dahil olarak gelen bir arayüzdür. Dolayısıyla senin ekstradan bişey yapmana gerek yok. Salt bir şekilde açmış olduğun uygulamanın dependency injection provider'ında yani IoC'sinde otomatik olarak bulunan bir arayüzdür.

<img src="9.png" width = "auto">

```C#
//**************************** HomeController ****************************
#region IConfiguration Arayüzü Nedir?
private readonly IConfiguration _configuration;
public HomeController(IConfiguration configuration)//Ben buradakine bağımlı olacağım yani bu IConfiguration'ı kullanacam bu nesneyi bunu ben new'lemek istemiyorum sen
bu bağımlılığı dışarıdan enjekte et. IoC'deki provider'dan ilgili nesneyi getiriyor. Gelen bu nesne buradaki parametre tarafından yakalanıyor. bu işlem neticesinde bunu bu uygulamada kullanabilmek istediğim yerde taşıyabilmek için global olarak tanımladığım readonly referans sayesinde işaretleyip her yerde global olarak kullanabilmekteyim.
{
    _configuration = configuration;
}
#endregion
```

## Indexer İle Veri Okuma Nasıl Yapılır?
- `IConfiguration` appsettings.json dosyası içerisindeki dataları otomatik çeken ve bize sunan bir nesne/servis. Dolayısıyla ben bunun üzerinde indexer'ım ile vermiş olduğum key'e karşılık gelen değeri elde edebilmekteyim.

- `:` operatörü buradaki ağaç yapılanmasında alt nesnelere/elemanlara/tanımlamalara erişebilmek için kullanılır.

- Uygulama ayağa kalkma sürecinde ilk adımda program.cs tetiklenirken appsettings.json ya da appsettings.json gibi diğer json formatındaki bütün konfigürasyon dosyaları tanımlananların hepsi uygulama ayağa kalkarken öncelikle içerisindeki konfigürasyonlar uygulamaya çekiliyor ve önbellekte yani inmemory'de tutuluyor. Artık hangi sunucuda bu uygulamayı ayağa kaldırıyorsanız o sunucunun inmemory'sinde ilgili değerler depolanacaktır. Haliyle bu çalışma zamanında `IConfiguration` gidipte dosyadan okumuyor inmemory'den okuyor.

- appsettings.json içerisinde mümkün mertebe Türkçe karakter kullanmamalıyız. Haliyle bir konfigürasyon evrensel olmalı yani gidipte oraya Türkçe karakter yazmayacaksın. Mümkün mertebe latince karakterler kullanacaksın. Benzer mantıkla konfigürasyondaki herhangi bir key'in altında metinsel değer yoksa bir obje varsa o key'i direkt çağırdığınızda `null` değer dönecektir. Çünkü bu `string` ile alakalı bir yapılanma değildir. Amma velakin bir key'e karşılık altında obje varsa bu objenin içindeki herhangi bir alanı çağırırken `:` operatörünü kullanıp `_configuration["Person:Name"]` bu şekilde o alanın değerini elde edebilirsiniz.  

```C#
//**************************** HomeController ****************************
public IActionResult Privacy()
{
    #region Indexer İle Veri Okuma Nasıl Yapılır?
    string? val1 = _configuration["OrnekMetin"];
    string? val2 = _configuration["Person"];
    string? val3 = _configuration["Person:Name"];
    string? val4 = _configuration["Person:Surname"];
    string? val5 = _configuration["Logging:LogLevel:Microsoft.Hosting.Lifetime"];
    #endregion
    return View();
}
```

## GetSection Metodu İle Veri Okuma Nasıl Yapılır?
- `_configuration.GetSection("Person")` yapılanması sayesinde siz vermiş olduğunuz key'e karşılık olan değeri bir section alan olarak elde edebiliyorsunuz. Bu değeri biz `IConfigurationSection` olarak yani bir konfigürasyon alanı olarak bizlere getirir. Dolayısıyla ben bu değeri `GetSection()` ile kullanıyorsam `string` olarak getirme gibi bir derdi olmayacağı için `null` dönmeyecektir.
​
- Indexer'da yapmış olduğumuz gibi direkt ilgili alanın key'in karşılığındaki değeri `string` olarak beklemediğimizden dolayı bir değer getirecektir.

- Indexer kullanıyorsan direkt değer odaklı bir konfigürasyon değerini çağırma işlemini yapmış oluyorsun. Değer odaklı çağırma yani direkt bana şu key'e karşılık olan konfigürasyon değerini getir kardeşim yorma beni demenin yoludur Indexer. Ya da ilgili konfigürasyon alanı ile ilgili daha fazla bilgi edinmek istiyorsanız `GetSection()` üzerinden alanı çağırabilirsiniz. Tabi bunu çağırdıktan sonra `Value` property'sini kullanmalıyız ki ilgili değeri sizlere getirsin.

```C#
//**************************** HomeController ****************************
public IActionResult Privacy()
{
    #region GetSection Metodu İle Veri Okuma Nasıl Yapılır?
    var v6 = _configuration.GetSection("Person");
    var v7 = _configuration.GetSection("Person:Name");
    #endregion
    return View();
}
```

## Get Metoduyla Verileri Uygun Nesneyle Eşleştirme​
- `Get()` fonksiyonu diyor ki sen bana bir tane type ver vermiş olduğun type'a karşılık ben sana ilgili appsettings.json'daki nesneyi döndüreyim diyor. Senin appsettings.json'da bir nesnen var buradaki kalıba uygun bir tane entity/viewmodel oluştur. Ya da DTO nesnesi oluştur. Bunu taşıyabilecek bir temsilci oluştur. Bu nesneyi bana ver ben sana ilgili ayarları geri döndüreyim.

- appsettings.json dosyasının içerisindeki konfigürasyonları sistemde daha efektif bir şekilde elde edebilmek için options pattern dediğimiz bir tasarım desenimiz var. Bu tasarım deseni Asp.Net Core mimarisinde dahili bir şekilde gelmektedir. Bu tasarımın nihai amacı esasında burada `Get` fonksiyonuyla ne yapıyorsak birebir o olacaktır. appsettings.json dosyasının içerisindeki tüm konfigürasyon yapılanmasını bize sınıf olarak bize bir sınıfın nesnesi/instance'ı olarak döndürebilecek bir tasarım deseni.

- `:` operatörü ise ilgili section'larımın arasında atlamamızı sağlayan yani bir section içerisindeki farklı bir alanı temsil etmemizi sağlayan bir operatördür.
 
```C#
//**************************** HomeController ****************************
public IActionResult Privacy()
{
    var v8 =_configuration.GetSection("Person").Get(typeof(Person));//Sen önce burada hangi section ile çalışacağını bildir ardından Get üzerinden ilgili section bir objeyse value olarak bir string dönmeyecekse bunu Get olarak belirli bir türde elde edebilirsin.
    var v9 = _configuration.GetSection("Person:Name").Get(typeof(String));
}
```
## Environment'a Göre appsettings.json Dosyası Ayarlama​
- Environment Asp.NET Core uygulamasının runtime'daki davranışını belirleyen değişkenleri kapsayan bir konu. 

- Environment variables(değişkenler) dediğimiz yapılanmsa sayesinde biz Asp.NET Core mimarisinde geliştirdiğimiz uygulamanın çalışma ortamını belirleyebilmekteyiz ve hani ortamdan ortama göre farklı değişkenler parametreler devreye sokabilmekteyiz.

- Asp.NET Core uygulamasına sağ tıklayıp Properties dediğimizde karşımıza uygulamaya dair konfigürasyon yapabildiğimiz uygulama ayarlarını yapabildiğimiz(derleyici/versiyonlama vs. ile ilgili olsun) bir dosya gelmekte. Bu pencerede Debug'a geldiğimizde Environment Variables isimli pencere var.

- Bu uygulama ne seviyesinde Development yani geliştirme sürecinde haliyle biz şu anda ortam olarak development ortamındayız. Eğer ki gelip Production yazarsan artık bu yayınlanıp publish edilip yayınlanmış halidir. Yani yayınlanan ortama karşılık gelecektir. Ne Production ne de Development ikisinin arası yani genellikle testlerin yapıldığı ortamı tarif etmek için Staging dediğimiz ortam aklımıza gelecektir. Bunların dışında custom ortamlarda belirleyebilirsin. Ama genellikle mimari tarafından ve mimaride yapmış olduğunuz çalışmaya göre eğer ki gerçek bir uygulama gerçekleştirme esnasındaysanız burası Development olarak tanımlanır. Eğer ki yayınladıysanız Production olarak yayınlanır eğer ki test sürecindeyseniz Staging olarak tanımlama yapılmaktadır.

- Dolayısıyla biz Environtment değişkenleri kullanırken genellikle ortamdan ortama farklı environment değişkenler devreye sokabiliriz. Yani bizim daha farklı değişkenlerimiz olabilir.

- appsettings.json tüm ortamlarda ister development olsun ister production olsun ister Ahmet Mehmet farketmiyor tüm ortamlarda ortak erişilebilir konfigürasyonları barındırırken appsettings.development.json sadece development ortamında konfigürasyonlara erişmenizi sağlar.

- Konfigürasyonları parçaladığınızda bir ortamdan diğerine erişim yapamazsınız amma velakin tüm ortamlarda erişebileceğiniz konfigürasyonlar appsettings.json içerisine tanımlanır. Dolayısıyla bu şekilde ortam ayırıcı özelliğe sahiptir Asp.NET Core mimarisi. Bununla ilgili ekstra bir çalışma yapmanız gerek yok. Haliyle bir tanımlama yapmana gerek yok yine appsettings ile başladığı için environment olduğu bilinecek mimari tarafından tüm hepsi sistem tarafından beslenilecek ve ilgili yayında ya da development sürecinde bu dosyalar konfigürasyonları kullanılabilir hale gelecektir.

- Biz genel konfigürasyonlarımızı appsettings.json'da yapıyoruz.

<img src="10.png" width = "auto">
<img src="11.png" width = "auto">
<img src="12.png" width = "auto">

## C# Examples
```C#
//**************************** HomeController ****************************
using ConfigurationExample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ConfigurationExample.Controllers
{
    public class HomeController : Controller
    {
        #region IConfiguration Arayüzü Nedir?
        private readonly IConfiguration _configuration;
        public HomeController(IConfiguration configuration)//Ben buradakine bağımlı olacağım yani bu IConfiguration'ı kullanacam bu nesneyi bunu ben new'lemek istemiyorum sen bu bağımlılığı dışarıdan enjekte et. IoC'deki provider'dan ilgili nesneyi getiriyor. Gelen bu nesne buradaki parametre tarafından yakalanıyor. bu işlem neticesinde bunu bu uygulamada kullanabilmek istediğim yerde taşıyabilmek için global olarak tanımladığım readonly referans sayesinde işaretleyip her yerde global olarak kullanabilmekteyim.
        {
            _configuration = configuration;
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            #region Indexer İle Veri Okuma Nasıl Yapılır?
            string? val1 = _configuration["OrnekMetin"];
            string? val2 = _configuration["Person"];
            string? val3 = _configuration["Person:Name"];
            string? val4 = _configuration["Person:Surname"];
            string? val5 = _configuration["Logging:LogLevel:Microsoft.Hosting.Lifetime"];
            #endregion
            #region GetSection Metodu İle Veri Okuma Nasıl Yapılır?
            var v6 = _configuration.GetSection("Person");
            var v7 = _configuration.GetSection("Person:Name");
            #endregion

            #region Get Metoduyla Verileri Uygun Nesneyle Eşleştirme​
            var v8 =_configuration.GetSection("Person").Get(typeof(Person));//Sen önce burada hangi section ile çalışacağını bildir ardından Get üzerinden ilgili section bir objeyse value olarak bir string dönmeyecekse bunu Get olarak belirli bir türde elde edebilirsin.
            var v9 = _configuration.GetSection("Person:Name").Get(typeof(String));
            #endregion
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

//**************************** appsettings.json ****************************
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  //************************* appsettings.json'a Veri Ekleme *************************
  "OrnekMetin": "sebepsiz boş yere ayrılacaksan...", //Sistemde anlamlı bir konfigürasyon olacatır. Nihayetinde sen bunu sistemde erişip kullanacak halde tanımlamış oldun.
  "Person": {
    "Name": "Musa",
    "Surname": "Uyumaz"
  }
  //**************************************************
}

//**************************** Program.cs ****************************
var builder = WebApplication.CreateBuilder(args);

#region appsettings.json Dosyasının Asp.NET Core Uygulamasındaki Davranışı 
builder.Configuration.AddJsonFile("hilmi.json");
#endregion

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

//**************************** Person ****************************
namespace ConfigurationExample.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
```