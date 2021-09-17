<template>
  <div class="dropdown">
    <button class="btn btn-primary dropdown-toggle"
            type="button"
            id="dropdownMenu2"
            data-toggle="dropdown"
            aria-haspopup="true"
            aria-expanded="false"
    >
      Add to Vault +
    </button>
    <div class="dropdown-menu" aria-labelledby="dropdownMenu2">
      <button class="dropdown-item" type="button" v-for="v in myVaults" :key="v.id" @click="saveVault(v)">
        {{ v.name }}
      </button>
    </div>
  </div>
</template>

<script>
import { computed } from '@vue/runtime-core'
import { AppState } from '../AppState'
import Pop from '../utils/Notifier'
import { vaultkeepsService } from '../services/VaultKeepsService'
import $ from 'jquery'

export default {
  name: 'VaultSelector',
  props: {
    keep: {
      type: Object,
      required: true

    }
  },

  setup(props) {
    return {
      myVaults: computed(() => AppState.myVaults),
      async saveVault(vault) {
        try {
          console.log(props.keep.id)
          console.log(vault.id)
          console.log('in the function-1')
          const vaultId = vault.id
          const keepId = props.keep.id
          const newVk = { keepId, vaultId }
          await vaultkeepsService.create(newVk)
        } catch (error) {
          Pop.toast(error, 'error')
        }
        $('#keep-modal-' + props.keep.id).modal('toggle')
        Pop.toast('Added to your Vault ' + vault.name, 'success')
      }

    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
