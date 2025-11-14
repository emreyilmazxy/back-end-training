# Patikafy 🎵

Şarkıcı listesi yönetimi ve LINQ pratik projesi.

## 📋 Proje Açıklaması

Çeşitli şarkıcıları içeren bir liste üzerinde karmaşık LINQ sorgularının uygulandığı pratik projesidir. Türk pop müziği sanatçılarının albüm satışları, çıkış yılları ve türleri üzerinde analiz yapılır.

## 🚀 Teknolojiler

- **C# Console Application**
- **LINQ** - Karmaşık sorgular
- **List<T>** - Generic koleksiyonlar
- **Lambda Expressions**

## 🎯 LINQ Sorguları

1. **Where** - 'S' harfi ile başlayan şarkıcılar
2. **Where** - Albüm satışları 10 milyon üzeri olanlar
3. **Where + GroupBy** - 2000 öncesi pop müzik yapanlar (yıla göre gruplanmış)
4. **OrderByDescending + FirstOrDefault** - En çok albüm satan şarkıcı
5. **Max + Min** - En yeni ve en eski çıkış yapan şarkıcılar

## 📊 Veri Yapısı

```csharp
public class Artist
{
    public string Name { get; set; }
    public string Lastname { get; set; }
    public string Genre { get; set; }
    public int ReleaseYear { get; set; }
    public long AlbumSales { get; set; }
}
```

## 🎵 Örnek Şarkıcılar

- Ajda Pekkan (1968, 20M satış)
- Tarkan (1992, 40M satış)
- Sezen Aksu (1971, 10M satış)
- ve diğerleri...

## ⚙️ Çalıştırma

```bash
cd Patikafy
dotnet restore
dotnet run --project Patikafy/Patikafy.csproj
```

## 📝 Çıktı Örneği

```
s ile başlayan şarkıcılar:
Sezen Aksu
Sıla
Serdar Ortaç

Albüm satışları 10 milyon'un üzerinde:
Tarkan - 40000000 sales
...
```

## 📚 Öğrenilen Konular

- LINQ Where, OrderBy, OrderByDescending
- LINQ GroupBy ile gruplama
- LINQ Max, Min ile extremum bulma
- FirstOrDefault kullanımı
- Lambda expressions
- Method chaining
- String comparison (StringComparison.OrdinalIgnoreCase)
