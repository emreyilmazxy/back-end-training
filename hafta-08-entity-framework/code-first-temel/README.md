# CodeFirstBasic 🏛️

Entity Framework Core temel Code First projesi.

## 📋 Proje Açıklaması

Entity Framework Core ile Code First yaklaşımının temellerini öğreten basit Web API projesi. PostgreSQL veritabanı ile çalışır.

## 🚀 Teknolojiler

- **ASP.NET Core Web API**
- **Entity Framework Core**
- **PostgreSQL (Npgsql)**
- **Code First Approach**
- **Migrations**

## 📊 Code First Adımları

### 1️⃣ Model Oluştur
```csharp
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
```

### 2️⃣ DbContext Tanımla
```csharp
public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
}
```

### 3️⃣ Migration Oluştur
```bash
Add-Migration InitialCreate
```

### 4️⃣ Veritabanını Güncelle
```bash
Update-Database
```

## 🎯 Özellikler

- ✅ Code First yaklaşımı
- ✅ DbContext yapılandırması
- ✅ Model sınıfları
- ✅ Migration sistemi
- ✅ PostgreSQL entegrasyonu
- ✅ Connection string yönetimi

## ⚙️ Çalıştırma

```bash
cd CodeFirstBasic
dotnet restore
dotnet ef database update
dotnet run --project CodeFirstBasic/CodeFirstBasic.csproj
```

## 🛠️ Gereksinimler

- PostgreSQL kurulu olmalı
- `appsettings.json` içinde connection string yapılandırılmalı

## 📚 Öğrenilen Konular

- Code First methodology
- DbContext configuration
- DbSet properties
- EF Core migrations
- PostgreSQL provider (Npgsql)
- Connection string management
- Model conventions
- Database initialization
