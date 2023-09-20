namespace MiddlewareExample.Middlewares
{
    public class HelloMiddleware
    {
        RequestDelegate _next;
        public HelloMiddleware(RequestDelegate next)// Senden sonraki/bir sonraki next edeceğimiz hani invoke'layacağımız middleware'i sen ilk önce buradan bir karşıla. RequestDelegate olarak. Mimarimiz kendisi bu parametreye değeri verecek. Kendisi HelloMiddleware'in kullanıldığı noktadan sonra gelen middleware varsa eğer next'e otomatik onu kendisi verecektir benim ekstradan bişey yapmama gerek yok. Ama tetikleme işlemini gerçekleştirebilmem için burada operasyonel açıdan şöyle bir yaklaşım belirlemem gerekiyor: Dependency Injection yaparak değeri/diğer middleware'i elde ettim.
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)//Bu middleware'den bir önceki middleware'in bunu tetikleyebilmesi için o middleware'in içerisinde olacak `RequestDelegate`'in temsil edebileceği uygun bir imzada metot bu. Yani bir önceki middleware'deki `RequestDelegate`'in bunu tetikleyebilmesi için o delagete'e uygun bir imza oluşturmuş olduk. Benim CustomMiddleware'imde yapacağım operasyonu burada yapacağım.
        {
            //Custom operasyon...

            await Console.Out.WriteLineAsync("Selamun aleykkkümmmmmm");
            await _next.Invoke(httpContext);//Oluşturmuş olduğumuz middleware içerisinde eğer ki ben bir sonraki metodu/middleware'i invoke etmezsem Short Circuit'e sebep olurum. Burada da bir kısa devre olur. Haliyle ben bir sonrakini invoke ediyorum ki devam etsin. kısa devre olmasın.
            await Console.Out.WriteLineAsync("Aleykümselam...");
        }
    }
}
