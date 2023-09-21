using DependencyInjection.Services.Interfaces;

namespace DependencyInjection.Services
{
    public class ConsoleLog : ILog
    {
        public ConsoleLog(int a)
        {
            
        }
        public void Log() 
        {
            Console.WriteLine("Console loglama işlemi gerçekleştirildi....");
        }
    }
}
