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
        SaEntities1 bd = new SaEntities1();
        // GET: api/Agendamento
        public IEnumerable<dynamic> Get()
        {
            var datas = from agend in bd.Agendamento2
                        select new { agend.cpf,agend.hora, agend.telefone, agend.data, agend.nome};
                       
            return datas;
        }

        // GET: api/Agendamento/5
        public string Get(int id)
        {   

            return "value";
        }

        // POST: api/Agendamento
        public string Post([FromBody]Agendamento2 agend)
        {
            var horaMin = new TimeSpan(10, 0, 0);
            var horaMax = new TimeSpan(18, 0, 0);

            var horarioConsulta = agend.hora;

            if(horarioConsulta > horaMax || horarioConsulta < horaMin){
                return "Horario invalido";
            }

            var agendamentos = bd.Agendamento2.ToList();

            bool ExisteAgendamentoDia = agendamentos.Any(x => x.data == agend.data);

            if(ExisteAgendamentoDia){
                return "Já existe uma consulta neste horario";
            }

            bd.Agendamento2.Add(agend);
            bd.SaveChanges();
            return "Salvo com Sucesso";
        }

        // PUT: api/Agendamento/5
        public string Put(int id, [FromBody]Agendamento2 agend)
        {
            Agendamento2 alterar = bd.Agendamento2.Find(id);
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
            bd.Agendamento2.Remove(bd.Agendamento2.Find(id));
            bd.SaveChanges();
            return "Deletado com Sucesso";
        }
    }
}