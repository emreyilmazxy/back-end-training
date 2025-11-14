# CodeFirst 🗄️

Entity Framework Code First yaklaşımı MVC projesi.

## 📋 Proje Açıklaması

Entity Framework Core Code First migration yaklaşımını kullanan ASP.NET Core MVC projesi.

## 🚀 Teknolojiler

- **ASP.NET Core MVC**
- **Entity Framework Core**
- **Code First Migrations**
- **SQL Server**

## 🎯 Özellikler

- ✅ Code First yaklaşımı
- ✅ DbContext tanımlama
- ✅ Migration oluşturma
- ✅ Database güncelleme
- ✅ Model sınıfları

## 🛠️ Migration Komutları

```bash
# Migration oluştur
Add-Migration InitialCreate

# Veritabanını güncelle
Update-Database

# Migration geri al
Remove-Migration
```

## ⚙️ Çalıştırma

```bash
cd CodeFirst
dotnet restore
dotnet ef database update
dotnet run --project codeFirst/codeFirst.csproj
```

## 📚 Öğrenilen Konular

- Code First approach
- DbContext configuration
- Migrations
- Model classes
- Entity Framework conventions
- Connection strings
