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
      <button class="dropdown-item" type="button" v-for="v in myVaults" :key="v.id">
        {{ v.name }}
      </button>
    </div>
  </div>
</template>

<script>
import { computed } from '@vue/runtime-core'
import { AppState } from '../AppState'
export default {
  name: 'VaultSelector',

  setup() {
    return {

      myVaults: computed(() => AppState.myVaults)
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
