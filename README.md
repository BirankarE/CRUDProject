# CRUDProject Backend Api App

CRUDProject .Net Core ve EF Core Katmanlı mimari ile oluşturulmuştur. Yapıda Repository ve UnitOfWork Desing Patternlere yer verilmiştir. Proje Müşterilerin Adres bilgilerini temel Crud operasyonları ile yönetmesini sağlamaktadır.
 
### Projeler
- **CRUDProject.Api** :
Endpointlerin bulunduğu katmandır. 

- **CRUDProject.Service** :
Business ile ilgili olan katmandır. Mapping işlemleri ve service implamenttasyonu bu katmanda yapılmıştır. 

- **CRUDProject.Repository** :
Core Katmanını referans alır. Migration dosyaları yer alır. Kullanılan Patternler bu katmanda implament edilmiştir.

- **CRUDProject.Core** :
Ortak sınıf ve modellerin yer aldığı aynı zamanda kullanılan patternlerin interfacelerinin bulunduğu katmandır.


**Database** : Veri tabanı olarak kullanım kolaylığından Sqlite kullanılmıştır. Proje içersinde Seed Datalar mevcuttur. Migration işlemi sonrasında veri tabanında veriler olacaktır.


### Kurulum ve Baslangic
- Proje locale çektikten sonra build edilmeli.
- Package Manager Console ile migration işlemi için ilk olarak "add-migraton init" komutu çılıştırılmalı ve *Build succeeded.* çıktısı görülmeli
- Ardında  "update-migration" komutu çalıştırılmalıdır. İlgili komut başarılı bir şekilde çalışması durumunda *Repository* katmanında *Migration* klasörü ve *Api* projesinda *appDb.db* dosyası oluşmuş olacaktır.
- Migration tamamlandıktan sonra *CRUDProject.Api* projesi "Set as Startup Project" denilip ayağa kaldırılabilir ve *Swagger* üzerinden endpointlere erişebilir ve işlem yapılabilir.

### Endpointler;

- Customer Ve Adres için Get, Post, Put ve Delete methodları vardır. 

- Customer için silme işlemi yapıldığında, ilgili Customer için tüm adresler silinecektir.
- Adres için "Id" ile tek kayıt silme işlemi yapıldığı gibi çoklu Id alıp silme işlemi yapmaktadır.


