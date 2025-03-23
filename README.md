Arac Otomasyon Sistemi
Bu proje, araçların veritabanı üzerinde yönetimini sağlamak amacıyla geliştirilmiştir. Sistemde araç ekleme, silme, güncelleme ve çeşitli filtreleme işlemleri yapılabilmektedir. SQL Server ile entegre çalışarak araç verilerini yönetir ve görüntüler. Bu README, projeyi kurmak, kullanmak ve SQL prosedürleri hakkında bilgi verir.

İçerik
Proje Hakkında

Proje Kurulumu

Gerekli Yazılımlar

Proje Yükleme

Prosedürler

aractablo

otomatik

manuell

satılık

kiralık

arama

.bak Yedekleme Dosyasının Kurulumu

Proje Hakkında
Arac Otomasyon Sistemi, araçların veritabanında tutulmasını ve kolayca yönetilmesini sağlayan bir uygulamadır. Kullanıcılar araçları ekleyebilir, silebilir, güncelleyebilir ve filtreleyebilir. SQL Server veritabanı kullanılarak araçların çeşitli özellikleri (marka, model, üretim yılı, vites tipi, envanter durumu vb.) yönetilmektedir.

Proje Kurulumu
Gerekli Yazılımlar
Bu projeyi çalıştırmak için aşağıdaki yazılımların bilgisayarınızda kurulu olması gerekir:

Visual Studio: C# Windows Forms projesi için gereklidir.

SQL Server: Veritabanı yönetimi için gereklidir.

SQL Server Management Studio (SSMS): SQL Server'ı yönetmek ve prosedürleri tanımlamak için gereklidir.

Proje Yükleme
Proje Dosyasını İndirin: GitHub reposundaki proje dosyalarını bilgisayarınıza indirin.

SQL Server Veritabanı Kurulumu:

SQL Server'ı yükleyin ve SQL Server Management Studio'yu açın.

Veritabanını oluşturun ve aşağıdaki .bak yedeğini yükleyin (aşağıda açıklanacaktır).

Projenin Bağlantısını Yapın: Proje, veritabanına bağlanabilmesi için SQL Server bağlantı dizesi gerektirir. Form1.cs içinde SqlConnection satırını aşağıdaki şekilde güncelleyin:

csharp
SqlConnection baglanti = new SqlConnection("Data Source=YOUR_SERVER_NAME;Initial Catalog=araclar;Integrated Security=True");
Projeyi Visual Studio'da Çalıştırın:

Visual Studio'yu açın.

Projeyi açın.

Çalıştırmaya başlamak için F5 tuşuna basın.
