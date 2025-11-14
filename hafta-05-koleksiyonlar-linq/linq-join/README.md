# LINQJOIN 🔗

LINQ Join işlemleri pratik projesi.

## 📋 Proje Açıklaması

Yazar ve kitap listeleri üzerinde LINQ Join işlemlerini uygulayan pratik çalışma. İki ayrı listeyi ilişkilendirerek birleştirme işlemleri yapılır.

## 🚀 Teknolojiler

- **C# Console Application**
- **LINQ Join** - Liste birleştirme
- **Lambda Expressions**
- **Anonymous Types**

## 🎯 LINQ Join Kullanımı

### Method Syntax
```csharp
var result = authors.Join(
    books,
    author => author.AuthorId,
    book => book.AuthorId,
    (author, book) => new {
        BookName = book.Title,
        AuthorName = author.Name
    }
);
```

### Query Syntax
```csharp
var result = from author in authors
             join book in books on author.AuthorId equals book.AuthorId
             select new {
                 BookName = book.Title,
                 AuthorName = author.Name
             };
```

## 📊 Örnek Çıktı

```
Kitap: Masumiyet Müzesi, Yazar: Orhan Pamuk
Kitap: Aşk, Yazar: Elif Şafak
Kitap: Beyoğlu Rapsodisi, Yazar: Ahmet Ümit
```

## ⚙️ Çalıştırma

```bash
cd LINQJOIN
dotnet restore
dotnet run --project LINQJOIN/LINQJOIN.csproj
```

## 📚 Öğrenilen Konular

- LINQ Join operations
- Method syntax vs Query syntax
- Anonymous types
- Lambda expressions
- Inner join kavramı
- Foreign key relationships
