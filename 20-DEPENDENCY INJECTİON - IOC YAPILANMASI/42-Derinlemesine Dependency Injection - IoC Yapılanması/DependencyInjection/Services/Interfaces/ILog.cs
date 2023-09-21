namespace DependencyInjection.Services.Interfaces
{
    public interface ILog// IoC yapılanmasını kullanırken aynı işi yapan servisleri ortak bir türün altında toplarız niye? Çünkü istediğim zaman istediğimi dahil edeyim istediğimi çağırabileyim istediğimi dışarıdan enjekte edebileyim. Dolayısıyla biz bu tarz çalışmalarda container'a vereceğimiz nesnelere bir ortak interface ile abstraction'a tabi tutarız. O interface üzerinden sisteme dahil ederiz.
    {
        void Log();
    }
}
