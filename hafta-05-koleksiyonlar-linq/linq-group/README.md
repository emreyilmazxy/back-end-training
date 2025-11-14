# LINQGROUP 📊

LINQ GroupJoin işlemleri pratik projesi.

## 📋 Proje Açıklaması

Sınıf ve öğrenci listeleri üzerinde LINQ GroupJoin operasyonunu uygulayan pratik çalışma. Bir-çok (one-to-many) ilişkili verileri gruplandırma.

## 🚀 Teknolojiler

- **C# Console Application**
- **LINQ GroupJoin**
- **Anonymous Types**
- **Lambda Expressions**

## 🎯 GroupJoin Kullanımı

GroupJoin, bir koleksiyonu diğer bir koleksiyonla ilişkilendirerek gruplar halinde birleştirir. SQL'deki LEFT JOIN'e benzer şekilde çalışır.

## 📊 Örnek Veri Yapısı

```csharp
// Sınıflar
public class Sinif { 
    public int SinifId { get; set; }
    public string SinifAdi { get; set; }
}

// Öğrenciler
public class Ogrenci {
    public int OgrenciId { get; set; }
    public string OgrenciAdi { get; set; }
    public int SinifId { get; set; }
}
```

## ⚙️ Çalıştırma

```bash
cd LINQGROUP
dotnet restore
dotnet run --project LINQGROUP/LINQGROUP.csproj
```

## 📚 Öğrenilen Konular

- LINQ GroupJoin operation
- One-to-Many relationships
- Grouping data
- LEFT JOIN equivalent in LINQ
- Anonymous types
- Lambda expressions
