# absinterfacepratik 🔶

Abstract class ve Interface karşılaştırma pratik projesi.

## 📋 Proje Açıklaması

Abstract sınıflar ve interface'ler arasındaki farkları öğreten ve karşılaştıran pratik çalışma.

## 🚀 Teknolojiler

- **C# Console Application**
- **Abstract Classes**
- **Interfaces**
- **OOP Principles**

## 🔷 Abstract Class vs Interface

### Abstract Class Örneği
```csharp
public abstract class Hayvan
{
    // Field (abstract class'ta olabilir)
    protected string _ad;
    
    // Constructor
    public Hayvan(string ad)
    {
        _ad = ad;
    }
    
    // Abstract method
    public abstract void SesCikar();
    
    // Normal method (implementation var)
    public void Bilgi()
    {
        Console.WriteLine($"Ad: {_ad}");
    }
}
```

### Interface Örneği
```csharp
public interface IUcabilir
{
    // Sadece imza (no implementation)
    void Uc();
    voidInis();
    
    // Property
    int KanatGenisligi { get; set; }
}

public class Kus : Hayvan, IUcabilir
{
    public int KanatGenisligi { get; set; }
    
    public Kus(string ad) : base(ad) { }
    
    public override void SesCikar()
    {
        Console.WriteLine("Cıv cıv!");
    }
    
    public void Uc()
    {
        Console.WriteLine("Uçuyor...");
    }
    
    public void Iniş()
    {
        Console.WriteLine("İniş yapıyor...");
    }
}
```

## 📊 Temel Farklar

| Özellik | Abstract Class | Interface |
|---------|---------------|----------|
| **Inheritance** | Single | Multiple |
| **Fields** | ✅ Evet | ❌ Hayır |
| **Constructor** | ✅ Evet | ❌ Hayır |
| **Implementation** | Kısmi | Hayır (C# 8.0 öncesi) |
| **Access Modifiers** | Tümü | Public only |

## 🎯 Ne Zaman Kullanılır?

### Abstract Class Kullan
- Ortak kod paylaşımı gerektiğinde
- Field'lara ihtiyaç olduğunda
- Constructor gerektiğinde
- Is-A ilişkisi olduğunda

### Interface Kullan
- Multiple inheritance gerektiğinde
- Sadece contract tanımı istendiğinde
- Farklı sınıflar ortak yetenek paylaştığında
- Can-Do ilişkisi olduğunda

## ⚙️ Çalıştırma

```bash
cd absinterfacepratik
dotnet restore
dotnet run --project absInterfacepratik/absInterfacepratik.csproj
```

## 📚 Öğrenilen Konular

- Abstract classes
- Interfaces
- Abstract vs Interface farkları
- Multiple interface implementation
- Single inheritance limitation
- When to use abstract vs interface
- OOP best practices
