<template>
  <div class="Container-fluid home flex-grow-1 d-flex flex-column align-items-center justify-content-center">
    <div class="row">
      <div class="col-md-12">
        <KeepComponent />
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted, ref } from '@vue/runtime-core'
import { AppState } from '../AppState'
import Pop from '../utils/Notifier'

export default {
  name: 'Home',
  setup() {
    const loading = ref(true)
    onMounted(async() => {
      try {
        await keepsService.GetAll()
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
