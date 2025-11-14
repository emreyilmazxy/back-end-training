# whilevsDo 🔄

While ve Do-While döngülerini karşılaştırma projesi.

## 📋 Proje Açıklaması

While ve Do-While döngülerinin farklarını ve kullanım senaryolarını öğreten pratik çalışma.

## 🚀 Teknolojiler

- **C# Console Application**
- **while döngüsü**
- **do-while döngüsü**
- **Loop comparison**

## 🔍 While vs Do-While

### While Döngüsü
```csharp
int i = 0;
while (i < 5)
{
    Console.WriteLine($"While: {i}");
    i++;
}
// Koşul önce kontrol edilir
```

### Do-While Döngüsü
```csharp
int j = 0;
do
{
    Console.WriteLine($"Do-While: {j}");
    j++;
} while (j < 5);
// En az bir kez çalışır
```

## 🎯 Temel Farklar

- ✅ while: Koşul önce kontrol edilir
- ✅ do-while: En az bir kez çalışır
- ✅ while: Koşul false ise hiç çalışmaz
- ✅ do-while: Koşul false olsa bile 1 kez çalışır

## ⚙️ Çalıştırma

```bash
cd whilevsDo/whilevsdo
dotnet restore
dotnet run
```

## 📚 Öğrenilen Konular

- while loop
- do-while loop
- Loop differences
- Pre-test vs Post-test loops
- Loop selection criteria
