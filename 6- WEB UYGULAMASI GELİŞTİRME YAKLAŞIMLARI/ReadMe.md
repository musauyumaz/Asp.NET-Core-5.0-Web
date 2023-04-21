# 9) Asp.NET Core 5.0 - Olay Tabanlı Web Geliştirme Yaklaşımı
- Biz bir web uygulaması geliştirirken geliştirme yaklaşımımıza göre mimariyi şekillendiririz.

- Belirli yaklaşımlar var bu yaklaşımlardan herhangi birini kabul ediyorsun o kabul ettiğin yaklaşıma göre mimarini ona göre kodluyorsun ona göre şekillendiriyorsun ona göre planlamalarını yapıyorsun.

<img src="1.png" width="auto">

- Olay güdümlü programlama veya Olay yönlendirmeli programlama da denmektedir.

- Programın akışını kullanıcı eylemlerine göre yönlendiren programlama yaklaşımıdır.
  * Örneğin  akşam odaya girdin kapkaranlık değil mi? Şimdi ışığın yanması için bir olaya ihtiyacın var nedir bu? Düğmeye basmak. Ben düğmeye bastığım zaman bu olay gerçekleştiği zaman sonuç olarak ışık yanar. Düğmeye basılması bir olayken bu olay neticesinde neticesinde bir iş yapılıyor işte ışığın yanmasıdır. 

- Kullanıcı eylemlerine uygun bir şekilde olaylar tanımlanmıştır. Bu olaylar çalıştırılacak kodu barındırmaktadırlar.

- Uygulama hızlı bir şekilde inşa edilebilir. Lakin bakım ve sonraki gelişim süreci oldukça maliyetli olan bir yaklaşımdır.

- Olay tabanlı yaklaşımda kullanıcının kişinin eylemleri ön plandadır.

- Sende bu programlama yaklaşımında yapacağın işleri belirli eylemlere bağlıyorsun dolayısıyla eylemleri/olayları tanımlıyorsun ardından o olaylar gerçekleştiğinde yapılacaklar işlemler neyse o işlemleri arkada yapıyorsun.

- bakım ve sonraki gelişim süreci oldukça maliyetli olacağından dolayı günümüzde pek fazla mimarisel çalışmalarda tercih etmemekteyiz. Asp.NET'in eski mimarisi olan Web Form mimarisi vardı onun temeli olay tabanlı yaklaşımdı. Hızlı bir şekilde gelişim yapabiliyorduk. Kodlar ve sunum aşaması iç içe olduğundan dolayı ciddi manada bir maliyete sebep oluyordu. Kurumsal bir çalışma yapmamıza müsaade etmiyordu. Bundan dolayı Web Formu tercih etmiyorduk MVC yaklaşımı ya da daha farklı yaklaşımlar tercih ediyoruz.

<img src="2.png" width="auto">

- Olay tabanlı programlamada iki tane aktör vardır.
    * Olay/Event
    * İş/Operasyon

- Butona tıklandığına çıkış yapması;
  - Olay : Butona Tıklanması
  - İş : Çıkış Yapılması

- Düğmeye basıldığında lambanın yanması;
  - Olay : Düğmeye basılması
  - İş : lambanın yanması

- Linke tıklandığında ayın en çok satılan ürünlerin sorgulanması;
  - Olay : Linke tıklamak
  - İş : ayın en çok satılan ürünlerin sorgulanması

- Yani bir olay gerçekleşecek ve olayın neticesinde bir iş yapılacaktır.

<img src="3.png" width="auto">

***
# 10) Asp.NET Core 5.0 - Model - View - Controller(MVC) Yaklaşımı
- MVC pattern'ını kullanan bir yaklaşımdır.

- Üretilen veri ile gösterim yani sunum katmanı arasında bir soyutlama esas alınmıştır.

- MVC pattern'ı Microsoft tarafından üretilmemiştir. Böyle bir yanlış algı vardır.

- MVC, Microsoft'un kurulduğu yıllardan (1979 yılından) beri tasarlanmış bir kalıptır.

- MVC Model, View ve Controller olarak 3 katmandan oluşan stratejiden ibarettir.

- MVC esasında bir framework değildir. MVC esasında bir design pattern.

- Belirli bir senaryoya uygun uygulanabilir tasarım desenidir. Asp.NET bu tasarım deseninin üzerine oturtulmuş bir mimari/framework bize sunmaktadır.

- 3 katmandan oluşur;
  * Model => Veritabanı işlemlerini yaptığımız katman
  * View => Görsellik sunum işlerini yaptığımız katman
  * Controller => Bu süreçte istekleri karşılayan gerekli işlemlerin gerçekleştirildiği Model ile View arasında köprüsel işlemlerin üstlenildiği bir katman.

- Kullanıcı ilgili web sitesine bir istek gönderdiği zaman bu Controller tarafından karşılanır. Eğer ki Controller varsa veritabanı işlemi Model'a gider ilgili veritabanı işlemini yapar elde ettiği ürettiği veriyi View'a gönderir. View'de ilgili veriyi görsel bir şekilde HTML CSS'e çevirecek şekilde basar ve sonucu yeniden User'a döndürür.

- Asp.NET Core yapılanmasında API ile MVC tasarımı birleştirilmiştir yani aynı altyapıda çalıştırılmaktadır.

<img src="4.png" width="auto">