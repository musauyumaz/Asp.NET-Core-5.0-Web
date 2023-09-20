using MiddlewareExample.Middlewares;

namespace MiddlewareExample.Extensions
{
    static public class Extension//Extension fonksiyonların hangi sınıfta bulundukları önemli değildir.
    {
        public static IApplicationBuilder UseHello(this IApplicationBuilder applicationBuilder)//Hangi middleware'e bakarsanız bakın geriye genellikle IApplicationBuilder döndürür. Standart bu şekildedir.Adam diyor ki ben middleware'i eklediğim `IApplicationBuilder` neyse ben onu geri döndürüyorum ki sen istiyorsan fluent bir çalışma yapabil. Yani noktalarla .. diyerek middleware'leri ekleyebil diyor. Çalışılabilir formatta middleware geriye döndürüyor ki böyle bir standartımız var. İstersen başka bişey de döndürebilirsin burada.
        {
            return applicationBuilder.UseMiddleware<HelloMiddleware>();
        }
    }
}
