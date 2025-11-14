# Konsol Tabanlı Çok Fonksiyonlu Uygulama

Bu proje, C# dilinde geliştirilmiş basit bir konsol uygulamasıdır. Uygulama, kullanıcıya üç farklı işlem seçeneği sunar:

1. Rasgele Sayı Tahmin Oyunu  
2. Dört İşlem Yapabilen Hesap Makinesi  
3. Ortalama Hesaplama Aracı

## 🔧 Kullanılan Teknolojiler

- **Dil:** C# (.NET Core/Framework bağımsız sade konsol yapısı)
- **IDE Önerisi:** Visual Studio, Visual Studio Code, JetBrains Rider veya herhangi bir C# destekleyen editör

## 🚀 Uygulama Nasıl Çalışır?

### Başlangıç

1. Uygulama açıldığında kullanıcıdan 1, 2 veya 3 numaralı bir seçenek seçmesi istenir.
2. Kullanıcı aşağıdaki işlemlerden birini seçebilir:

---

### 1. Rasgele Sayı Tahmin Oyunu
- Sistem 1 ile 100 arasında rastgele bir sayı üretir.
- Kullanıcı 5 tahmin hakkıyla bu sayıyı bulmaya çalışır.
- Her tahminde ipucu verilir (daha büyük/küçük).
- Doğru tahmin edilirse oyun kazanılır, 5 hakkı dolarsa kaybedilir.

---

### 2. Hesap Makinesi
- Kullanıcıdan iki sayı alınır.
- Aritmetik işlem seçmesi istenir: toplama (+), çıkarma (-), çarpma (*), bölme (/).
- Bölme işleminde sıfıra bölme kontrolü yapılır.
- Sonuç ekrana yazdırılır.

---

### 3. Ortalama Hesaplama Aracı
- 0 ile 100 arasında üç not alınır.
- Ortalama hesaplanır.
- Not ortalamasına göre harfli not sistemiyle geri bildirim verilir (AA, BA, BB ... FF).

---

## 🛠 Nasıl Çalıştırılır?

1. Proje klasörünü açın.
2. Aşağıdaki komutu terminalden çalıştırın:


3. Konsoldaki yönlendirmeleri takip edin.

---

## 📌 Notlar

- Girişlerde veri doğrulama yapılır: sayı aralıkları kontrol edilir, geçersiz girişler yeniden istenir.
- Kod yapısı, tekrar kullanılabilir metotlarla temiz ve okunabilir şekilde tasarlanmıştır (`guess1`, `guess2`, `guess3`).
- Uygulama .NET Core veya .NET Framework kurulu bir sistemde çalıştırılabilir.

---

## 📄 Lisans

Bu proje herhangi bir özel lisansa sahip değildir. Eğitim ve öğrenme amacıyla serbestçe kullanılabilir.
