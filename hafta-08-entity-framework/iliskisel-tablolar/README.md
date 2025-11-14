# RelationTable 🔗

Entity Framework Core tablo ilişkileri pratik projesi.

## 📋 Proje Açıklaması

Entity Framework Core ile veritabanı tablo ilişkilerini (Relationships) uygulayan Web API projesi. One-to-One, One-to-Many ve Many-to-Many ilişkiler örneklendirilir.

## 🚀 Teknolojiler

- **ASP.NET Core Web API**
- **Entity Framework Core**
- **PostgreSQL (Npgsql)**
- **Code First Migrations**
- **Navigation Properties**

## 🔗 Tablo İlişki Türleri

### 1️⃣ One-to-One (1-1)
```csharp
public class User
{
    public int Id { get; set; }
    public Profile Profile { get; set; }
}

public class Profile
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}
```

### 2️⃣ One-to-Many (1-N)
```csharp
public class Blog
{
    public int Id { get; set; }
    public ICollection<Post> Posts { get; set; }
}

public class Post
{
    public int Id { get; set; }
    public int BlogId { get; set; }
    public Blog Blog { get; set; }
}
```

### 3️⃣ Many-to-Many (N-N)
```csharp
public class Student
{
    public int Id { get; set; }
    public ICollection<Course> Courses { get; set; }
}

public class Course
{
    public int Id { get; set; }
    public ICollection<Student> Students { get; set; }
}
```

## 🎯 Özellikler

- ✅ One-to-One relationship
- ✅ One-to-Many relationship
- ✅ Many-to-Many relationship
- ✅ Foreign Key configuration
- ✅ Navigation properties
- ✅ Cascade delete

## ⚙️ Çalıştırma

```bash
cd RelationTable
dotnet restore
dotnet ef database update
dotnet run --project RelationTable/RelationTable.csproj
```

## 🛠️ Veritabanı Kurulumu

1. PostgreSQL yüklü olmalı
2. Connection string'i güncelleyin
3. Migration'ları çalıştırın:
```bash
Add-Migration InitialCreate
Update-Database
```

## 📚 Öğrenilen Konular

- Entity relationships
- Foreign Key configuration
- Navigation properties
- Fluent API configuration
- Cascade delete options
- Join tables (Many-to-Many)
- DbContext configuration
