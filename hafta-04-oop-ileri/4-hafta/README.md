# 4week 📱

4. hafta OOP pratikleri - Telefon/Laptop üretim sistemi.

## 📋 Proje Açıklaması

4. hafta OOP konseptlerini içeren pratik çalışma. Telefon ve Laptop üretim sistemi üzerinden inheritance, properties ve validation öğrenilir.

## 🚀 Teknolojiler

- **C# Console Application**
- **OOP - Inheritance**
- **Properties**
- **Validation**
- **User Input**

## 🏗️ Sınıf Yapısı

```csharp
public class BaseMakine
{
    public DateTime UretimTarihi { get; set; }
    public string SeriNumarasi { get; set; }
    public string Ad { get; set; }
    public string Aciklama { get; set; }
    public string IsletimSistemi { get; set; }
}

public class Telefon : BaseMakine
{
    public bool TrLisansli { get; set; }
}

public class Bilgisayar : BaseMakine
{
    public int UsbGirisSayisi { get; set; }
    public bool Bluetooth { get; set; }
}
```

## 🎯 Özellikler

- ✅ Ürün üretme (Telefon/Laptop)
- ✅ Inheritance kullanımı
- ✅ Property validation
- ✅ User input handling
- ✅ Otomatik tarih atama

## ⚙️ Çalıştırma

```bash
cd 4week
dotnet restore
dotnet run --project 4week/4week.csproj
```

## 📚 Öğrenilen Konular

- OOP Inheritance
- Properties
- Input validation
- DateTime operations
- Base class usage
- Derived classes
