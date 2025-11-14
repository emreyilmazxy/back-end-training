# ifmanav 🍎

Manav uygulaması - if-else vs switch-case karşılaştırması.

## 📋 Proje Açıklaması

Manav fiyat hesaplama uygulaması. Aynı mantık hem if-else hem switch-case ile yazılarak karşılaştırma yapılır.

## 🚀 Teknolojiler

- **C# Console Application**
- **if-else yapısı**
- **switch-case yapısı**
- **Karşılaştırma**

## 🍎 Meyve Fiyatları

- **Elma** - 2 TL
- **Armut** - 3 TL
- **Çilek** - 2 TL
- **Muz** - 3 TL
- **Diğerleri** - 4 TL

## 📊 İki Yaklaşım

### if-else Yaklaşımı
```csharp
if (meyve == "elma")
    fiyat = 2;
else if (meyve == "armut")
    fiyat = 3;
else
    fiyat = 4;
```

### switch-case Yaklaşımı
```csharp
switch (meyve)
{
    case "elma":
        fiyat = 2;
        break;
    case "armut":
        fiyat = 3;
        break;
    default:
        fiyat = 4;
        break;
}
```

## ⚙️ Çalıştırma

```bash
cd ifmanav
dotnet restore
dotnet run --project ifswitcihlermanav/ifswitcihlermanav.csproj
```

## 📚 Öğrenilen Konular

- if-else statements
- switch-case statements
- String comparison
- Code readability
- Performance comparison
