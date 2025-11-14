# mvcodev 🏗️

ASP.NET Core MVC öğrenme projesi.

## 📋 Proje Açıklaması

MVC (Model-View-Controller) mimarisini detaylı Türkçe açıklamalarla öğreten eğitim projesi. Controller, Action, Model, View ve Razor konseptleri uygulamalı olarak anlatılır.

## 🚀 Teknolojiler

- **ASP.NET Core MVC**
- **Razor View Engine**
- **Controllers & Actions**
- **Models**
- **Views**

## 🎯 MVC Bileşenleri

### M - Model
```csharp
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
```

### V - View (Razor)
```html
@model Product
<h1>@Model.Name</h1>
<p>Fiyat: @Model.Price TL</p>
```

### C - Controller
```csharp
public class ProductController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
```

## 📚 MVC Kavramları

- **Controller:** İş mantığını yönetir
- **Action:** Controller içindeki metodlar
- **Model:** Veri yapıları
- **View:** Kullanıcı arayüzü
- **Razor:** View için C# kullanma
- **ViewBag:** Controller'dan View'a veri taşıma
- **ViewData:** Alternatif veri taşıma

## 🎯 Özellikler

- ✅ MVC pattern detaylı anlatım
- ✅ Türkçe kod açıklamaları
- ✅ Controller örnekleri
- ✅ Action method'ları
- ✅ Razor syntax
- ✅ Model binding
- ✅ Routing yapılandırması

## ⚙️ Çalıştırma

```bash
cd mvcodev
dotnet restore
dotnet run --project mvcodev/mvcodev.csproj
```

## 🌐 Tarayıcıda Görüntüleme

Uygulama çalıştığında: `https://localhost:xxxx`

## 📚 Öğrenilen Konular

- MVC Architecture Pattern
- Controller oluşturma
- Action methods
- View rendering
- Razor syntax
- Model binding
- ViewBag & ViewData
- Routing configuration
- Layout pages
- Partial views
