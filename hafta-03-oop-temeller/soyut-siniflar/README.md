# Soyutlar 🎭

Abstract (Soyut) sınıflar pratik projesi.

## 📋 Proje Açıklaması

OOP'de abstract class (soyut sınıf) kavramını öğreten pratik çalışma. Soyut sınıflar ve metod uygulamaları.

## 🚀 Teknolojiler

- **C# Console Application**
- **Abstract Classes**
- **Abstract Methods**
- **Method Override**
- **OOP Principles**

## 🎯 Abstract Class Kavramı

### Soyut Sınıf
```csharp
public abstract class Sekil
{
    // Abstract method - implement edilmeli
    public abstract double AlanHesapla();
    
    // Normal method - isteğe bağlı override
    public virtual void Bilgi()
    {
        Console.WriteLine("Şekil bilgisi");
    }
}
```

### Türetilmiş Sınıf
```csharp
public class Daire : Sekil
{
    public double Yaricap { get; set; }
    
    // Abstract method implement edilmeli
    public override double AlanHesapla()
    {
        return Math.PI * Yaricap * Yaricap;
    }
}
```

## 📊 Abstract vs Interface

| Abstract Class | Interface |
|---------------|----------|
| Partial implementation | No implementation |
| Single inheritance | Multiple inheritance |
| Fields allowed | Only properties |
| Access modifiers | All public |

## 🎯 Özellikler

- ✅ Abstract class tanımlama
- ✅ Abstract method
- ✅ Virtual method
- ✅ Method overriding
- ✅ Cannot instantiate abstract class

## ⚙️ Çalıştırma

```bash
cd Soyutlar
dotnet restore
dotnet run --project Soyutlar/Soyutlar.csproj
```

## 📚 Öğrenilen Konular

- Abstract classes
- Abstract methods
- Method overriding
- Virtual methods
- OOP abstraction
- Cannot instantiate abstract types
- Partial vs full implementation
