# opsiyonal pratik 💸

İndirim hesaplama metodları pratik projesi.

## 📋 Proje Açıklaması

Farklı indirim yüzdeleri için hesaplama metodları içeren opsiyonel pratik çalışma.

## 🚀 Teknolojiler

- **C# Console Application**
- **Methods**
- **Parameters**
- **Return values**
- **Mathematical operations**

## 💰 İndirim Hesaplama

```csharp
static double IndirimliFiyat(double fiyat, double indirimYuzdesi)
{
    double indirim = fiyat * (indirimYuzdesi / 100);
    return fiyat - indirim;
}

// Kullanım
double yeniFiyat = IndirimliFiyat(1000, 20); // %20 indirim
```

## 🎯 Özellikler

- ✅ İndirim hesaplama metodları
- ✅ Farklı yüzde oranları
- ✅ Return değerli metodlar
- ✅ Matematiksel işlemler

## ⚙️ Çalıştırma

```bash
cd "opsiyonal pratik"
dotnet restore
dotnet run --project "öylesine pratik/öylesine pratik.csproj"
```

## 📚 Öğrenilen Konular

- Method creation
- Parameters
- Return values
- Mathematical calculations
- Percentage operations
