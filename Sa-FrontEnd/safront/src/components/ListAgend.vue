<template>
  <div class="lista">
      <br>
      <table class="tabela">
          <thead>
              <tr>
                  <th>Nome</th>
                  <th>CPF</th>
                  <th>Telefone</th>
                  <th>Data</th>
                  <th>Hora</th>
                  <th class="acao">Ações</th>
              </tr>
          </thead>
          <tbody>
              <tr :value="agend.id" v-for="agend in agendamentos" :key="agend.id" class="dados">
                  <td>{{agend.nome}}</td>
                  <td>{{agend.cpf}}</td>
                  <td>{{agend.telefone}}</td>
                  <td>{{agend.data}}</td>
                  <td>{{agend.hora}}</td>
                  <td class="btn"><button class="buttonDel" @click="data">Deletar</button></td>
              </tr>
          </tbody>
      </table>


  </div>
</template>

<script>
const axios=require('axios')
export default {
 data: function(){
    return{
        agendamentos:[]
    }
 }, methods: {
     data: function(){
         console.log(this.agendamentos.cpf
         )
     }
 }, mounted(){
     axios.get("https://localhost:44337/api/Agendamento").then(agend =>this.agendamentos=agend.data)
 }
}
</script>

<style>
.btn{
    padding: 0 30px;
}
.buttonDel{
  background-color: #008CBA; /* Red */
}
table {
  border-collapse: collapse;
  width: 100%;
}

th, td {
  padding: 8px;
  text-align: left;
  border-bottom: 1px solid #ddd;
}
.acao{
    padding: 0 0 0 70px;
}
tr:hover {background-color:#f5f5f5;}
</style>