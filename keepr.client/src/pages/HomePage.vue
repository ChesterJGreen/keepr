<template>
  <div class="Container-fluid home flex-grow-1 d-flex flex-column align-items-center justify-content-center">
    <div class="row">
      <div v-if="loading" class="col text-center">
        <i class="fa fa-spinner fa-spin fa-lg" aria-hidden="true"></i>
      </div>
      <div v-else class="col-md-12">
        <KeepComponent v-for="k in keeps" :key="k.id" :keep="k" />
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted, ref } from '@vue/runtime-core'
import { AppState } from '../AppState'
import Pop from '../utils/Notifier'
import { keepsService } from '../services/KeepsService'

export default {
  name: 'Home',
  setup() {
    const loading = ref(true)
    onMounted(async() => {
      try {
        debugger
        console.log('before sending to service in component')
        await keepsService.GetAll()
        console.log('after sending to service')
        loading.value = false
      } catch (error) {
        Pop.toast(error, 'error')
      }
    })
    return {
      loading,
      keeps: computed(() => AppState.account)
    }
  }
}
</script>

<style scoped lang="scss">
.home{
  text-align: center;
  user-select: none;
  > img{
    height: 200px;
    width: 200px;
  }
}
</style>
