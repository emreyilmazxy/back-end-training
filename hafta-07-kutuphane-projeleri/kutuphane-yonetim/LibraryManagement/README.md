# 📚 Library Management System (MVC Projesi)

Bu proje, ASP.NET Core MVC kullanılarak geliştirilmiş basit bir kütüphane yönetim sistemidir. Projede kitaplar ve yazarlar için CRUD (Create, Read, Update, Delete) işlemleri gerçekleştirilmiştir.

## 🚀 Proje Özellikleri

- 📖 Kitap ekleme, düzenleme, silme ve detay görüntüleme
- 👤 Yazar ekleme, düzenleme, silme ve detay görüntüleme
- 📄 Mock veri listeleri ile çalışır (veritabanı gerektirmez)
- ✨ Partial View yapısı ile formlar sadeleştirilmiştir
- 🎨 Tüm ön yüz (UI) ve stillendirme işlemleri, yapay zeka desteğiyle oluşturulmuştur

## 🛠️ Kullanılan Teknolojiler

- ASP.NET Core MVC
- Razor View Engine
- C#
- HTML/CSS
- Bootstrap 5
- Yapay Zeka ile oluşturulmuş özel UI stilleri (`site.css` içinde)

## 📂 Klasör Yapısı

```bash
LibraryManagement/
├── Controllers/
│   ├── BookController.cs
│   └── AuthorController.cs
├── Models/
│   ├── Author.cs
│   ├── Book.cs
│   ├── ViewModel klasörleri
│   └── MockData.cs
├── Views/
│   ├── Author/
│   ├── Book/
│   └── Shared/ (PartialView'ler)
├── wwwroot/
│   └── css/
│       └── site.css
