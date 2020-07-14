<template>
  <div class="agendamento">
      <b>Nome: </b>
      <input type="text" placeholder="Digite seu Nome" v-model="nome" class="nome"><br><br>

      <b>CPF: </b>
      
  <input type="text" v-mask="'###.###.###-##'" placeholder="Digite seu CPF" v-model="cpf" class="cpf"><br><br>

      <b>Telefone: </b>
      <input type="text" v-mask="['(##) ####-####', '(##) #####-####']" placeholder="Digite seu Telefone" v-model="telefone"><br><br> 

      <b class="dataTxt">Data: </b>
      <input type="date" v-model="data" class="data"><br><br>

      <b>Hora: </b>
      <input type="time" v-model="hora" class="hora"><br><br>

      <button @click="salvar">Enviar</button>
  </div>
</template>

<script>
const axios= require('axios')



export default {
  data: function() {
    return{
      nome:'',
      cpf:'',
      telefone:'',
      data:'',
      hora:'',
    }
  }, methods: {
    salvar: function(){
        axios.post("https://localhost:44337/api/Agendamento",{
          nome:this.nome,
          cpf:this.cpf,
          telefone:this.telefone,
          data:this.data,
          hora:this.hora,
        }).then(resp => alert(resp.data))

    }
  }, mounted(){
    
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
.nome{
  margin-left: 20px;
}
.cpf{
  margin-left: 34px;
}
.horaTxt{
  margin-left: 10px;
}
.hora{
  margin-right: 70px;
}

button{
  background-color: #4CAF50; /* Green */
  border: none;
  border-radius: 5px;
  color: white;
  padding: 8px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 16px;
  margin: 4px 2px;
  cursor: pointer;
  margin-left: 20px;
  width: 90px;
  height: 30px;
}
</style>
