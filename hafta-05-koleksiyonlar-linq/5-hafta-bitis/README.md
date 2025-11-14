# 5weekFinish 🚗

5. hafta OOP pratikleri - Araba üretim sistemi.

## 📋 Proje Açıklaması

5. hafta OOP konseptlerini içeren araba üretim sistemi. List yönetimi, validation ve goto/label kullanımı.

## 🚀 Teknolojiler

- **C# Console Application**
- **OOP Principles**
- **List<T>**
- **Validation**
- **goto/label**

## 🚗 Araba Sınıfı

```csharp
public class Araba
{
    public DateTime UretimTarihi { get; set; }
    public string SeriNumarasi { get; set; }
    public string Marka { get; set; }
    public string Model { get; set; }
    public string Renk { get; set; }
    public int KapiSayisi { get; set; }
}
```

## 🎯 Özellikler

- ✅ Araba üretimi
- ✅ List yönetimi
- ✅ Üretim devam/bitirme
- ✅ Validation kontrolleri
- ✅ Seri numarası atama
- ✅ goto/label kullanımı

## 📊 Program Akışı

1. Araba bilgilerini al
2. Listeye ekle
3. Devam etmek istiyor mu?
4. Evet ise tekrar üret
5. Hayır ise listeyi göster

## ⚙️ Çalıştırma

```bash
cd 5weekFinish
dotnet restore
dotnet run --project 5weekClosed/5weekClosed.csproj
```

## 📚 Öğrenilen Konular

- OOP class design
- List<T> operations
- User interaction loops
- goto and label
- Input validation
- Auto-generated values
