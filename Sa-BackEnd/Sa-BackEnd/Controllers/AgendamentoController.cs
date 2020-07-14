using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.Ajax.Utilities;
using Sa_BackEnd.Models;

namespace Sa_BackEnd.Controllers
{
    [EnableCors(origins: "http://localhost:8080", headers: "*", methods: "*")]
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

            var agendamentos = bd.Agendamento2.ToList();
            bool ExisteAgendamentoDia = agendamentos.Any(x => x.data == agend.data);
            var horaMin = new TimeSpan(10, 0, 0);
            var horaMax = new TimeSpan(18, 0, 0);

            var horarioConsulta = agend.hora;

            if (horarioConsulta > horaMax || horarioConsulta < horaMin) {
                return "Horario invalido";
            }

            if (bd.Agendamento2.Sql.Contains(agend.cpf) || ExisteAgendamentoDia)
            {

                return "Você Já tem um horario marcado!";
            }


            if (agend.data == null || agend.cpf == "" || agend.hora == null || agend.telefone == "" || agend.nome=="")
            {
                return "ta errado isso ae";
            }


            bd.Agendamento2.Add(agend);

            bd.SaveChanges();
            return "Salvo com Sucesso";
        }

        // PUT: api/Agendamento/5
        public string Put(int id, [FromBody]Agendamento2 agend)
        {

            Agendamento2 alterar = bd.Agendamento2.Find(id);

            var agendamentos = bd.Agendamento2.ToList();
            bool ExisteAgendamentoDia = agendamentos.Any(x => x.data == agend.data);
            var horaMin = new TimeSpan(10, 0, 0);
            var horaMax = new TimeSpan(18, 0, 0);

            var horarioConsulta = agend.hora;

            if (horarioConsulta > horaMax || horarioConsulta < horaMin)
            {
                return "Horario invalido";
            }

            if (ExisteAgendamentoDia)
            {
                return "Já existe uma consulta neste horario";
            }

            if (bd.Agendamento2.Sql.Contains(agend.cpf) || ExisteAgendamentoDia)
            {

                return "Você Já tem um horario marcado!";
            }

            if (agend.data == null || agend.cpf == "" || agend.hora == null || agend.telefone == "" || agend.nome=="")
            {
                return "ta errado isso ae";
            }

           
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