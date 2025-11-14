# tekrarkütüphane 📚

Kütüphane yönetim sistemi MVC tekrar projesi.

## 📋 Proje Açıklaması

ASP.NET Core MVC ile kütüphane yönetim sistemi. Yazar ve kitap yönetimi için MVC pattern uygulanması tekrar projesi.

## 🚀 Teknolojiler

- **ASP.NET Core MVC**
- **Razor Views**
- **Controllers**
- **Models**

## 📁 Controller'lar

- **AuthorController** - Yazar yönetimi
- **BookController** - Kitap yönetimi
- **HomeController** - Ana sayfa

## 📊 Model Yapısı

```csharp
public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
}

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; }
}
```

## 🎯 Özellikler

- ✅ Yazar CRUD işlemleri
- ✅ Kitap CRUD işlemleri
- ✅ MVC pattern
- ✅ Razor views
- ✅ Controller actions

## ⚙️ Çalıştırma

```bash
cd tekrarkütüphane
dotnet restore
dotnet run --project tekrarkütüphane/tekrarkütüphane.csproj
```

## 📚 Öğrenilen Konular

- MVC Pattern
- Multiple controllers
- Razor view engine
- Model binding
- Navigation between views
- MVC routing
