# kimMilyoner 💰

Kim Milyoner Olmak İster yarışma oyunu konsol uygulaması.

## 📋 Proje Açıklaması

"Kim Milyoner Olmak İster" yarışmasından esinlenilmiş interaktif soru-cevap oyunu. 3 soru sorulur ve doğru cevaplar verilirse 1 milyon TL kazanılır.

## 🚀 Teknolojiler

- **C# Console Application**
- **if-else yapısı**
- **Counter logic**
- **String manipulation (ToLower, Trim)**
- **Input validation**

## 🎯 Oyun Kuralları

- 🎲 **3 soru** sorulur
- ✅ En az **2 doğru cevap** gerekir
- 💰 2 veya daha fazla doğru cevap = **1 Milyon TL**
- ❌ 2 yanlış cevap = Oyun biter

## 📊 Sorular

1. **Kızınca tüküren hayvan hangisidir?**
   - A) Lama
   - B) Deve

2. **Dünya'ya en yakın gezegen hangisidir?**
   - A) Mars
   - B) Merkür

3. **5 * 2 + 8 / 2 - 2 işleminin sonucu kaçtır?**
   - A) 7
   - B) 12

## ⚙️ Çalıştırma

```bash
cd kimMilyoner
dotnet restore
dotnet run --project kim_milyoner/kim_milyoner.csproj
```

## 🎮 Özellikler

- ✅ Case-insensitive cevap kabul eder ("lama", "LAMA", "Lama")
- ✅ Harf veya şık numarası ile cevap verilebilir
- ✅ Counter sistemi ile puan takibi
- ✅ Erken çıkış (2 yanlış = oyun biter)
- ✅ Input validation (Trim ile boşluk temizleme)

## 📚 Öğrenilen Konular

- Nested if-else yapıları
- Counter mantığı
- String methods (ToLower, Trim)
- Early return
- Input validation
- Boolean logic
