using Ab_pk_week1.DBOperations;
using Ab_pk_week1.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace Ab_pk_week1.Controllers
{

    [ApiController]
    [Route("[controller]s")]
    public class BankAccauntController : ControllerBase
    {
        private readonly BankDbContext dbcontext;

        public BankAccauntController(BankDbContext bankDbContext)
        {
            this.dbcontext = bankDbContext;
        }

        // GET: get BankAccaunts
        //Tüm banka hesaplarını almak için kullanılan method.
        [HttpGet]
        public ActionResult<List<BankAccount>> GetBankAccounts()
        {
            try
            {
                var _list = dbcontext.BankAccounts.OrderBy(x => x.accountId).ToList();
                if (_list == null)
                {
                    return NotFound(); // 404 Not Found : İstenen kaynak bulunamadı.
                }
                return Ok(_list); // 200 OK: Yapılan istek başarılı.
            }
            catch (Exception ex)
            {// 500: Sunucu hatası nedeniyle işlem
                return StatusCode(500, $"Internal server error: {ex.Message}"); 
            }
        }

        // GET: get BankAccaunts
        //Belirli bir hesap sahibine ait hesapları almak için bu method'u kullanın.
        //`holderName` parametresi olarak hesap sahibinin adını belirtin.
        [HttpGet("/AccountsByHolder/")]
        public ActionResult<List<BankAccount>> GetBankAccountsByHolder([FromQuery] string holder)
        {
            try
            {
                var _list = dbcontext.BankAccounts.Where(x=>x.accountHolder== holder).OrderBy(x => x.accountId).ToList();
                if (_list == null)
                {
                    return NotFound(); // 404 Not Found : İstenen kaynak bulunamadı.
                }
                return Ok(_list); // 200 OK: Yapılan istek başarılı.
            }
            catch (Exception ex)
            {// 500: Sunucu hatası nedeniyle işlem
                return StatusCode(500, $"Internal server error: {ex.Message}"); 
            }
        }

        // GET: get BankAccaunt from id
        //Belirli bir banka hesabını almak için bu method'u kullanın.
        //`id` parametresi olarak hesap ID'sini belirtin.
        [HttpGet("{id}")]
        public ActionResult<BankAccount> GetBankAccountById([FromRoute]int id)
        {

            try
            {
                var account = dbcontext.BankAccounts.Where(x => x.accountId == id).SingleOrDefault();
                if (account == null)
                {
                    return NotFound(); //404 Not Found : İstenen kaynak bulunamadı.
                }

                return Ok(account); //200 OK: Yapılan istek başarılı.
            }
            catch (Exception ex)
            {// 500: Sunucu hatası nedeniyle işlem
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Post: create a BankAccaunt
        //Yeni bir banka hesabı oluşturmak için bu method'u kullanın.
        //JSON formatında yeni hesap bilgilerini gönderin.
        [HttpPost]
        public IActionResult AddBankAccount([FromBody]BankAccount newAccount)
        {
            try
            {
                if(newAccount == null)
                {
                    return BadRequest(); // 400 Bad Request: İstek geçersiz veya eksik bilgi içeriyor.
                }

                dbcontext.Add(newAccount);
                dbcontext.SaveChanges();

                return new ObjectResult(newAccount)
                {
                    StatusCode = StatusCodes.Status201Created // 201 Created: Kayıt başarılı.
                };
            }
            catch (Exception ex)
            {// 500: Sunucu hatası nedeniyle işlem
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: update a BankAccaunt
        //Belirli bir banka hesabını güncellemek için bu method'u kullanın.
        //`id` parametresi olarak güncellenecek hesabın ID'sini belirtin.
        //JSON formatında güncel bilgileri gönderin.
        [HttpPut("{id}")]
        public IActionResult UpdateBankAccount(int id, [FromBody]BankAccount updateAccount)
        {
            try
            {
                if (id != updateAccount.accountId)
                {
                    return BadRequest();// 400 Bad Request: İstek geçersiz veya eksik bilgi içeriyor.
                }

                var account = dbcontext.BankAccounts.Where(x => x.accountId == id).SingleOrDefault();

                if (account == null)
                {
                    return NotFound(); // 404 Not Found : İstenen kaynak bulunamadı.
                }

                dbcontext.Update(account);
                dbcontext.SaveChanges();
                return Ok(); //200 OK: Yapılan istek başarılı.
            }
            catch (Exception ex)
            {// 500: Sunucu hatası nedeniyle işlem
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: delete a BankAccaunt
        //Belirli bir banka hesabını silmek için bu method'u kullanın.
        //`id` parametresi olarak silinecek hesabın ID'sini belirtin.
        [HttpDelete("{id}")]
        public IActionResult DeleteBankAccount(int id)
        {
            try
            {
                var account = dbcontext.BankAccounts.Where(x => x.accountId == id).SingleOrDefault();

                if (account == null)
                    return NotFound(); //404 Not Found : İstenen kaynak bulunamadı.

                dbcontext.BankAccounts.Remove(account);
                dbcontext.SaveChanges();
                return Ok(); //200 OK: Yapılan istek başarılı.
            }
            catch (Exception ex)
            {// 500: Sunucu hatası nedeniyle işlem
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        // PATCH: patch a BankAccaunt
        // Belirli bir banka hesabını kısmi olarak güncellemek için bu method'u kullanın.
        // `id` parametresi olarak güncellenecek hesabın ID'sini belirtin.
        // Güncellemeleri JSON Patch formatında gönderin. 
        // Örnek Json dosyası README dosyasında bulunuyor.
        [HttpPatch("{id}")]
        public IActionResult PatchBankAccount(int id, [FromBody] JsonPatchDocument<BankAccount> updateAccount)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();// 400 Bad Request: İstek geçersiz veya eksik bilgi içeriyor.
                }
                var account = dbcontext.BankAccounts.Where(x => x.accountId == id).SingleOrDefault();

                if (account == null) 
                { 
                    return NotFound();//404 Not Found: İstenen kaynak bulunamadı.
                }

                dbcontext.Update(account);
                dbcontext.SaveChanges();
                return Ok(); //200 OK: Yapılan istek başarılı.
            }
            catch (Exception ex)
            {// 500: Sunucu hatası nedeniyle işlem
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
