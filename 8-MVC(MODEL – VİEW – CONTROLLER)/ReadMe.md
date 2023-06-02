---
modified: 2023-06-02T13:59:43.680Z
title: 13) Asp.NET Core 5.0 - MVC Nedir? Asp.NET Core MVC Pipeline'ı Nasıldır?
---
***
# 13) Asp.NET Core 5.0 - MVC Nedir? Asp.NET Core MVC Pipeline'ı Nasıldır?
<img src="1.png" width="auto">

- MVC, birbirinden bağımsız üç katmanı esas alan bir Mimarisel Desen(Architectural Pattern)'dir.

- Özünde Observer, Decorator gibi design pattern'ları kullanan bir mimarisel desendir.

- Microsoft bu desen üzerine oturtulmuş Asp.NET Core MVC mimarisini geliştirmiştir.

- Mimarisel desen design pattern'lardan daha kapsamlıdır diyebiliriz. İçerisinde bir veya birden fazla design pattern'ın kullanıldığı ve belirli bir mimarinin oturtulduğu desenlerdir. Daha geniş kapsamlıdır.

- Design pattern dediğimiz tasarım desenleri belirli senaryolara uygun yerleştirilirken mimarisel desenler ise genel yaklaşımımızı belirlerler.

- Mimari desenler içerisinde bir veya birden daha fazla tasarım deseni barındıran desenlerdir.

<img src="2.png" width="auto">

- Model : İşlenecek olan veriyi temsil eden katmandır. Genellikle veritabanı işlemlerinin yapıldığı katmandır.
    * Entity Framework Core, Entity Models, Ado.NET, Repository, Veritabanı İşlemleri
    * Model web'de de çalışsan herhangi bir platformda da çalışsan işlenecek olan veriyi temsil eden bir katman.
    * Veri ile alakalı bütün mevzuların hepsi Model katmanında tutulacak işlemler yapılacaktır.


- View :  İstek neticesinde elde edilen verileri görselleştirecek, görsel çıktısını verecek katmandır.
    * HTML, CSS, JavaScript, Razor, Resim, Müzik, Video
    * Sunum katmanıdır.

- Controller : Gelen request'leri karşılayacak olan ve request'in içeriğine göre gerekli model işlemlerini üstlenecek olan katmandır. Algoritmaları, servisleri, veritabanını'ı vs. çağırarak/çalıştırarak/sorgulayarak istenilen veriyi üretmekten ve ihtiyaç dahilinde üretilen bu veriyi View ile görselleştirmekten sorumludur. İstek neticesinde elde edilen ve işlenen veriyi tekrar client'a response olarak döndürür.
    * Controller her daim gelen istekleri karşılayacaktır. Dolayısıyla gelen istekleri karşıladıktan sonra isteğin mahiyetine uygun veri işlemlerini yapacak.
    * Verinin üretiminden sorumludur.
    * Verinin görselleştirilip görselleştirilmeme sorumluluğu da controller'dadır.

- Yapacağın işleme göre barındıracağın veri yapılarını ya da işlemleri belirli algoritmaları vs yapacağın işlemleri kategorize ediyorsun örneğin model'da model'la ilgili işlemler barındırılırken view'da adı üzerinde görsel/sunumla alakalı işlemler yapılıyor. Controller'da ise bunları kontrol etmek yani belirli şeyleri organize etmek. MVC tasarım deseni temelde yapısal olarak bir kodun işlenme sürecinde bunun sunulmasını bunun üretilmesini değer üretilme sürecini yahut yönetilmesini birbirlerinden soyutlamamız gerekiyor. Belirli başlıklar altında işte MVC ile biz bunları birbirinden soyutluyoruz.

- MVC illa ki web'te uygulanan bir tasarım deseni değildir. MVC'yi herhangi bir programda/platformda herhangi bir programlama dilinde de kullanabilirsiniz.

- Veri MVC'de temsil edilen ayrı bir katmanda işlenen ayrı bir katman olarak nitelendirilen bir değer/olgu. 

<img src="3.png" width="auto">

- User'ımız client'ı üzerinden bir istekte bulunuyor. Bu istek neticesinde controller gelen isteğin mahiyetine bakıyor eğer ki bu istekte bir veritabanı ihtiyacı varsa veriler dış kaynaktan alınacaksa yahut bir model kullanılacaksa model katmanına gider. Model'a diyor ki ya kardeşim bana şöyle şöyle veriler lazım bu veriler sende bunları bana üret gönder. Model'da ilgili verileri üretiyor tekrardan controller'a gönderiyor. Controller verileri aldıktan sonra Eğer ki bu verileri View katmanına gönderip belirli bir görsellik işlemi yapacaksa View katmanına gönderiyor. Yani ihtiyaç doğrultusuna View'a gitti. Belirli bir giyinim yaptık belirli bir görsellik sunum hazırlandı ilgili veriler daha da anlamlı hale getirildi vs. Yeniden controller'a bu veriler döndürüldü. Model'a gider. Model'dan geri controller'a gelen veriler tekrardan View'e gönderilir. View'den geri controller'a getirilir. View'den gelen sonuç tekrardan controller'dadır. Controller'da elde edilen sonuçlar tekrardan client'a gönderilecektir. Artık veri hazırdır çünkü.

- Controller kontrol edendir komutandır. Gelen isteği kontrol ediyor. Dolayısıyla bir zorunluluğu yok. Controller hiçbir zaman View'a ve Model'a gitmek zorunda değildir.

<img src="4.png" width="auto">

- Client isteği yaptı kampanyalı ürünler diye Controller katmanı senin yapmış olduğun bu isteği karşılayacaktır. Controller diyor ki kampanyalı ürünler nerde? veritabanında o zaman Model'la işimiz var. O zaman gidiyor Model'a ya kardeşim sen bana bir kampanyalı ürünleri ver. Çünkü bu herif kampanyalı ürünleri istiyor. Dolayısıyla Model bize ilgili veriyi üretiyor. Al buyur kampanyalı ürünlerimiz bunlar haliyle üretilen veriyi tekrardan controller'a gönderiyor. Controller diyor ki bak View benim elimde böyle bir veri var sen bu veriyi bir al bunu bir adam et/şekillendir/makyajını yap ondan sonra bana geri gönder. View veriyi alıyor gerekli işlemleri yapıyor ardından Controller'a geri gönderiyor. Biz bu işleme render diyeceğiz. View ilgili dataları render ediyor. Burada razor teknolojisini vs. kullanabiliyoruz. Render edilen sonuçtan ViewResult dediğimiz bir sonuç üretiliyor. Üretilen bu sonuç sana gelen sonuçta ViewResult'ta View'ın result'u yani sunumunun sonucu. İçinde senin gönderdiğin değerlerinin HTML, CSS'le, Javascript'le Razor'la artık neyse render edilip çıktısı verilmiş bir result olarak sana sunuluyor. Gelen sonuç artık tam olarak ideal veri elimizde mi elimizde. Bu verileri sana bu şekilde getirmiş olacaktır.

<img src="5.png" width="auto">

- Request geldi senin sunucun bunu karşılayacak. 
    1. Kestrel örneğin karşılayacak. 
    2. Önce Middleware dediğimiz yapılar devreye giriyor. Sonra buradaki yazılımların alayı geçecek bu mevzudan. 
    3. Geçtikten sonra routing dediğimiz bir modül/middleware/ara yazılım var. Routing'de gerekli route işlemleri/endpointler vs falan bunlar ayıklanacak.
        * Request'in hangi endpointi o isteği ayıracak hangi alana istek yapıldığını burada ayırır. Biz buna endpoint diyeceğiz.
        * Yani belirli bir link üzerinden yapılacak bu istek yapılan bu isteğin binlerce controller'ın binlerce istek alanının Action method diyeceğiz biz onlara. Bunların arasından hangisine yapıldığını kampanyalı ürün de var bir yandan en çok satan ürün de var hangisine yapıldığını işte burada ayırt eder. 
        * Rotayı burada belirliyor yani gelen istek hangi istek yani mahiyeti ne? neyi istiyor?
        * Burada gelen isteğin mahiyeti anlaşılıyor.
    4. Anlaşıldıktan sonra ilgili Controller ayağa kaldırılır. Kontrol edici var dı ya MVC'nin C boyutu burada devreye giriyor. Controller isteği karşıladı.
        * Senin yapmış olduğun istek neticesinde işlem yapacağın controller ayağa kaldırılır hepsi değil!
        * Ardından bu Controller'ın içerisinde Action dediğimiz metotlar var. Controller bizim için sınıftır. Bu Action'larda bir metot olacak.
    5. Controller ayağa kalktı bu controller'ın içerisinde senin isteğine gerçekten cevap verecek olan oradaki aksiyonu olması gerektiği gibi alacak olan Action metodları var. 
        * Action metot ilgili operasyonu gerçekleştirecek gerekli model'la bağlanacak gerekirse View'e gönderecek vs.
    6. Burada sonuç üretilecek yani model'dan gittin sen model'a bağlandın model'dan ilgili verileri aldın ya da kendin ürettin ya da uzaktan bir servisten aldın vs. Action metot tetiklendikten sonra ilgili veri üretilecek üretilen veri ya direkt client'a gönderilecek ya da View'e gönderilecek View'de render edilecek burada render edilen view'ın sonucunda ViewResult elde edeceksiniz bunu da client'a gönderecek. Ya direkt gönderebilirsin data result olarak ya da viewresult olarak gönderebilirsin. Ya da hiçbişey göndermeyebilirsin. İsteği alırsın başarılı bir şekilde sonlandıradabilirsin.

<img src="6.png" width="auto">