using DependencyInjection.Services;

namespace DependencyInjection
{
    public class Example
    {
        public Example()
        {
            IServiceCollection services = new ServiceCollection();//.Net mimarisinde IServiceCollection türü dahili/built-in gelen IoC yapılanmasını barındıran bir türdür. O yapılanmanın arayüzüdür.
            // Bu tür Microsoft.Extensions.DependencyInjection namespace'i altından gelmektedir.
            // Bu container'a istediğim değeri ekleyebiliyorum. Sistemden hazır gelen servisleri ekleyebilirsiniz. Servis eklemek demek ilgili servisin sınıflarını kullanılabilir vaziyette mimarinin container'ına eklemek demek. Örneğin sen buradan Cors mu ekliyorsun. Cors politiklarına dair gerekli sınıfların hepsini buradaki mimarinin servisine yani container'ına ekliyorsun ki yarın lazım olursa çağırdığında direkt gelsin diye.
            // Buradaki fonksiyon arka planda bu container'a gerekli eklemelerde bulunuyor.
            // Burada custom/kendimize ait servisleri eklemek için Add() fonksiyonuyla direkt ekleme işlemi yapabilirsiniz. Add'den sonra ismi olanlar özel servisleri belirlerken direkt ne olduğu belli olan servislerken customize edilmiş kendime ait bizzat özel servislerimizi sisteme eklemek için Add() fonksiyonunu kullanabilirsiniz. Bu fonksiyon üzerinden Container'a istediğim herhangi bir sınıfı ekleyebilirim. Kökünde hepsinin Add() fonksiyonu var gibi düşünebilirsiniz.
            // Add() fonksiyonu ile biz esasında .NET mimarisinde gelen hazır dahili IoC mekanizmasının container'ına ilgili nesnelerimizi/değerlerimizi ekleyebiliyoruz.
            

            services.Add(new(typeof(ConsoleLog), new ConsoleLog(5)));
            services.Add(new(typeof(TextLog), new TextLog()));// Property vs. varsa bunların içerisinde koyulacak nesnenin orada ilk oluşturulacak nesnenin hangi değerlerde olması gerektiğini de buradan bildireceksiniz.
            
            ServiceProvider provider = services.BuildServiceProvider(); // Bu container'a eklenmiş değerleri biz bu fonksiyon ile elde edebiliyoruz. Bu bana ilgili container'ı direkt oluşturacaktır. Artık provider/sağlayıcı direkt net/somut bir container verecek.
            provider.GetService<ConsoleLog>();//Generic olarak bildirdiğin türe karşılık gelen nesne herneyse sana onu döndürecektir. 
            provider.GetService<TextLog>();
        }
    }
}
