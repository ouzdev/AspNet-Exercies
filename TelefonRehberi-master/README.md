# Telefon Rehberi Projesi

## Projenin İsmi
Gerçekleştirilmesi istenen projenin ismi “Telefon Rehberi”dir.
## Proje Amacı
Bir şirkette çalışanların telefon numaralarının ortak bir havuzda toplanması ve gerektiği zaman
buradan istenilen kişiye ait telefon numarasının öğrenilebilmesini sağlamak.
## Genel Özellikler
### Sisteme Erişim
Sisteme erişim internet üzerinden internet tarayıcı ile olacaktır.
3.2 Kullanılacak Teknolojiler
.Net Framework 4,5+ veya ASP.NET Core 2,2+ ve SQL Server 2012 (veya üzeri)
kullanılacaktır. Javascript framework kullanımı geliştirecek kişinin tercihine bırakılmıştır.
Bunların dışında ücretli bir component kullanımı istenmemektedir. Veritabanı erişimi için Entity
Framework kullanımı tercih edilmektedir.
Projenin MVC 5 (veya üzeri versiyon) ve Razor kullanılarak hazırlanması gerekmektedir.
4 Kapsam
* Sistem iki farklı arayüze sahip olacaktır.
* Herkese açık arayüz (bundan sonra PublicUI olarak adlandırılacaktır)
* Sadece Admin tarafından girilebilen arayüz (bundan sonra AdminUI olarak
adlandırılacaktır)
* Çalışanın ad, soyad, telefon, departman ve yönetici bilgileri sistemde yer alacaktır.
* PublicUI sadece sistemde kayıtlı çalışanların adlarını ve telefon numaralarını
barındıran bir liste gösterecektir. Buradan bir çalışan seçilmesi durumunda çalışana ait
detay bilgi gösterimi yapılacaktır.
* AdminUI için gerek şifre değiştirilebilir olacaktır.
* AdminUI arayüzünden yeni çalışan girişi yapılabilecektir.
* Çalışanın ad, soyad ve telefon bilgisinin girilmesi zorunludur.
* Departman bilgisi, veritabanından alınarak dropdownlist’ten seçtirilecektir.
* Yönetici bilgisi, dropdownlist’ten seçtirilecektir. Bu dropdownlist sistemde mevcut
bulunan çalışan kayıtları üzerinden doldurulacaktır.
* Çalışan kayıtları AdminUI üzerinden düzenlenebilecek ve silinebilecektir. Kural olarak
eğer ilgili çalışan başka bir çalışanın yöneticisi statüsünde bulunuyor ise silme işlemine
izin verilmeyecektir.
* Sistemde kayıtlı bulanan departmanlar yönetilebilir olacaktır. Ekleme, Düzenleme ve
Silme işlemlerine izin verilecektir. Kural olarak ilgili departmanın altında tanımlı
çalışan varsa departman silinemeyecektir.


## Uygulamaya Ait Ekran Görüntüleri
![](https://i.imgyukle.com/2020/02/12/nI8CHH.png)
![](https://i.imgyukle.com/2020/02/12/nI8S1A.png)
![](https://i.imgyukle.com/2020/02/12/nI8ykU.png)
![](https://i.imgyukle.com/2020/02/12/nI8uw1.png)
![](https://i.imgyukle.com/2020/02/12/nI8Q3o.png)
![](https://i.imgyukle.com/2020/02/12/nI85xI.png)
