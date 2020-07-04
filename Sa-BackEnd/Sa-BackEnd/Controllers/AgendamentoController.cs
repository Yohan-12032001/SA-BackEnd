using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Sa_BackEnd.Models;

namespace Sa_BackEnd.Controllers
{   
    [EnableCors(origins:"http://localhost:8080", headers:"*",methods:"*")]
    public class AgendamentoController : ApiController
    {
        SaEntities bd = new SaEntities();
        // GET: api/Agendamento
        public IEnumerable<dynamic> Get()
        {
            var datas = from agend in bd.Agendamento
                        select new { agend.cpf, agend.data, agend.hora };
            return datas;
        }

        // GET: api/Agendamento/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Agendamento
        public string Post([FromBody]Agendamento agend)
        {
            bd.Agendamento.Add(agend);
            bd.SaveChanges();
            return "Salvo com Sucesso";
        }

        // PUT: api/Agendamento/5
        public string Put(int id, [FromBody]Agendamento agend)
        {
            Agendamento alterar = bd.Agendamento.Find(id);
            alterar.data = agend.data;
            alterar.hora = agend.hora;
            alterar.telefone = agend.telefone;
            alterar.cpf = agend.cpf;
            bd.SaveChanges();
            return "Reagendado com Sucesso";
        }

        // DELETE: api/Agendamento/5
        public string Delete(int id)
        {
            bd.Agendamento.Remove(bd.Agendamento.Find(id));
            bd.SaveChanges();
            return "Deletado com Sucesso";
        }
    }
}
