# Inheritance 🌳

Kalıtım (Inheritance) konsepti pratik projesi.

## 📋 Proje Açıklaması

OOP'nin temel kavramlarından biri olan kalıtımı Öğrenci ve Öğretmen sınıfları üzerinden uygulayan basit bir konsol uygulaması.

## 🚀 Teknolojiler

- **C# Console Application**
- **OOP - Inheritance**
- **Base Class & Derived Classes**

## 🏗️ Sınıf Hiyerarşisi

```
BaseClass (Temel Sınıf)
├── Ogrenci (Türetilmiş Sınıf)
└── Ogretmen (Türetilmiş Sınıf)
```

## 🎯 Kalıtım Özellikleri

- **Base Class:** Ortak özellikler (Ad, Soyad)
- **Derived Classes:** Özgü özellikler (OgrenciNo, Maas)
- **Code Reusability:** Kod tekrarını önler
- **Is-A Relationship:** Ogrenci "is-a" BaseClass

## 📊 Örnek Çıktı

```
Öğretmen Bilgileri: Ayse Yılmaz - Maaş: 5000
Öğrenci Bilgileri: Ali Veli - No: 123
```

## ⚙️ Çalıştırma

```bash
cd Inheritance
dotnet restore
dotnet run --project Inheritance/Inheritance.csproj
```

## 📚 Öğrenilen Konular

- Inheritance (Kalıtım)
- Base class & Derived class
- Code reusability
- Is-A relationship
- Access modifiers
- OOP principles
