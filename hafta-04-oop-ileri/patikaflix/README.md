# Patikaflix 🎬

Dizi listesi yönetimi ve LINQ pratik projesi.

## 📋 Proje Açıklaması

Türk dizilerini içeren bir liste oluşturup LINQ ile filtreleme ve sıralama işlemleri yapan pratik çalışma. Komedi türündeki diziler özel olarak filtrelenir.

## 🚀 Teknolojiler

- **C# Console Application**
- **List<T>** - Generic koleksiyonlar
- **LINQ** - Where, OrderBy
- **Custom Classes**

## 🎯 Özellikler

- ✅ Dizi listesi oluşturma
- ✅ LINQ Where ile filtreleme
- ✅ OrderBy ile alfabetik sıralama
- ✅ Komedi türü seçimi
- ✅ Custom class (Dizi) kullanımı

## 📊 Dizi Yapısı

```csharp
public class Dizi
{
    public string Name { get; set; }
    public int Year { get; set; }
    public string Genre { get; set; }
    public int Year2 { get; set; }
}
```

## ⚙️ Çalıştırma

```bash
cd Patikaflix
dotnet restore
dotnet run --project Patikaflix/Patikaflix.csproj
```

## 📚 Öğrenilen Konular

- List<T> koleksiyonu
- LINQ Where clause
- LINQ OrderBy
- Custom class tanımlama
- Lambda expressions
