***
# 19) Asp.NET Core 5.0 - Razor Nedir? Kullanım Durumları Nelerdir?
- Varolan bir programlama dilini farklı bir ortamda kullanmamızı sağlayan bir sözdizimidir.

- Razor ASP.NET Core MVC mimarisinde .cshtml dosyasında C# kodları yazabilmemizi sağlayan ve bu kodları Server'da çalışmamızı sağlayan bir teknolojidir.

- Razor Nedir? : Asp.NET Core MVC mimarisinde .cshtml uzantılı dosyalarda HTML ile birlikte yazılan C# kodlarının server tarafında çalıştırılmasını sağlayan bir teknolojidir.

- Razor aynı zamanda Blazor'da da kullanılmaktadır. Aynı zamanda Razor Pages mimarisinde de kullanılmaktadır.

- UI tabanlı çalışmalarda C#'ı kullanmamızı sağlayan teknolojidir.

- `@` Operatörü : `@` Operatörü razor operatörüdür.

- Razor'da yorum satırı `@**@` şeklindedir.

- Bir sayfa üzerinde sizin birden fazla tanımlamış olduğunu Razor scope'u esasında derlendiği zaman bunların hepsi tek bir scope olarak nitelendiriliyor.

- cshtml'de varolan HTML kodlarımızı javascript'e vs. ihtiyaç duymaksızın server tarafında C#'ta hızlı bir şekilde derleyebilmek render edebilmek için kullanılan bir teknolojidir Razor teknolojisi. 

- Eğer bir yapılanma konseptliyse onun konseptine razor'ı bağlayabilirsin ekstradan bir scope oluşturmana gerek yok.

```C#
@* Razor Nedir? : Asp.NET Core MVC mimarisinde .cshtml uzantulı dosyalarda HTML ile birlikte yazılan C# kodlarının server tarafında çalıştırılmasını sağlayan bir teknolojidir.*@
@* @ Operatörü : @ Operatörü razor operatörüdür.*@
@* Razor İle Değişken Oluşturma *@

@{
    string metin = "aasfsafsasad";
}
@* Razor İle Değişken Okuma *@

@{
    int a = 5;
    Console.WriteLine(a);
}

@* Razor İle Parçalı Scope Yapısı *@

@{
    metin = "assad";
}

@* Razor İçerisinde HTML Kullanımı *@
@{
    <div></div>
}

@* Razor İçerisinde <text> Etiketi *@
@{
    if (true)
    {
        <text>Evet</text>
    }else
    {
        <text>Hayır</text>
    }
}

@* Razor İle Tek Satırlık İşlemler *@
@* Sayısal İşlemler *@
<h3>@(5+4)</h3>
<h3>@metin</h3>
<h3>@(metin)</h3>
@* Ternary Operatörü *@
<h3>@(33 % 5 == 3 ? "Evet" : "Hayır")</h3>

@* Koşul Yapıları *@


@{
    int sayi = 5;
}
    @if (sayi == 5)
    {
        <h3>afsadasdsada</h3>
    }else
    {
        
    }


@* Döngüler *@
@foreach (var item in collection)
{
    
}
@for (int i = 0; i < length; i++)
{
    
}

@try
{

}
catch (Exception)
{
    
    throw;
}

<!--@*YORUM SATIRI*@-->
```
