# dependency 🔌

Dependency Injection canlı örnek projesi.

## 📋 Proje Açıklaması

Dependency Injection (Bağımlılık Enjeksiyonu) pattern'ini canlı örneklerle gösteren Web API projesi.

## 🚀 Teknolojiler

- **ASP.NET Core Web API**
- **Dependency Injection Pattern**
- **Interface-based programming**
- **Swagger/OpenAPI**

## 🔗 DI Pattern

### Without DI (Tight Coupling)
```csharp
public class OrderService
{
    private EmailService _emailService;
    
    public OrderService()
    {
        _emailService = new EmailService(); // Tight coupling!
    }
}
```

### With DI (Loose Coupling)
```csharp
public interface IEmailService
{
    void SendEmail(string to, string message);
}

public class OrderService
{
    private readonly IEmailService _emailService;
    
    // Dependency injected via constructor
    public OrderService(IEmailService emailService)
    {
        _emailService = emailService;
    }
}

// Program.cs
builder.Services.AddScoped<IEmailService, EmailService>();
```

## 🎯 DI Avantajları

- ✅ **Loose Coupling:** Gevşek bağlılık
- ✅ **Testability:** Mock nesneler kullanabilme
- ✅ **Maintainability:** Kolay bakım
- ✅ **Flexibility:** Kolay değiştirme
- ✅ **SOLID Principles:** Dependency Inversion

## 📊 DI Lifetime'lar

```csharp
// Transient - Her seferinde yeni
services.AddTransient<IMyService, MyService>();

// Scoped - Request başına bir
services.AddScoped<IMyService, MyService>();

// Singleton - Uygulama boyunca tek
services.AddSingleton<IMyService, MyService>();
```

## ⚙️ Çalıştırma

```bash
cd dependency
dotnet restore
dotnet run --project depencdeyycanli/depencdeyycanli.csproj
```

## 🔧 Test Edilebilirlik

```csharp
// Test için mock service
public class MockEmailService : IEmailService
{
    public void SendEmail(string to, string message)
    {
        // Mock implementation
    }
}

// Test
var mockEmail = new MockEmailService();
var orderService = new OrderService(mockEmail);
```

## 📚 Öğrenilen Konular

- Dependency Injection Pattern
- Constructor Injection
- Interface segregation
- Loose coupling vs Tight coupling
- Service lifetimes
- IoC (Inversion of Control)
- SOLID - Dependency Inversion Principle
- Testability improvement
