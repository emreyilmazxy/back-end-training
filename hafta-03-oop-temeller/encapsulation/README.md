# kapsulleme 🔒

Encapsulation (Kapsülleme) pratik projesi.

## 📋 Proje Açıklaması

OOP'nin temel prensiplerinden Encapsulation (Kapsülleme) kavramını öğreten pratik çalışma. Private field'lar ve public property'ler kullanımı.

## 🚀 Teknolojiler

- **C# Console Application**
- **Encapsulation**
- **Properties (get/set)**
- **Private fields**
- **OOP Principles**

## 🔒 Kapsülleme Nedir?

Verileri (field'lar) gizleyip, kontrollü erişim sağlama:
- **Private fields:** Veriyi gizle
- **Public properties:** Kontrollü erişim sağla
- **Validation:** Değer kontrolü yap

## 📊 Örnek Kod

### Kötü Uygulama (No Encapsulation)
```csharp
public class Person
{
    public int Age; // Herkes değiştirebilir!
}

Person p = new Person();
p.Age = -5; // Geçersiz değer!
```

### İyi Uygulama (With Encapsulation)
```csharp
public class Person
{
    private int _age; // Gizli
    
    public int Age
    {
        get { return _age; }
        set 
        { 
            if (value >= 0 && value <= 150)
                _age = value;
            else
                throw new ArgumentException("Geçersiz yaş!");
        }
    }
}

Person p = new Person();
p.Age = 25; // OK
p.Age = -5; // Exception!
```

## 🎯 Kapsülleme Avantajları

- ✅ **Data Hiding:** Veri gizleme
- ✅ **Validation:** Değer doğrulama
- ✅ **Flexibility:** Esneklik
- ✅ **Maintainability:** Bakım kolaylığı
- ✅ **Security:** Güvenlik

## 📊 Property Türleri

```csharp
// Auto-implemented property
public string Name { get; set; }

// Read-only property
public string Country { get; }

// Computed property
public string FullName 
{ 
    get { return $"{FirstName} {LastName}"; } 
}

// Private setter
public DateTime CreatedDate { get; private set; }
```

## ⚙️ Çalıştırma

```bash
cd kapsulleme
dotnet restore
dotnet run --project Encapsulation/Encapsulation.csproj
```

## 📚 Öğrenilen Konular

- Encapsulation principle
- Private fields
- Public properties
- Get/Set accessors
- Auto-implemented properties
- Property validation
- Read-only properties
- Computed properties
- Access modifiers
