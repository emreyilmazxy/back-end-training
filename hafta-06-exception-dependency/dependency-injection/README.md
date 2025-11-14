# DI 🔌

Dependency Injection (Bağımlılık Enjeksiyonu) pratik projesi.

## 📋 Proje Açıklaması

ASP.NET Core'da Dependency Injection konseptini öğreten Web API projesi. Servis kayıt türleri ve yaşam döngüleri uygulamalı olarak gösterilir.

## 🚀 Teknolojiler

- **ASP.NET Core Web API**
- **Dependency Injection**
- **Service Lifetimes**
- **Swagger/OpenAPI**

## 🔗 DI Lifetime'lar

### 1️⃣ Transient
```csharp
services.AddTransient<IMyService, MyService>();
// Her istek için yeni instance
```

### 2️⃣ Scoped
```csharp
services.AddScoped<IMyService, MyService>();
// Her HTTP isteği için bir instance
```

### 3️⃣ Singleton
```csharp
services.AddSingleton<IMyService, MyService>();
// Uygulama boyunca tek instance
```

## 🎯 DI Avantajları

- ✅ **Loose Coupling:** Gevşek bağlılık
- ✅ **Testability:** Test edilebilirlik
- ✅ **Maintainability:** Bakım kolaylığı
- ✅ **Flexibility:** Esneklik
- ✅ **Separation of Concerns:** Sorumluluk ayrımı

## 📊 Örnek Kullanım

```csharp
// Interface
public interface IEmailService
{
    void SendEmail(string to, string message);
}

// Implementation
public class EmailService : IEmailService
{
    public void SendEmail(string to, string message)
    {
        // Email gönderme mantığı
    }
}

// Registration (Program.cs)
builder.Services.AddScoped<IEmailService, EmailService>();

// Usage (Controller)
public class UserController : ControllerBase
{
    private readonly IEmailService _emailService;
    
    public UserController(IEmailService emailService)
    {
        _emailService = emailService;
    }
}
```

## ⚙️ Çalıştırma

```bash
cd DI
dotnet restore
dotnet run --project Dependency_Injection/Dependency_Injection.csproj
```

## 📚 Öğrenilen Konular

- Dependency Injection Pattern
- Service registration
- Service lifetimes (Transient, Scoped, Singleton)
- Constructor injection
- Interface-based programming
- Inversion of Control (IoC)
- Built-in DI container
- SOLID principles
