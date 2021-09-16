<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-md-12 mt-5">
        <div class="col-md-6 offset-1">
          <div class="row">
            <div class="col-md-3">
              <img class="w-100" :src="activeVault.img" alt="" />
            </div>
            <div class="col-md-5">
              <h2> {{ activeVault.name }} &nbsp;&nbsp;&nbsp;&nbsp;<i class="mdi mdi-delete mdi-24px action" title="Delete Keep"></i>  </h2>
              <hr>
              <h4> {{ activeVault.description }}</h4>
            </div>
            <div class="col-md-2" v-if="activeVault.isPrivate===true">
              <span> Private <i class="mdi mdi-eye-off mdi-24px"></i></span>
            </div>
            <div class="col-md-2" v-else>
              <span> Public <i class="mdi mdi-eye mdi-24px"></i></span>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col-md-12 mt-4">
        <div class="row">
          <div class="col-md-10 offset-1 my-2">
            {{ vaultKeeps.name }}
            <div class="card-columns">
              <KeepCard v-for="k in vaultKeeps" :key="k.id" :keep="k" />
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted, ref } from 'vue'
import { AppState } from '../AppState'
import Pop from '../utils/Notifier'
import { vaultsService } from '../services/VaultsService'
import { keepsService } from '../services/KeepsService'
import VaultCard from '../components/VaultCard.vue'
import KeepCard from '../components/KeepCard.vue'
import { useRoute } from 'vue-router'
import { logger } from '../utils/Logger'

export default {
  name: 'VaultPage',

  setup() {
    const loading = ref(true)
    onMounted(async() => {
      const route = useRoute()
      try {
        AppState.vaultKeeps = []
        await vaultsService.getById(route.params.id)
        await keepsService.getAllByVaultId(route.params.id)
        logger.log(AppState.vaultKeeps)
        console.log('appstate vaultkeeps')
        loading.value = false
      } catch (error) {
        Pop.toast(error, 'error')
      }
    })
    return {
      account: computed(() => AppState.account),
      activeVault: computed(() => AppState.activeVault),
      activeKeeps: computed(() => AppState.activeKeeps),
      vaultKeeps: computed(() => AppState.vaultKeeps)
    }
  },
  components: { KeepCard }
}
</script>

<style scoped>
.card:hover {
  transform: scale(1.01);
}
.action {
    cursor: pointer;
}
a {
  color: inherit;
  text-decoration: inherit;;
}
h3 {
  color: rgb(32, 6, 6);
  text-shadow: 4px 4px 4px #db0808;
}
.card-columns {
padding-top: 18px;
column-count: 6;
}
.card {
  border-radius: 15px;
  }
.card-top {
  border-top-left-radius: 15px;
  border-top-right-radius: 15px;
}

</style>
