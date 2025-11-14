# kutuphaneodevi 📚

Kütüphane kitap yönetimi class örneği.

## 📋 Proje Açıklaması

Basit bir kütüphane sistemi için Book (Kitap) sınıfı oluşturma pratiği. Class yapısı, constructor ve property kullanımını öğreten temel OOP örneği.

## 🚀 Teknolojiler

- **C# Console Application**
- **Class ve Object**
- **Constructor**
- **Properties**
- **Encapsulation**

## 📚 Book Class Yapısı

```csharp
public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int PageCount { get; set; }
    public string Publisher { get; set; }
    public DateTime PublishDate { get; set; }
    
    // Constructor
    public Book(string title, string author)
    {
        Title = title;
        Author = author;
        PublishDate = DateTime.Now;
    }
}
```

## 🎯 Özellikler

- ✅ Book class tanımı
- ✅ Properties (Title, Author, PageCount)
- ✅ Constructor ile nesne oluşturma
- ✅ Otomatik tarih atama
- ✅ Kitap bilgilerini yazdırma

## ⚙️ Çalıştırma

```bash
cd kutuphaneodevi
dotnet restore
dotnet run --project kutuphane/kutuphane.csproj
```

## 📊 Kullanım Örneği

```csharp
Book book1 = new Book("Suç ve Ceza", "Dostoyevski");
book1.PageCount = 700;
book1.Publisher = "İş Bankası Yayınları";
```

## 📚 Öğrenilen Konular

- Class tanımlama
- Constructor kullanımı
- Auto-implemented properties
- Object initialization
- Encapsulation basics
- DateTime kullanımı
