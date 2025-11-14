# FilmListe 🎥

Film listesi yönetimi ve LINQ filtreleme projesi.

## 📋 Proje Açıklaması

Film listesi oluşturup IMDB puanına göre filtreleme yapan pratik çalışma. Custom class ve LINQ kullanımı içerir.

## 🚀 Teknolojiler

- **C# Console Application**
- **List<T>** - Generic koleksiyonlar
- **LINQ Where**
- **Custom Classes**

## 🎯 Özellikler

- ✅ Film listesi oluşturma
- ✅ IMDB puanına göre filtreleme
- ✅ LINQ Where kullanımı
- ✅ Custom class (Movie)
- ✅ Lambda expressions

## 📊 Film Yapısı

```csharp
public class Movie
{
    public string Name { get; set; }
    public double ImdbScore { get; set; }
}
```

## 🎬 Örnek Filtreleme

```csharp
// IMDB puanı 4 ile 9 arası filmler
var filtered = movies.Where(m => m.ImdbScore >= 4 && m.ImdbScore <= 9);
```

## ⚙️ Çalıştırma

```bash
cd FilmListe
dotnet restore
dotnet run --project FilmListe/FilmListe.csproj
```

## 📚 Öğrenilen Konular

- List<T> koleksiyonu
- LINQ Where filtreleme
- Custom class tanımlama
- Lambda expressions
- Property kullanımı
