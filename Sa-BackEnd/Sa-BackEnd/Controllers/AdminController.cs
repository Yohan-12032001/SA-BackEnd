using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using System.Web.Http.Cors;
using Sa_BackEnd.Models;

namespace Sa_BackEnd.Controllers
{
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
    public class AdminController : ApiController
    {
        SaEntities1 bd = new SaEntities1();
        // GET: api/Admin
        public IEnumerable<dynamic> Get()
        {
            var admin = from adm in bd.adm
                        select new { adm.nome, adm.senha };


            return admin;
        }

        // GET: api/Admin/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Admin
        public dynamic Post([FromBody]adm value)
        {
            SaEntities1 bd = new SaEntities1();

            var login = bd.adm.FirstOrDefault(x => x.nome == value.nome && x.senha == value.senha);

            if (login == null)
            {
                return "Wrong Login!";
            }
            else
            {
                return true;
            }

        }

        // PUT: api/Admin/5
        public dynamic Put(int id, [FromBody]adm value, string newPassword)
        {

            adm alterar = bd.adm.Find(id);

            var verifyAccount = bd.adm.FirstOrDefault(x => x.nome == value.nome && x.senha == value.senha);

            if (verifyAccount != null)
            {
                alterar.senha = newPassword;
                bd.SaveChanges();
                return "foi ou n carai";
            }
            return "senhas incorretas!";

            
        }

        // DELETE: api/Admin/5
        public void Delete(int id)
        {
        }
    }
}
