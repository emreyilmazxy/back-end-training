# Kütüphane Kitap Takip Uygulaması

Bu proje, C# dilinde yazılmış basit bir kitap takip uygulamasıdır. Uygulama, kitap bilgilerini bir `Books` sınıfı aracılığıyla tutar ve bu sınıf içinde kapsülleme (encapsulation), property kullanımı, parametreli ve parametresiz constructor örnekleri barındırır.

## Özellikler

- Kitap ismi, yazar adı ve soyadı, sayfa sayısı, yayınevi gibi bilgileri saklar.
- Kitabın eklendiği tarihi otomatik olarak bugünün tarihiyle kaydeder.
- Hem parametreli hem de parametresiz constructor kullanımı mevcuttur.
- `Books` sınıfı içerisinde tüm alanlara erişim `property`ler aracılığıyla sağlanır.

## Sınıf Özeti: `Books`

### Alanlar:
- `BookName`: Kitap ismi
- `Name`: Yazar adı
- `Surname`: Yazar soyadı
- `PageNumber`: Sayfa sayısı
- `Publisher`: Yayınevi
- `EntryDate`: Sisteme giriş tarihi

### Constructorlar:
- `Books()` – Parametresiz constructor, `EntryDate`'i bugünün tarihi olarak ayarlar.
- `Books(string _bookName, string _name, string _surname, string _pageNumber, string _publisher)` – Kitap bilgilerini baştan tanımlamak için parametreli constructor.

## Örnek Kullanım

```csharp
Books book1 = new Books();
book1.bookName = "İnsanın Anlam Arayışı";
book1.name = "Viktor";
book1.surname = "Frankl";
book1.pageNumber = "170";
book1.publisher = "İş Bankası Yayınları";

Books book2 = new Books("Sevme Sanatı", "Erik", "Fromm", "200", "Say Yayınları");


Bu uygulamayı çalıştırmak için Visual Studio ya da herhangi bir C# IDE'si kullanabilirsiniz.

dotnet run
