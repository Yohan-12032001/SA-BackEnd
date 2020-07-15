<template>
  <div class="TrocaSenha"><br>  
      <b>Nome: </b>
      <input type="text" placeholder="Digite o Nome" class="nome" v-model="nome"><br>
      <b>Senha Antiga: </b>
      <input type="password" placeholder="Digite a Senha Antiga" v-model="senha"><br>
      <b>Senha Nova: </b>
      <input type="password" placeholder="Digite a Nova Senha" class="nova" v-model="newPassword"><br>
      <button @click="enviar">Enviar</button>
  </div>
</template>

<script>
const axios= require('axios')
export default {
  
  data:function(){
    return{
      nome:'',
      senha:'',
      newPassword:'',
      id:1
    }
  },methods:{
    enviar:function(){
      axios.put(`https://localhost:44337/api/Admin/${this.id}`,{   
        nome:this.nome,
        senha:this.senha,
        newPassword:this.newPassword
      }).then(resp=>alert(resp.data))
    }
}
}
</script>

<style>
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
.nome{
    margin-left: 55px;
}
.nova{
    margin-left: 10px;
}
</style>