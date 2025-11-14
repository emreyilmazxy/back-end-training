# UnlulerApi ⭐

Ünlüler listesi yönetimi Web API projesi.

## 📋 Proje Açıklaması

Basit bir REST API projesi. Ünlü kişilerin listesini yönetmek için CRUD operasyonları içerir. In-memory liste ile çalışır.

## 🚀 Teknolojiler

- **ASP.NET Core Web API**
- **RESTful API**
- **Swagger/OpenAPI**
- **In-memory data storage**
- **CRUD Operations**

## 🔌 API Endpoints

### Ünlüler İşlemleri
- `GET /api/celebrities` - Tüm ünlüleri listele
- `GET /api/celebrities/{id}` - ID'ye göre ünlü getir
- `POST /api/celebrities` - Yeni ünlü ekle
- `PUT /api/celebrities/{id}` - Ünlü bilgilerini güncelle
- `DELETE /api/celebrities/{id}` - Ünlü sil

## 📊 Model Yapısı

```csharp
public class Celebrity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Profession { get; set; }
    public int BirthYear { get; set; }
}
```

## 🎯 Özellikler

- ✅ RESTful API standartları
- ✅ Tam CRUD operasyonları
- ✅ Swagger UI entegrasyonu
- ✅ In-memory veri saklama
- ✅ HTTP status code'lar

## ⚙️ Çalıştırma

```bash
cd UnlulerApi
dotnet restore
dotnet run --project UnlulerApi/UnlulerApi.csproj
```

### Swagger UI
Uygulama çalıştığında: `https://localhost:xxxx/swagger`

## 📝 Örnek Request

```json
POST /api/celebrities
{
  "name": "Tarkan",
  "profession": "Şarkıcı",
  "birthYear": 1972
}
```

## 📚 Öğrenilen Konular

- REST API tasarımı
- API Controller
- HTTP Methods (GET, POST, PUT, DELETE)
- Swagger/OpenAPI documentation
- In-memory data management
- Status code handling
- Model binding
