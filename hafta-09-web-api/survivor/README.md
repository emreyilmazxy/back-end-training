# Survivor 🏝️

Survivor yarışma yönetim sistemi Web API projesi.

## 📋 Proje Açıklaması

Survivor yarışması için kategori ve yarışmacı yönetim sistemi. Entity Framework Core ve PostgreSQL ile geliştirilmiştir.

## 🚀 Teknolojiler

- **ASP.NET Core Web API**
- **Entity Framework Core** - ORM
- **PostgreSQL (Npgsql)** - Veritabanı
- **DTO Pattern** - Veri transfer nesneleri
- **Swagger/OpenAPI** - API dokümantasyonu
- **JSON Patch** - Kısmi güncelleme

## 🎯 Özellikler

- ✅ Kategori yönetimi (CRUD)
- ✅ Yarışmacı yönetimi (CRUD)
- ✅ Eager Loading (Include)
- ✅ Soft Delete (IsDeleted)
- ✅ DTO kullanımı
- ✅ JSON Patch desteği

## 🔌 API Endpoints

### Categories
- `GET /api/categories` - Tüm kategorileri listele
- `POST /api/categories` - Yeni kategori ekle
- `PUT /api/categories/{id}` - Kategori güncelle
- `DELETE /api/categories/{id}` - Kategori sil

### Competitors
- `GET /api/competitors` - Tüm yarışmacıları listele
- `GET /api/competitors/{id}` - Yarışmacı detayı
- `POST /api/competitors` - Yeni yarışmacı ekle
- `PUT /api/competitors/{id}` - Yarışmacı güncelle
- `DELETE /api/competitors/{id}` - Yarışmacı sil

## ⚙️ Çalıştırma

```bash
cd Survivor
dotnet restore
dotnet run --project Survivor/Survivor.csproj
```

## 🛠️ Veritabanı Kurulumu

1. PostgreSQL yüklü olmalı
2. `appsettings.json` içindeki connection string'i düzenleyin
3. Migration'ları çalıştırın:
```bash
Add-Migration InitialCreate
Update-Database
```

## 📚 Öğrenilen Konular

- Entity Framework Core with PostgreSQL
- Npgsql provider kullanımı
- DTO Pattern
- Eager Loading (Include)
- Soft Delete implementation
- JSON Patch operations
- One-to-Many relationships
