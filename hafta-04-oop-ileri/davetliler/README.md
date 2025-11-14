# Davetliler 👥

Davetli listesi yönetimi konsol uygulaması.

## 📋 Proje Açıklaması

Basit bir davetli listesi oluşturan ve yöneten konsol uygulaması. List<string> koleksiyonu ile çalışma pratiği yapar.

## 🚀 Teknolojiler

- **C# Console Application**
- **List<string>** - Generic koleksiyon
- **foreach döngüsü**
- **Add method**

## 📊 List<T> Kullanımı

```csharp
// Liste oluşturma
List<string> davetliler = new List<string>();

// Eleman ekleme
davetliler.Add("Ahmet Yılmaz");
davetliler.Add("Ayşe Demir");
davetliler.Add("Mehmet Kaya");

// Listeleme
foreach (var davetli in davetliler)
{
    Console.WriteLine(davetli);
}
```

## 🎯 Özellikler

- ✅ Davetli ekleme
- ✅ Davetli listesini görüntüleme
- ✅ List<string> kullanımı
- ✅ foreach döngüsü
- ✅ Dinamik liste yönetimi

## ⚙️ Çalıştırma

```bash
cd Davetliler
dotnet restore
dotnet run --project davetlilerList/davetlilerList.csproj
```

## 📝 Çıktı Örneği

```
Davetli Listesi:
1. Ahmet Yılmaz
2. Ayşe Demir
3. Mehmet Kaya
4. Fatma Özdemir
5. Ali Yıldırım
```

## 📚 Öğrenilen Konular

- List<T> koleksiyonu
- Generic types
- Add method
- foreach döngüsü
- Collection initialization
- Dynamic array alternative
