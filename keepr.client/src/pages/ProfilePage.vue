<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-md-12 mt-5">
        <div class="col-md-6">
          <div class="row">
            <div class="col-md-3 d-sm-none">
              <img class="w-100 border border-dark card-top card-bottom" :src="profile?.picture" alt="" />
            </div>
            <div class="col-md-5">
              <h2> {{ profile.name }}</h2>
              <p>
              </p><h4>Vaults: {{ activeVaults?.length }}</h4>

              <p>
              </p><h4>Keeps: {{ activeKeeps?.length }}</h4>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col-md-12">
        <div class="row">
          <div class="col-md-4 pl-5 my-3 mt-5">
            <h3>
              Vaults
            </h3>
          </div>
        </div>
        <div class="row">
          <div class="col-md-10  my-2">
            <div class="row">
              <VaultCard v-for="v in activeVaults" :key="v.id" :vault="v" />
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col-md-12">
        <div class="row">
          <div class="col-md-4  pl-5 my-3">
            <h3>
              Keeps
            </h3>
          </div>
        </div>
        <div class="row">
          <div class="col-md-10  my-2">
            <div class="card-columns">
              <KeepCard v-for="k in activeKeeps" :key="k.id" :keep="k" />
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
import { accountService } from '../services/AccountService'
import { useRoute } from 'vue-router'

export default {
  name: 'Profile',

  setup() {
    const route = useRoute()
    onMounted(async() => {
      try {
        await accountService.getProfile(route.params.id)
        await vaultsService.getAllByProfile(route.params.id)
        await keepsService.getAllByProfile(route.params.id)
      } catch (error) {
        Pop.toast(error, 'error')
      }
    })
    return {
      profile: computed(() => AppState.profile),
      activeVaults: computed(() => AppState.activeVaults),
      activeKeeps: computed(() => AppState.activeKeeps)

    }
  },
  components: { VaultCard, KeepCard }
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
/* column-count: 6; */
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

</style>
