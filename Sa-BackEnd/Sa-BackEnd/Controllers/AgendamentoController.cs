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
<<<<<<< HEAD
            var datas = from agend in bd.Agendamento2
                        select new { agend.cpf,agend.hora, agend.telefone, agend.data, agend.nome};
                       
=======
            var datas = from agend in bd.Agendamento
                        select new {agend.cpf, agend.data, agend.hora, agend.telefone };
>>>>>>> bee681380a052da0bc520e2640ab806158b55c9a
            return datas;
        }

        // GET: api/Agendamento/5
        public string Get(int id)
        {

            return "value";
        }

        // POST: api/Agendamento
<<<<<<< HEAD
        public string Post([FromBody]Agendamento2 agend)
=======
        public string Post([FromBody] Agendamento agend)
>>>>>>> bee681380a052da0bc520e2640ab806158b55c9a
        {

            var agendamentos = bd.Agendamento.ToList();
            bool ExisteAgendamentoDia = agendamentos.Any(x => x.data == agend.data);
            var horaMin = new TimeSpan(10, 0, 0);
            var horaMax = new TimeSpan(18, 0, 0);

            var horarioConsulta = agend.hora;

            if (horarioConsulta > horaMax || horarioConsulta < horaMin) {
                return "Horario invalido";
            }

<<<<<<< HEAD
            var agendamentos = bd.Agendamento2.ToList();
=======
            if (ExisteAgendamentoDia) {
                return "Já existe uma consulta neste horario";
            }
>>>>>>> bee681380a052da0bc520e2640ab806158b55c9a

            if (bd.Agendamento.Sql.Contains(agend.cpf) || ExisteAgendamentoDia)
            {

                return "Você Já tem um horario marcado!";
            }

            if (agend.data == null || agend.cpf == null || agend.hora == null || agend.telefone == null)
            {
                return "ta errado isso ae";
            }

<<<<<<< HEAD
            bd.Agendamento2.Add(agend);
=======
>>>>>>> bee681380a052da0bc520e2640ab806158b55c9a
            bd.SaveChanges();
            return "Salvo com Sucesso";
        }

        // PUT: api/Agendamento/5
        public string Put(int id, [FromBody]Agendamento2 agend)
        {
<<<<<<< HEAD
            Agendamento2 alterar = bd.Agendamento2.Find(id);
=======
            var agendamentos = bd.Agendamento.ToList();
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

            if (bd.Agendamento.Sql.Contains(agend.cpf) || ExisteAgendamentoDia)
            {

                return "Você Já tem um horario marcado!";
            }

            if (agend.data == null || agend.cpf == null || agend.hora == null || agend.telefone == null)
            {
                return "ta errado isso ae";
            }

            Agendamento alterar = bd.Agendamento.Find(id);
>>>>>>> bee681380a052da0bc520e2640ab806158b55c9a
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