# Identity 🔐

ASP.NET Identity ile kullanıcı kimlik doğrulama sistemi.

## 📋 Proje Açıklaması

ASP.NET Core Identity kullanılarak geliştirilmiş kullanıcı kayıt ve giriş sistemi. Entity Framework Core ve SQL Server ile entegre çalışır.

## 🚀 Teknolojiler

- **ASP.NET Core Web API**
- **ASP.NET Identity** - Kullanıcı yönetimi
- **Entity Framework Core** - ORM
- **SQL Server** - Veritabanı
- **Swagger/OpenAPI** - API dokümantasyonu

## 🎯 Özellikler

- ✅ Kullanıcı kaydı (Register)
- ✅ Kullanıcı girişi (Login)
- ✅ Şifre hashleme
- ✅ Rol yönetimi (IdentityRole)
- ✅ Token providers

## 🔌 API Endpoints

- `POST /api/auth/register` - Yeni kullanıcı kaydı
- `POST /api/auth/login` - Kullanıcı girişi

## ⚙️ Çalıştırma

```bash
cd identity
dotnet restore
dotnet run --project Identity/Identity.csproj
```

## 🛠️ Veritabanı Kurulumu

1. `appsettings.json` içindeki connection string'i düzenleyin
2. Migration'ları çalıştırın:
```bash
Add-Migration InitialIdentity
Update-Database
```

## 📚 Öğrenilen Konular

- ASP.NET Identity Framework
- IdentityUser ve IdentityRole
- Entity Framework with Identity
- Password Hashing
- Token Providers
- User Manager & Sign In Manager
