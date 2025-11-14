# BankApp 🏦

Modern ve güvenli bir banka uygulaması Web API projesi. Enterprise-level mimari ile geliştirilmiştir.

## 📋 Proje Açıklaması

BankApp, çok katmanlı mimari (Multi-layer Architecture) kullanılarak geliştirilmiş profesyonel bir banka uygulamasıdır. Hesap yönetimi, fatura işlemleri, kullanıcı yönetimi ve güvenlik özellikleri içerir.

## 🚀 Teknolojiler

- **ASP.NET Core Web API** - RESTful API
- **Entity Framework Core** - ORM
- **SQL Server** - Veritabanı
- **JWT Authentication** - Token tabanlı kimlik doğrulama
- **API Versioning** - API sürüm yönetimi
- **Data Protection** - Veri şifreleme
- **Two Factor Authentication (2FA)** - İki faktörlü kimlik doğrulama
- **Swagger/OpenAPI** - API dokümantasyonu
- **xUnit** - Unit testler

## 🏗️ Mimari

Proje **Clean Architecture** prensiplerine uygun olarak 4 katmandan oluşur:

- **BankApp.WebApi** - API Controller'ları ve Middleware'ler
- **BankApp.Business** - İş mantığı ve servisler
- **BankApp.Data** - Veritabanı işlemleri (Repository, UnitOfWork)
- **BankApp.Business.Tests** - Unit testler

## 📦 Design Pattern'ler

- Repository Pattern
- Unit of Work Pattern
- Dependency Injection
- DTO (Data Transfer Object) Pattern

## 🔐 Güvenlik Özellikleri

- JWT Bearer Token Authentication
- Data Protection (Şifreleme)
- Two Factor Authentication (2FA)
- User Activity Logging
- Custom Middlewares (Global Exception Handler, Maintenance Mode)

## 🎯 Özellikler

- ✅ Kullanıcı yönetimi (Kayıt, Giriş, Profil)
- ✅ Hesap yönetimi (Para transferi, bakiye sorgulama)
- ✅ Fatura işlemleri
- ✅ İki faktörlü kimlik doğrulama (2FA)
- ✅ Kullanıcı aktivite takibi
- ✅ Sistem ayarları yönetimi
- ✅ Maintenance mode (Bakım modu)

## 🔌 API Endpoints

- `/api/v1/users` - Kullanıcı işlemleri
- `/api/v1/accounts` - Hesap işlemleri
- `/api/v1/bills` - Fatura işlemleri
- `/api/v1/security` - Güvenlik işlemleri
- `/api/v1/settings` - Ayarlar

## ⚙️ Çalıştırma

### Visual Studio ile
1. `BankApp/BankApp.sln` dosyasını açın
2. F5 ile çalıştırın
3. Tarayıcıda Swagger UI otomatik açılacaktır

### Komut satırından
```bash
cd BankApp
dotnet restore
dotnet run --project BankApp.WepApi/BankApp.WepApi.csproj
```

### Swagger UI
Uygulama çalıştığında: `https://localhost:xxxx/swagger`

## 🗄️ Veritabanı Kurulumu

1. `appsettings.json` içindeki connection string'i düzenleyin
2. Package Manager Console'da:
```
Add-Migration InitialCreate
Update-Database
```

## 📝 Önemli Dosyalar

- `BankApp/BankApp.sln` - Solution dosyası
- `BankApp.WepApi/Program.cs` - Uygulama giriş noktası
- `BankApp.Data/Context/BankAppDbContext.cs` - Veritabanı context
- `appsettings.json` - Yapılandırma dosyası (JWT, ConnectionString)

## 🧪 Test Çalıştırma

```bash
cd BankApp.Business.Tests
dotnet test
```

## 📚 Öğrenilen Konular

- Multi-layer Architecture
- Repository & Unit of Work Pattern
- JWT Authentication & Authorization
- API Versioning
- Custom Middleware Development
- Data Protection & Encryption
- Two Factor Authentication
- Unit Testing
- Entity Framework Core Advanced Features
- SOLID Principles
