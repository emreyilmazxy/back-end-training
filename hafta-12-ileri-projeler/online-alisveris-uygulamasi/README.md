# OnlineShoppingApp 🛒

Kapsamlı bir e-ticaret Web API projesi. Enterprise-level mimari ve modern teknolojiler ile geliştirilmiştir.

## 📋 Proje Açıklaması

OnlineShoppingApp, çok katmanlı mimari kullanılarak geliştirilmiş tam özellikli bir online alışveriş sistemidir. Ürün yönetimi, kategori sistemi, sipariş takibi, kullanıcı yönetimi ve güvenlik özellikleri içerir.

## 🚀 Teknolojiler

- **ASP.NET Core Web API** - RESTful API
- **Entity Framework Core** - ORM
- **SQL Server** - Veritabanı
- **JWT Authentication** - Token tabanlı kimlik doğrulama
- **API Versioning** - API sürüm yönetimi
- **Data Protection** - Veri şifreleme
- **Swagger/OpenAPI** - API dokümantasyonu
- **Memory Cache** - Performans optimizasyonu
- **Localization** - Çoklu dil desteği

## 🏗️ Mimari

Proje **Clean Architecture** prensiplerine uygun olarak 3 katmandan oluşur:

- **OnlineShoppingApp.WebApi** - API Controller'ları ve Middleware'ler
- **OnlineShoppingApp.Business** - İş mantığı ve servisler
- **OnlineShoppingApp.Data** - Veritabanı işlemleri (Repository, UnitOfWork)

## 📦 Design Pattern'ler

- Repository Pattern
- Unit of Work Pattern
- Dependency Injection
- DTO (Data Transfer Object) Pattern

## 🔐 Güvenlik Özellikleri

- JWT Bearer Token Authentication
- Data Protection (Şifreleme)
- Request Logging Middleware
- Global Exception Handler
- Maintenance Mode

## 🎯 Özellikler

- ✅ Ürün yönetimi (CRUD işlemleri)
- ✅ Kategori sistemi
- ✅ Sipariş yönetimi
- ✅ Kullanıcı kaydı ve girişi
- ✅ Memory cache ile performans optimizasyonu
- ✅ Maintenance mode (Bakım modu)
- ✅ Request logging (İstek kayıtları)
- ✅ Sistem ayarları yönetimi

## 🔌 API Endpoints

- `/api/v1/products` - Ürün işlemleri
- `/api/v1/categories` - Kategori işlemleri
- `/api/v1/orders` - Sipariş işlemleri
- `/api/v1/users` - Kullanıcı işlemleri
- `/api/v1/settings` - Ayarlar

## ⚙️ Çalıştırma

### Visual Studio ile
1. `OnlineShoppingApp/OnlineShoppingApp.sln` dosyasını açın
2. F5 ile çalıştırın
3. Tarayıcıda Swagger UI otomatik açılacaktır

### Komut satırından
```bash
cd OnlineShoppingApp
dotnet restore
dotnet run --project OnlineShoppingApp.WebApi/OnlineShoppingApp.WebApi.csproj
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

- `OnlineShoppingApp/OnlineShoppingApp.sln` - Solution dosyası
- `OnlineShoppingApp.WebApi/Program.cs` - Uygulama giriş noktası
- `OnlineShoppingApp.Data/Context/OnlineShoppingDbContext.cs` - Veritabanı context
- `appsettings.json` - Yapılandırma dosyası

## 📚 Öğrenilen Konular

- Multi-layer Architecture
- Repository & Unit of Work Pattern
- JWT Authentication & Authorization
- API Versioning
- Custom Middleware Development
- Memory Caching
- Localization
- Entity Framework Core Advanced Features
- SOLID Principles
