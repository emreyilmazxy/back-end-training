# Patikafy

Bu C# konsol uygulaması, belirli şarkıcı verileri üzerinde LINQ sorguları yaparak çeşitli filtreleme ve sıralama işlemlerini gerçekleştirmektedir.

## 🔍 Uygulama İçeriği

Uygulama aşağıdaki işlemleri yapar:

- **Adı 'S' ile başlayan şarkıcıları listeler.**
- **Albüm satışı 10 milyonun üzerinde olan şarkıcıları gösterir.**
- **2000 yılı öncesi çıkış yapmış ve sadece Pop türünde müzik yapan şarkıcıları çıkış yılına göre gruplayarak, alfabetik sıralı şekilde listeler.**
- **Albüm satışı en yüksek olan sanatçıyı bulur ve ekrana yazdırır.**
- **En yeni ve en eski çıkış yılına sahip sanatçıları listeler.**

## 🛠️ Kullanılan Teknolojiler

- .NET Core / .NET Framework
- C#
- LINQ (Language Integrated Query)
- Konsol uygulaması

## 🚀 Başlamak için

Projeyi çalıştırmak için Visual Studio ya da herhangi bir C# destekleyen editörde `Program.cs` dosyasını açarak çalıştırabilirsiniz.

## 📁 Dosya Yapısı

- `Program.cs`: Ana program dosyası, tüm işlemler burada yapılır.
- `Artist`: Şarkıcı bilgilerini tutan veri modeli.

## 👨‍🎤 Şarkıcı Bilgileri

Uygulamada örnek olarak 11 farklı şarkıcının adı, soyadı, müzik türü, çıkış yılı ve albüm satışları girilmiştir.

## 📌 Notlar

- `StartsWith`, `Where`, `GroupBy`, `OrderBy`, `FirstOrDefault`, `Max`, `Min` gibi LINQ metodları yoğun olarak kullanılmıştır.
- LINQ pratikleri yapmak isteyenler için faydalı bir örnektir.

---

*Bu uygulama eğitim ve pratik amaçlı hazırlanmıştır.*
