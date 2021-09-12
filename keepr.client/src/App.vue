<template>
  <header>
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>
  <footer>
    <div class="bg-dark lighten-40 text-light text-center p-2">
      <span class="text-dark"> Have you tried saving it to your vault yet?</span>
    </div>
  </footer>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
export default {
  name: 'App',
  setup() {
    return {
      appState: computed(() => AppState)
    }
  }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";
.action {
  :hover{
    cursor: pointer;
  }
}
a {
  text-decoration: none;
}

</style>
