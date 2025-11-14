# vacationapp ✈️

Tatil planlama ve fiyat hesaplama konsol uygulaması.

## 📋 Proje Açıklaması

Kullanıcının tatil lokasyonunu, kişi sayısını ve ulaşım türünü seçerek toplam tatil fiyatını hesaplayan interaktif konsol uygulaması.

## 🚀 Teknolojiler

- **C# Console Application**
- **While döngüsü**
- **Switch-case**
- **Input validation**
- **Fiyat hesaplama**

## 🌍 Tatil Lokasyonları ve Fiyatları

- **Bodrum** - Paket başlangıç fiyatı: 4000 TL
- **Marmaris** - Paket başlangıç fiyatı: 3000 TL
- **Çeşme** - Paket başlangıç fiyatı: 5000 TL

## 🚗 Ulaşım Seçenekleri

1. **Kara yolu** - Ekstra fiyat: 1500 TL
2. **Hava yolu** - Ekstra fiyat: 4000 TL

## 🎯 Özellikler

- ✅ Lokasyon seçimi (Bodrum, Marmaris, Çeşme)
- ✅ Kişi sayısı girişi
- ✅ Ulaşım türü seçimi
- ✅ Otomatik fiyat hesaplama
- ✅ Input validation
- ✅ Yeniden planlama seçeneği

## 💰 Fiyat Hesaplama

```
Toplam Fiyat = (Lokasyon Fiyatı * Kişi Sayısı) + Ulaşım Fiyatı
```

## ⚙️ Çalıştırma

```bash
cd vacationapp
dotnet restore
dotnet run --project vacationapp/vacationapp.csproj
```

## 📊 Örnek Akış

```
1. Lokasyon seç: Bodrum
2. Kişi sayısı: 2
3. Ulaşım: Hava yolu

Toplam = (4000 * 2) + 4000 = 12.000 TL
```

## 📚 Öğrenilen Konular

- While döngüsü kullanımı
- Switch-case yapısı
- Input validation
- String comparison
- Matematiksel hesaplamalar
- User experience (UX) tasarımı
