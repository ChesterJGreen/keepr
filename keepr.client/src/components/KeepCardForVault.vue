<template>
  <div :data-target="'#keep-modal-'+keep.id" data-toggle="modal" @click="getById">
    <div class="card card-bottom card-top shadow action">
      <img :src="keep.img" class="card-img card-bottom card-top">
      <div>
        <h5 class="card-text py-2 text-dark text-center">
          {{ keep.name }}
        </h5>
      </div>
      <div class="col-md-12 align-p mb-2">
        <button class="btn btn-primary" @click.stop="deleteVk">
          Remove Keep
        </button>
      </div>
    </div>
  </div>
  <KeepModalForVault :keep="keep" />
</template>
<script>
import { computed } from '@vue/runtime-core'
import Pop from '../utils/Notifier'
import { AppState } from '../AppState'
import { vaultkeepsService } from '../services/VaultKeepsService'
export default {
  name: 'KeepCard',

  props: {
    keep: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    return {
      vaultKeeps: computed(() => AppState.vaultKeeps),
      async deleteVk() {
        try {
          await vaultkeepsService.delete(props.keep.vaultKeepId)
        } catch (error) {
          Pop.toast(error, 'error')
        }
        Pop.toast('Removed Keep', 'success')
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
.card {
  border-radius: 15px;
  }
.card-top {
  border-top-left-radius: 15px;
  border-top-right-radius: 15px;
}
.backO {
  background: rgba(0, 0, 255, 0.212);
}
.align-p {
  position: relative;
  left: 20%;
}
</style>
