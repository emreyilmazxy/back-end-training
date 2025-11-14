# pratik ilk sınıf 🏛️

İlk sınıf (class) oluşturma pratik projesi.

## 📋 Proje Açıklaması

C# dilinde ilk sınıf (class) oluşturma pratiği. Person sınıfı ile OOP'ye giriş.

## 🚀 Teknolojiler

- **C# Console Application**
- **OOP - Classes**
- **Properties**
- **Objects**

## 📄 Person Sınıfı

```csharp
public class Person
{
    // Properties
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public string City { get; set; }
    
    // Method
    public void Introduce()
    {
        Console.WriteLine($"Merhaba, ben {Name} {Surname}");
        Console.WriteLine($"{Age} yaşındayım ve {City}'de yaşıyorum.");
    }
}
```

## 📊 Kullanım

```csharp
// Nesne oluşturma
Person person1 = new Person();
person1.Name = "Ahmet";
person1.Surname = "Yılmaz";
person1.Age = 25;
person1.City = "İstanbul";

// Method çağırma
person1.Introduce();
```

## 🎯 Özellikler

- ✅ İlk class tanımlama
- ✅ Property kullanımı
- ✅ Object oluşturma
- ✅ Method tanımlama
- ✅ OOP temelleri

## ⚙️ Çalıştırma

```bash
cd "pratik ilk sınıf"
dotnet restore
dotnet run --project pratikIlksinif/pratikIlksinif.csproj
```

## 📚 Öğrenilen Konular

- Class definition
- Properties
- Object creation
- Object initialization
- Method definition
- OOP basics
