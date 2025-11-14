# metoduygulamalari 🛠️

Method (metod) uygulamaları pratik projesi.

## 📋 Proje Açıklaması

Farklı türlerde method tanımlamalarını içeren pratik çalışma. Void, return, parametreli/parametresiz metodlar.

## 🚀 Teknolojiler

- **C# Console Application**
- **Methods**
- **Return types**
- **Parameters**
- **Static methods**

## 📊 Method Türleri

### 1️⃣ Parametresiz Void Method
```csharp
static void Selamla()
{
    Console.WriteLine("Merhaba!");
}
```

### 2️⃣ Parametreli Void Method
```csharp
static void SelamVer(string isim)
{
    Console.WriteLine($"Merhaba {isim}!");
}
```

### 3️⃣ Parametresiz Return Method
```csharp
static int RandomSayiUret()
{
    Random rnd = new Random();
    return rnd.Next(1, 100);
}
```

### 4️⃣ Parametreli Return Method
```csharp
static int Topla(int a, int b)
{
    return a + b;
}
```

## 🎯 Özellikler

- ✅ Void metodlar
- ✅ Return değerli metodlar
- ✅ Parametreli metodlar
- ✅ Parametresiz metodlar
- ✅ Static metodlar
- ✅ Multiple parameters

## ⚙️ Çalıştırma

```bash
cd metoduygulamalari
dotnet restore
dotnet run --project metoduygulamalari/metoduygulamalari.csproj
```

## 📚 Öğrenilen Konular

- Method declaration
- Return types (void, int, string)
- Parameters
- Method calling
- Static methods
- Method signatures
- Return values
