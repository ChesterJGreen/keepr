<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-md-12 mt-5">
        <div class="col-md-6 offset-1">
          <div class="row">
            <div class="col-md-3">
              <img class="w-100 border border-dark card-top card-bottom" :src="account.picture" alt="" />
            </div>
            <div class="col-md-5">
              <h2> {{ account.name }}</h2>
              <p>
              </p><h4>Vaults: {{ myVaults.length }}</h4>

              <p>
              </p><h4>Keeps: {{ myKeeps?.length }}</h4>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col-md-12">
        <div class="row">
          <div class="col-md-4 offset-1 pl-5 my-3 mt-5">
            <h3>
              Vaults <span class="action" title="Add a Vault" data-target="#create-vault-modal" data-toggle="modal">
                +
              </span>
            </h3>
          </div>
        </div>
        <div class="row">
          <div class="col-md-10 offset-1 my-2">
            <div class="row">
              <VaultCard v-for="v in myVaults" :key="v.id" :vault="v" />
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col-md-12">
        <div class="row">
          <div class="col-md-4 offset-1 pl-5 my-3">
            <h3>
              Keeps <span class="action" title="Add a Keep" data-target="#create-keep-modal" data-toggle="modal">
                +
              </span>
            </h3>
          </div>
        </div>
        <div class="row">
          <div class="col-md-10 offset-1 my-2">
            <div class="card-columns">
              <KeepCard v-for="k in myKeeps" :key="k.id" :keep="k" />
            </div>
          </div>
        </div>
      </div>
    </div>
    <CreateVaultModal />
    <CreateKeepModal />
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

export default {
  name: 'Account',

  setup() {
    const loading = ref(true)
    onMounted(async() => {
      try {
        await vaultsService.getAllByCreator()
        await keepsService.getAllByCreator(AppState.account.id)
        loading.value = false
      } catch (error) {
        Pop.toast(error, 'error')
      }
    })
    return {
      account: computed(() => AppState.account),
      myVaults: computed(() => AppState.myVaults),
      myKeeps: computed(() => AppState.myKeeps)

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
