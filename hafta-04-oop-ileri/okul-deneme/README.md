# OkulDeneme 🏫

Okul yönetim sistemi Web API projesi.

## 📋 Proje Açıklaması

Okul yönetimi için basit bir Web API. Öğrenci, öğretmen ve sınıf yönetimi içerir.

## 🚀 Teknolojiler

- **ASP.NET Core Web API**
- **Entity Framework Core**
- **SQL Server**
- **DbContext**
- **Swagger/OpenAPI**

## 📊 Veri Modelleri

- **Student** - Öğrenci bilgileri
- **Teacher** - Öğretmen bilgileri
- **Class** - Sınıf bilgileri
- **Course** - Ders bilgileri

## 🔌 API Endpoints

- `/api/students` - Öğrenci işlemleri
- `/api/teachers` - Öğretmen işlemleri
- `/api/classes` - Sınıf işlemleri
- `/api/courses` - Ders işlemleri

## ⚙️ Çalıştırma

```bash
cd OkulDeneme
dotnet restore
dotnet ef database update
dotnet run --project OkulDeneme.WebApi/OkulDeneme.WebApi.csproj
```

## 📚 Öğrenilen Konular

- Web API development
- Entity Framework Core
- DbContext configuration
- REST API design
- Database relationships
