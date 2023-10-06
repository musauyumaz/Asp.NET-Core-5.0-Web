using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

#region Secret Manager Verileri Nerede Depolamaktadır?
//C:\Users\{username}\AppData\Roaming\Microsoft\UserSecrets\{secret id} buranın altında uygulamanıza ait development ortamındaki secret manager dosyalarını bulabilirsiniz. 
#endregion

namespace SecretManagerExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomesController : ControllerBase
    {
        #region secrets.json'dan Veri Okuma
        //readonly IConfiguration _configuration;

        //public HomesController(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        //public void Index()
        //{
        //    string kullanici = _configuration["MailBilgileri:Kullanici"];
        //    string sifre = _configuration["MailBilgileri:Sifre"];
        //} 
        #endregion
        #region SqlConnectionStringBuilder Sınıfının Kullanımı(Genel Kültür)
        private readonly IConfiguration _configuration;

        public HomesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Index2()
        {
            string connection = _configuration.GetConnectionString("SQL");
            SqlConnectionStringBuilder builder = new(connection);
            builder.UserID = _configuration["SQL:KullaniciAdi"];
            builder.Password = _configuration["SQL:Sifre"];

            string x = builder.ConnectionString;
        } 
        #endregion
    }
}
