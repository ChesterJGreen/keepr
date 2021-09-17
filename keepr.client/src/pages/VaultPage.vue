<template>
  <div class="container-fluid px-4">
    <div class="row">
      <div class="col-md-12 mt-5">
        <div class="col-md-10 ">
          <div class="row">
            <div class="col-md-3">
              <img class="w-100 card-top card-bottom border border-dark shadow mb-2" :src="activeVault.img" alt="" onerror="this.onerror=null;this.src='https://thiscatdoesnotexist.com/';" />
            </div>
            <div class="col-md-5" v-if="account.id === activeVault.creatorId">
              <div class="row">
                <div class="col-md-10">
                  <h2> {{ activeVault.name }} </h2>
                </div>
                <div class="col-md-2">
                  <i class="mdi mdi-delete mdi-24px action" title="Delete Vault" @click="deleteVault"></i>
                </div>
              </div>
              <hr>
              <h4> {{ activeVault.description }}</h4>
            </div>
            <div class="col-md-5" v-else>
              <h2> {{ activeVault.name }}</h2>
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
          <div class="row">
            <div class="col-md-12 mt-2">
              <h3>Keeps: {{ vaultKeeps.length }}</h3>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col-md-12 my-2">
        <div class="card-columns">
          <KeepCardForVault v-for="k in vaultKeeps" :key="k.id" :keep="k" />
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
import { useRoute, useRouter } from 'vue-router'
import { logger } from '../utils/Logger'
import Swal from 'sweetalert2'

export default {
  name: 'VaultPage',
  props: {
    vault: {
      type: Object,
      required: true
    }
  },

  setup(props) {
    const loading = ref(true)
    const router = useRouter()
    const route = useRoute()
    onMounted(async() => {
      try {
        await vaultsService.getById(route.params.id)
        await keepsService.getAllByVaultId(route.params.id)
        logger.log(AppState.vaultKeeps)
        loading.value = false
      } catch (error) {
        Pop.toast(error, 'error')
        router.push({ name: 'Home', params: '/' })
      }
    })
    return {

      async deleteVault() {
        await Swal.fire({
          title: 'Are you sure?',
          text: "You won't be able to revert this!",
          icon: 'warning',
          showCancelButton: true,
          confirmButtonColor: '#3085d6',
          cancelButtonColor: '#d33',
          confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
          if (result.isConfirmed) {
            try {
              vaultsService.deleteVault(AppState.activeVault.id)
            } catch (error) {
              Pop.toast(error, 'error')
            }
            Swal.fire(
              'Deleted!',
              'Your Vault has been deleted.',
              'success'
            )
            router.push({ name: 'Account', params: '/account' })
          }
        })
      },
      account: computed(() => AppState.account),
      activeVault: computed(() => AppState.activeVault),
      activeKeeps: computed(() => AppState.activeKeeps),
      vaultKeeps: computed(() => AppState.vaultKeeps),
      vaults: computed(() => AppState.vaults),
      myVaults: computed(() => AppState.myVaults)
    }
  },
  components: { }
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

.card {
  border-radius: 15px;
  }
.card-top {
  border-top-left-radius: 15px;
  border-top-right-radius: 15px;
}
.card-bottom {
  border-bottom-left-radius: 15px;
  border-bottom-right-radius: 15px;
}
@media only screen and (min-width: 1200px) {
  .card-columns {
    column-count: 4;
  }
}

</style>
