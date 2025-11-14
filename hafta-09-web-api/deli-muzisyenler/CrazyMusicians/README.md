# Crazy Musicians API 🎸

Bu proje, hayali ve eğlenceli müzisyenlerden oluşan bir listeyi yöneten basit bir ASP.NET Core Web API uygulamasıdır. JSON formatında CRUD işlemleri sağlar.

## Özellikler

- 🎶 Tüm müzisyenleri listeleme
- 🔍 ID ile müzisyen bulma
- ➕ Yeni müzisyen ekleme
- ✏️ Mevcut müzisyeni güncelleme
- ❌ Müzisyen silme
- 🔍 İsimle arama (query string)
- 🩹 PATCH işlemi ile kısmi güncelleme

## Kullanım

### GET /api/CrazyMusicians
Tüm müzisyenleri getirir.

### GET /api/CrazyMusicians/{id}
Belirli ID’ye sahip müzisyeni getirir.

### POST /api/CrazyMusicians
Yeni müzisyen ekler.

```json
{
  "name": "Yeni İsim",
  "profession": "Meslek",
  "funTrait": "Eğlenceli Özellik"
}
