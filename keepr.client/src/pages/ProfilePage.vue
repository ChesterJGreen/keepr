<template>
  <div class="profile">
    <h1>This is the profile page</h1>
  </div>
</template>

<script>
import { computed, onMounted, ref } from '@vue/runtime-core'
import { AppState } from '../AppState'
import Pop from '../utils/Notifier'
import { accountService } from '../services/AccountService'
import { route, useRoute } from "vue-router"
export default {
  name: 'ProfilePage',
  const route: useRoute,
  setup() {
    const route: useRoute,
    const loading = ref(true)
    onMounted(async() => {
      try {
        await accountService.getAccount(route.params.id)
        loading.value = false
      } catch (error) {
        Pop.toast(error, 'error')
      }
    })
    return {
      account: computed(() => AppState.account)
    }
  },
  components: {}
}
</script>
