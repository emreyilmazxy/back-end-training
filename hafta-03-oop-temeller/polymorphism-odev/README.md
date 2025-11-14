# polymorphismOdev 🔷

Polymorphism (Çok biçimlilik) konsepti pratik projesi.

## 📋 Proje Açıklaması

Geometrik şekillerin alan hesaplaması üzerinden polymorphism konseptini uygulayan OOP projesi. Abstract base class ve method overriding kullanımı.

## 🚀 Teknolojiler

- **C# Console Application**
- **OOP - Polymorphism**
- **Virtual Methods & Override**
- **Abstract Classes**

## 🏗️ Sınıf Hiyerarşisi

```
GeometrikSekil (Base)
├── Rectangle (Dikdörtgen)
├── Square (Kare)
└── Triangle (Üçgen)
```

## 🎯 Polymorphism Kavramı

- **Base Class:** GeometrikSekil (ortak özellikler)
- **Virtual Method:** AlanHesapla() - override edilebilir
- **Override:** Triangle sınıfı kendi alan hesaplamasını yapar
- **Inheritance:** Tüm şekiller base class'tan türer

## 📊 Örnek Çıktı

```
diktörgenin alanı > 200
karenin alanı > 100
diküçgen alanı > 25
```

## ⚙️ Çalıştırma

```bash
cd polymorphismOdev
dotnet restore
dotnet run --project polymorphism/polymorphism.csproj
```

## 📚 Öğrenilen Konular

- Polymorphism (Çok biçimlilik)
- Virtual methods
- Method overriding
- Abstract classes
- Inheritance
- OOP principles
