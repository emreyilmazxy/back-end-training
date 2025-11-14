# Tatil Planlayıcı (C# Konsol Uygulaması)

Bu uygulama, kullanıcıya basit bir şekilde tatil planı yaptırmayı sağlayan bir C# konsol programıdır. Kullanıcı, gitmek istediği şehri, kişi sayısını ve ulaşım şeklini seçerek toplam maliyeti görebilir.

## Özellikler

- Kullanıcıdan şehir seçimi alınır (Bodrum, Marmaris, Çeşme).
- Geçersiz şehir girişi kontrolü yapılır.
- Kaç kişiyle tatil yapılacağı bilgisi istenir ve yalnızca pozitif sayılar kabul edilir.
- Ulaşım yöntemi seçtirilir (Kara Yolu veya Hava Yolu).
- Girişlerin geçerliliği kontrol edilir.
- Şehir ve ulaşım fiyatları toplanarak kişi sayısı ile çarpılır ve toplam maliyet hesaplanır.
- Kullanıcıya tekrar tatil planlamak isteyip istemediği sorulur.

## Kullanılan Teknikler

- `while`, `do-while` döngüleri
- `switch-case` yapısı
- `if-else` ile koşul kontrolü
- `int.TryParse()` ile güvenli kullanıcı girişi
- String temizleme işlemleri: `ToLower()`, `Trim()`

## Örnek Çalışma


## Gereksinimler

- .NET SDK (örneğin .NET 6 veya .NET 7)
- Bir C# derleyicisi (Visual Studio, Visual Studio Code, Rider vs.)

## Çalıştırma

```bash
dotnet run
