# Akbank .Net Bootcamp Cohort Ödevi 1

Akbank ve patikadev tarafından gerçekleştirilen Asp.Net eğitimi sürecinde verilen cohort üzerinden verilen ilk hafta ödevi. 

## Bizden istenilenler:
 -  Rest standartlarna uygun olmalıdır. 
 -  GET,POST,PUT,DELETE,PATCH methodları kullanılmalıdır. 
 -  Http status code standartlarına uyulmalıdır. Error Handler ile 500, 400, 404, 200, 201 hatalarının standart format ile verilmesi 
 -  Modellerde zorunlu alanların kontrolü yapılmalıdır. 
 -  Routing kullanılmalıdır. 
 -  Model binding işlemleri hem body den hemde query den yapılacak şekilde örneklendirilmelidir. Bonus: 
 -  Standart crud işlemlerine ek olarak, listeleme ve sıralama işlevleride eklenmelidir. Örn: /api/products/list?name=abc 

### Kullanılan Metotlar

- `GET /BankAccaunts` :

  Tüm banka hesaplarını almak için kullanılan method.
  
- `GET /AccountsByHolder/?holder={holderName}`:

  Belirli bir hesap sahibine ait hesapları almak için bu method'u kullanın. `holderName` parametresi olarak hesap sahibinin adını belirtin.

- `GET /BankAccaunts/{id}`:

  Belirli bir banka hesabını almak için bu method'u kullanın. `id` parametresi olarak hesap ID'sini belirtin.

- `POST /BankAccaunts`:

  Yeni bir banka hesabı oluşturmak için bu method'u kullanın. JSON formatında yeni hesap bilgilerini gönderin.

- `PUT /BankAccaunts/{id}`:

  Belirli bir banka hesabını güncellemek için bu method'u kullanın. `id` parametresi olarak güncellenecek hesabın ID'sini belirtin. JSON formatında güncel bilgileri gönderin.

- `DELETE /BankAccaunts/{id}`:

  Belirli bir banka hesabını silmek için bu method'u kullanın. `id` parametresi olarak silinecek hesabın ID'sini belirtin.

- `PATCH /BankAccaunts/{id}`:

  Belirli bir banka hesabını kısmi olarak güncellemek için bu method'u kullanın. `id` parametresi olarak güncellenecek hesabın ID'sini belirtin. Güncellemeleri JSON Patch formatında gönderin. 
  - Verilen ID tegerine göre tek özelligin patch edilmesi
    ```javascript
    {
        "path": "/accountHolder",
        "op": "replace",
        "value": "Mehmet C. patched"
    }
    ```
    - Verilen ID tegerine göre birden çok özelligin patch edilmesi
    ```javascript
    [
        {
            "path": "/accountHolder",
            "op": "replace",
            "value": "Mehmet C. patched"
        },
        {
            "path": "/accountBalance",
            "op": "replace",
            "value": 34567
        }
    ]
    ```

## Hata Durumları

- `404 Not Found`: İstenen kaynak bulunamadı.
- `400 Bad Request`: İstek geçersiz veya eksik bilgi içeriyor.
- `500 Internal Server Error`: Sunucu hatası nedeniyle işlem gerçekleştirilemedi.

## Diger durumlar
- `200 OK`: Yapılan istek başarılı.
- `201 Created`: Kayıt başarılı.

## Database işlemleri ve Kullanılan dosyalar:
Bu projede database ve fonksiyonlarının oluşturulması için **Microsoft.EntityFrameworkCore.InMemory**, **Microsoft.EntityFrameworkCore**paketleri  kullanıldı.  

### BankDbContext :
Bu Dosya BankAccaunt sınıfının Database eklenmesini ve oluşturulan fonksiyonlarla table üzerinde işlem yapılmasını sağlar.

### DataGenerator :
-   Proje başlarken örnek verilerin yüklenmesi.
-   Çok sayıda olan verilen otomatik olarak yüklenmesi için kullanılan sınıf.



