<template>
  <div class="Admin">

      <br>
      <b>Nome: </b>
      <input type="text" placeholder="Nome" v-model="nomeDigit"><br>
      <b>Senha: </b>
      <input type="password" placeholder="Senha" v-model="senhaDigit"><br><br>

      
      <button @click="Entrar">Entrar</button><br>
    
      <router-link to="/tSenha" class="link">Trocar Senha</router-link> <br>
           
  </div>
</template>

<script>
const axios= require('axios')
export default {
 data: function(){
     return{
         nomeDigit:'',
         senhaDigit:'',

  
     }
 }, methods:{
     Ir: function(){
         <router-link to="/tSenha" class="link">Trocar Senha</router-link> 
     },
     Entrar:function(){
         
         axios.post("https://localhost:44337/api/Admin",{
             nome:this.nomeDigit,
             senha:this.senhaDigit
         }).then(resp=>{
             if(resp.data==true){
             window.location.href = "http://localhost:8080/list"
         }else{
             alert("Login ou Senha Invalido!!!")
         }
         });
         
         
         

         
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