---
modified: 2023-04-18T09:35:49.877Z
title: 5) Asp.NET Core 5.0 - Http Protokolü Nedir? Çalışma Mantığı Nasıldır?
---

# 5) Asp.NET Core 5.0 - Http Protokolü Nedir? Çalışma Mantığı Nasıldır?
<img src="1.png" width="auto">

- User'ımız client'ı kullanarak hosting'teki herhangi bir web sitesine domain aracılığıyla request atıyordu ve bu request neticesinde de response'u alıp response'un içerisinde render edilmiş web sitenin/web uygulamasının result'unu elde edip client'ta görebiliyordu kullanabiliyordu tarayıcı üzerinde ilgili web sitesi açılıyordu.

- Burada client'la server arasında ilişkiyi sağlayabilmesi için bir protokole ihtiyacımız var. Protokol dediğimiz yapılanma iki farklı yapılanmanın ortak buluşmasıdır. 
    * Yani protokol dediğimiz kavram normalde biz Türkler birde Sudanlılar var. İki ülkenin kültürü farklı dili farklı herşeyi farklı ama ortak bir protokolde buluşuyor değil mi bizim devlet büyüklerimiz. Ortak protokolde buluşulmasının sebebi ortak bir kültür oluşturuluyor orada. Ne onlar bizim kültüre geliyor ne biz onların kültürüne gidiyoruz. Ortak bir kültürde yani protokolde buluşuluyor.

- Client farklı bir yapılanma server bambaşka bir yapılanma dolayısıyla client'la server arasındaki ilişkiyi buradaki haberleşmeyi sağlayan model bizim için HTTP protokolüdür. HTTP protokolü client ile server arasındaki haberleşmeyi sağlayan bir protokoldür.
    * Sen normalde bir web uygulaması mı yapacaksın HTTP protokolünü öğren mevzu zaten bitiyor ondan sonra zaten çok fazla derin bir çalışma yapmana gerek yok. Ondan sonra programatik çalışman gerekecek.

- HTTP, client ile server arasındaki ilişkiyi 9 farklı fonksiyonla gerçekleştirir.
    * Get
    * Head
    * Post
    * Put
    * Delete
    * Trace
    * Options
    * Connect
    * Patch
- Bu fonksiyonlar davranışsal olarak yapmak istediğimiz edinmek istediğimiz verilere göre tercih edilen fonksiyonlardır.
    * Örneğin ben kullandığım client üzerinden herhangi bir veriyi ya da verileri elde etmek istiyorsam `Get` fonksiyonuyla ilgili request'i gerçekleştiririm.
    * Benzer mantıkla sunucuya veri göndereceksem `Post` fonksiyonuyla gerçekleştiriyoruz.
    * Sunucudan veri sileceksek `Delete` fonksiyonuyla gerçekleştiriyoruz.
    * Sunucudan herhangi bir veriyi güncelleyeceksek `Put` fonksiyonuyla gerçekleştiriyoruz.

<img src="2.png" width="auto">