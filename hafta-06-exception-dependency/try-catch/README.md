# trtcatch ⚠️

Exception Handling (Hata Yakalama) pratik projesi.

## 📋 Proje Açıklaması

C# dilinde hata yakalama ve yönetimi (Exception Handling) konusunu öğreten pratik çalışma. Try-catch-finally blokları ve özel exception'lar kullanılır.

## 🚀 Teknolojiler

- **C# Console Application**
- **Try-Catch-Finally**
- **Exception Handling**
- **Custom Exceptions**
- **Error Management**

## 🎯 Kapsanan Exception Türleri

### Built-in Exceptions
- **DivideByZeroException** - Sıfıra bölme hatası
- **FormatException** - Format dönüşüm hatası
- **IndexOutOfRangeException** - Dizi sınır aşımı
- **NullReferenceException** - Null referans hatası
- **InvalidOperationException** - Geçersiz işlem

### Custom Exceptions
- Kendi exception sınıflarınızı tanımlama
- Özel hata mesajları

## 📊 Try-Catch Yapısı

```csharp
try
{
    // Hata oluşabilecek kod
    int result = 10 / 0;
}
catch (DivideByZeroException ex)
{
    // Özel hata yakalama
    Console.WriteLine("Sıfıra bölme hatası!");
}
catch (Exception ex)
{
    // Genel hata yakalama
    Console.WriteLine($"Hata: {ex.Message}");
}
finally
{
    // Her durumda çalışacak kod
    Console.WriteLine("İşlem tamamlandı.");
}
```

## 🎯 Özellikler

- ✅ Try-catch-finally blokları
- ✅ Birden fazla catch bloğu
- ✅ Exception properties (Message, StackTrace)
- ✅ Custom exception tanımlama
- ✅ Exception throwing
- ✅ Error logging

## ⚙️ Çalıştırma

```bash
cd trtcatch
dotnet restore
dotnet run --project trycatcth/trycatcth.csproj
```

## 💡 Best Practices

- ✅ Spesifik exception'ları önce yakala
- ✅ Generic Exception'ı en sona bırak
- ✅ Finally bloğunda cleanup işlemleri yap
- ✅ Exception message'ları kullanıcı dostu yap
- ✅ Log exceptions for debugging

## 📚 Öğrenilen Konular

- Try-Catch-Finally yapısı
- Exception türleri
- Custom exception oluşturma
- Exception properties
- Error handling strategies
- Finally bloğu kullanımı
- Throw ve Throw ex farkı
