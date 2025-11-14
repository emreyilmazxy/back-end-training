# Yapıcı Metot (Constructor) Örneği - Baby Sınıfı

Bu C# projesi, **sınıf yapısı**, **yapıcı metot (constructor)** kullanımı ve **nesne üzerinden veri atama** gibi temel nesne yönelimli programlama (OOP) kavramlarını göstermek için hazırlanmıştır.

## 👶 Sınıf: `Baby`

### Alanlar:
- `_name`: Bebeğin adı (string)
- `_surname`: Bebeğin soyadı (string)
- `_birtDay`: Bebeğin doğum tarihi (string, bugünün tarihi atanır)

### Yapıcı Metotlar:
- `Baby(string name, string surName)`: Parametreli yapıcı metot. İsim ve soyisim alınır, doğum tarihi olarak bugünün tarihi atanır ve konsola bilgi yazdırılır.
- `Baby()`: Parametresiz yapıcı metot. Sadece doğum tarihi atanır ve konsola "ıngaaaaa" çıktısı verilir.

## 🧪 Kullanım

Program içerisinde iki farklı `Baby` nesnesi oluşturulmuştur:

```csharp
Baby baby = new Baby("Ali", "yılmaz");
Baby baby2 = new Baby();
baby2._name = "Mehmet";
baby2._surname = "şeker";
Console.WriteLine($"bebek adı:{baby2._name} soy adı:{baby2._surname}  ");

## 🖨️ Konsol Çıktısı (Örnek)



ıngaaaaa 17.05.2025 bebek adı:Ali soy adı:yılmaz  
ıngaaaaa 17.05.2025 
bebek adı:Mehmet soy adı:şeker  

## 📁 Proje Yapısı



Yapicimethod/
├── Program.cs         // Main metodu içeriyor
└── Baby.cs            // Baby sınıfı burada (veya Program.cs içinde tanımlı)



## 🎯 Amaç

Bu mini proje ile aşağıdaki konuların öğrenilmesi hedeflenmiştir:

- ✅ **C# dilinde sınıf (class) tanımı**
- ✅ **Yapıcı metot (constructor) kullanımı**
- ✅ **Aşırı yükleme (constructor overloading)**
- ✅ **`DateTime.Today.ToShortDateString()` ile günün tarihini alma**
- ✅ **Alanlara (fields) doğrudan erişim ve değer atama**
