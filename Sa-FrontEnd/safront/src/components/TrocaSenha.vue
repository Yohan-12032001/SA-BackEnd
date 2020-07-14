<template>
  <div class="TrocaSenha"><br>  
      <b>Nome: </b>
      <input type="text" placeholder="Digite o Nome" class="nome"><br>
      <b>Senha Antiga: </b>
      <input type="password" placeholder="Digite a Senha Antiga"><br>
      <b>Senha Nova: </b>
      <input type="password" placeholder="Digite a Nova Senha" class="nova"><br>
      <button>Enviar</button>
  </div>
</template>

<script>
export default {

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