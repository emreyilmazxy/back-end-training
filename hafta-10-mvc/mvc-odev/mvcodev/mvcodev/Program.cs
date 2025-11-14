var builder = WebApplication.CreateBuilder(args); // UYGULAMA OLUÞTURUCU NESNESÝNÝ OLUÞTURUR.UYGULAMAYI YAPILANDIRMAK ÝÇÝN KULLANILIR.  


//Add services to the container.
builder.Services.AddControllersWithViews(); // KONTROLÖR VE GÖRÜNÜMLERÝ ÝÇEREN SERVÝSLERÝ VE ASP.NET CORE ÝÇÝN GEREKLÝ SERVÝSLERÝ EKLER.


var app = builder.Build();  //UYGULAMA NESNESÝNÝ OLUÞTURUR YAPILANDIRILMIÞ UYGULAMA OLUÞTURUR.

if (!app.Environment.IsDevelopment())
{ 
   app.UseExceptionHandler("/Home/Error"); // HATA YAKALAMA ÝÞLEVÝ EKLER. UYGULAMA GELÝÞTÝRME MODUNDA DEÐÝLSE, HATA YAKALAMA ÝÞLEVÝ EKLER.
    app.UseHsts(); // HTTP STRICT TRANSPORT SECURITY (HSTS) KULLANIMINI ETKÝNLEÞTÝRÝR. BU, UYGULAMANIN HTTPS ÜZERÝNDEN ÇALIÞMASINI ZORUNLU KILAR.
}

app.UseHttpsRedirection(); // HTTPS YÖNLENDÝRMESÝNÝ ETKÝNLEÞTÝRÝR. HTTP ÝSTEÐÝ GELDÝÐÝNDE HTTPS'YE YÖNLENDÝRÝR.
app.UseStaticFiles(); //statik dosyalara hizmet verir. Örneðin, CSS, JavaScript ve resimler gibi dosyalarýn sunulmasýný saðlar. 

app.UseRouting(); // YOL HARÝTASI OLUÞTURMA ÝÞLEVÝNÝ ETKÝNLEÞTÝRÝR. UYGULAMA ÝÇÝN YOL HARÝTASI OLUÞTURUR. urlarý ve HTTP YÖNLENDÝRMELERÝNÝ YÖNETÝR.
app.UseAuthorization(); // yetkilendirme iþlevini etkinleþtirir. UYGULAMA ÝÇÝN YETKÝLENDÝRMEYÝ YÖNETÝR. KULLANICI GÝRÝÞÝ VE YETKÝLERÝNÝ DENETLER.

app.MapControllerRoute(
    name :"default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    ); //kontrolör rotalarýný haritalar.uygulama içindeki kontrolörlere yönlendirme yapar.

 

app.Run(); // UYGULAMAYI ÇALIÞTIRIR. UYGULAMA ÝÇÝN GEREKEN TÜM BÝLENLERÝ YÜKLER VE UYGULAMAYI BAÞLATIR. BU, ASP.NET CORE UYGULAMASININ ÇALIÞMASINI SAÐLAR.

//-----------------------kavramlarýn açýklamalarý---------------------------------  

// controller :kullanýcý isteklerini karþýlayan ve iþleyen sýnýftýr. views ile model arasýndaki köprüdür.
//action:contorller içinde bulunun doðrudan çalýþtýrýlan methotlardýr kullanýcý isteklerine yanýt verirler.
//model :veri yapýlarýdýr ve uygulamanýn veri katmanýný temsil eder. veritabaný ile etkileþimde bulunur ve verileri iþler.
//view : kullacý arayüzünü temsil eder.kullanýcýya gösterilecek sayfalarý oluþturur. HTML + razor kullanýlarak oluþturulur.
//razor : html içine c# kodu kullanabilmeyi saðlayan  bir þablon görüntü motorudur.
//razýrview : razor ile oluþturulan görünümlerdir. .cshtml uzantýsýna sahiptirler ve kullanýcý arayüzünü oluþtururlar.
//wwwroot: statik dosyalarýn (css,js,resimler vb) için kullanýlan kasördür. ASP.NET Core uygulamalarýnda statik dosyalarýn sunulmasý için kullanýlýr.
//builder.build(); uygulamayý yapýlandýrýr ve çalýþmaya hazýr hale getirir. Uygulama için gerekli tüm bileþenleri ve hizmetleri oluþturur.
//app.run();: uygulamyý baþlatýr ve dinlemeye baþlar. Uygulama, gelen istekleri iþlemek için hazýr hale gelir ve çalýþmaya baþlar.
