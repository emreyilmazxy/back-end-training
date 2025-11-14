# CrazyMusicians 🎵

Müzisyen yönetim sistemi RESTful Web API projesi.

## 📋 Proje Açıklaması

Müzisyenleri yönetmek için geliştirilmiş tam özellikli REST API. Tüm HTTP metodlarını (GET, POST, PUT, DELETE, PATCH) destekler.

## 🚀 Teknolojiler

- **ASP.NET Core Web API** - RESTful API
- **Swagger/OpenAPI** - API dokümantasyonu
- **JSON Patch** - Kısmi güncelleme işlemleri
- **In-Memory Data** - Liste tabanlı veri yönetimi

## 🔌 API Endpoints

- `GET /api/musicians` - Tüm müzisyenleri listele
- `GET /api/musicians/{id}` - ID'ye göre müzisyen getir
- `GET /api/musicians/search?name=xxx` - İsme göre ara
- `POST /api/musicians` - Yeni müzisyen ekle
- `PUT /api/musicians/{id}` - Müzisyeni güncelle
- `DELETE /api/musicians/{id}` - Müzisyeni sil
- `PATCH /api/musicians/{id}` - Kısmi güncelleme

## 🎯 Özellikler

- ✅ Tam CRUD operasyonları
- ✅ JSON Patch desteği
- ✅ Arama (Search) fonksiyonu
- ✅ Swagger UI entegrasyonu
- ✅ RESTful API standartları

## ⚙️ Çalıştırma

### Visual Studio ile
```bash
CrazyMusicians/CrazyMusicians.sln dosyasını açın ve F5 ile çalıştırın
```

### Komut satırından
```bash
cd CrazyMusicians
dotnet restore
dotnet run --project CrazyMusicians/CrazyMusicians.csproj
```

### Swagger UI
Uygulama çalıştığında: `https://localhost:xxxx/swagger`

## 📝 Örnek Request

```json
POST /api/musicians
{
  "name": "Ahmet",
  "instrument": "Gitar",
  "funnyFeature": "Her zaman yanlış akort yapar"
}
```

## 📚 Öğrenilen Konular

- RESTful API Design
- HTTP Methods (GET, POST, PUT, DELETE, PATCH)
- JSON Patch Operations
- API Controller
- Swagger/OpenAPI Documentation
- Route Attributes
