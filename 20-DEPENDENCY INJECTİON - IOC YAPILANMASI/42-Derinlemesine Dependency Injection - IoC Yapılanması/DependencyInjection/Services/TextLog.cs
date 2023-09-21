using DependencyInjection.Services.Interfaces;

namespace DependencyInjection.Services
{
    public class TextLog : ILog
    {
        public void Log()
        {
            Console.WriteLine("Text dosyasına loglama işlemi gerçekleştirildi....");
        }
    }
}
