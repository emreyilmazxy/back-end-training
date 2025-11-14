# mvcproje 📦

MVC ViewModel pattern uygulama projesi.

## 📋 Proje Açıklaması

ASP.NET Core MVC'de ViewModel pattern'ini uygulayan örnek proje. Customer-Orders ilişkisini ViewModel ile yönetir.

## 🚀 Teknolojiler

- **ASP.NET Core MVC**
- **ViewModel Pattern**
- **Razor Views**
- **Data Transfer Objects**

## 📊 ViewModel Pattern

### Model Sınıfları
```csharp
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class Order
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public decimal Amount { get; set; }
}
```

### ViewModel
```csharp
public class CustomerOrderViewModel
{
    public Customer Customer { get; set; }
    public List<Order> Orders { get; set; }
    public decimal TotalAmount { get; set; }
}
```

## 🎯 ViewModel Avantajları

- ✅ Birden fazla model'i birleştirir
- ✅ View'a özel veri yapısı
- ✅ Hesaplanmış alanlar eklenebilir
- ✅ Güvenlik (sadece gerekli veriler)
- ✅ View logic'i azaltır

## 📊 Kullanım

```csharp
public IActionResult CustomerDetails(int id)
{
    var viewModel = new CustomerOrderViewModel
    {
        Customer = GetCustomer(id),
        Orders = GetOrders(id),
        TotalAmount = CalculateTotal(id)
    };
    
    return View(viewModel);
}
```

## ⚙️ Çalıştırma

```bash
cd mvcproje
dotnet restore
dotnet run --project mvcproje/mvcproje.csproj
```

## 🌐 Tarayıcıda Görüntüleme

Uygulama çalıştığında: `https://localhost:xxxx`

## 📚 Öğrenilen Konular

- ViewModel Pattern
- Data aggregation
- View-specific models
- Separation of concerns
- Model composition
- Calculated properties
- Clean architecture
