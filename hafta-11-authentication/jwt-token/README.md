# token 🔑

JWT Token authentication Web API projesi.

## 📋 Proje Açıklaması

JWT (JSON Web Token) tabanlı kimlik doğrulama sistemi. Token oluşturma ve doğrulama işlemlerini içerir.

## 🚀 Teknolojiler

- **ASP.NET Core Web API**
- **JWT Bearer Authentication**
- **Entity Framework Core**
- **SQL Server**
- **Swagger/OpenAPI**

## 🎯 Özellikler

- ✅ JWT token üretimi
- ✅ Token doğrulama
- ✅ Bearer authentication
- ✅ Secure endpoints

## 🔌 API Endpoints

- `POST /api/auth/login` - Login ve token al
- `GET /api/secure` - Token korumalı endpoint

## ⚙️ Çalıştırma

```bash
cd token
dotnet restore
dotnet run --project token/token.csproj
```

## 📚 Öğrenilen Konular

- JWT Token generation
- Bearer Authentication
- Token validation
- Secure API endpoints
- appsettings configuration
