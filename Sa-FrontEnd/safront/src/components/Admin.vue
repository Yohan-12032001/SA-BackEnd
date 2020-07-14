<template>
  <div class="Admin">
      <br>
      <b>Nome: </b>
      <input type="text" placeholder="Nome"><br>
      <b>Senha: </b>
      <input type="password" placeholder="Senha"><br><br>
      <router-link to="/list" tag="button">Entrar</router-link><br>
      <router-link to="/tSenha" class="link">Trocar Senha</router-link> 
      

  </div>
</template>

<script>
export default {
 data: function(){
     return{

     }
 }, methods:{
     Ir: function(){
         <router-link to="/tSenha" class="link">Trocar Senha</router-link> 
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
.link{
    margin-left: 15px;
}
</style>