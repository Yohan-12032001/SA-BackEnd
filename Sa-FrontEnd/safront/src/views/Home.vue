<template>
  <div class="home">
    <img alt="Vue logo" src="../assets/logo2.jpg" width="150px">
    <Agendamento/>
  </div>
  
</template>

<script>
// @ is an alias to /src
import Agendamento from '@/components/Agendamento.vue'
//HelloWorld
export default {
  name: 'Home',
  components: {
    Agendamento
  }
}
</script>
