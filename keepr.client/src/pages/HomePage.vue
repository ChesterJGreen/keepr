<template>
  <div class="container-fluid home flex-grow-1  align-items-center justify-content-center px-5">
    <div class="row m-0 mt-5 justify-content-between px-5">
    </div>
    <div class="card-columns position-relative">
      <div v-if="loading" class="col-md-12 text-center">
        <i class="fa fa-spinner fa-spin fa-lg" aria-hidden="true"></i>
      </div>
      <KeepComponent v-for="k in keeps" :key="k.id" :keep="k" />
    </div>
  </div>
</template>

<script>
import { computed, onMounted, ref } from '@vue/runtime-core'
import { AppState } from '../AppState'
import Pop from '../utils/Notifier'
import { keepsService } from '../services/KeepsService'
import { accountService } from '../services/AccountService'

export default {
  name: 'Home',

  setup() {
    const loading = ref(true)
    onMounted(async() => {
      try {
        await keepsService.getAll()
        await accountService.getAccount()
        loading.value = false
      } catch (error) {
        Pop.toast(error, 'error')
      }
    })

    return {
      loading,
      keeps: computed(() => AppState.keeps),
      myVaults: computed(() => AppState.myVaults)

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
@media only screen and (min-width: 1200px) {
  .card-columns {
    column-count: 4;
  }
}

.card:hover {
  transform: scale(1.04);
}

</style>
