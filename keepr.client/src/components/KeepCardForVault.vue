<template>
  <div :data-target="'#keep-modal-'+keep.id" data-toggle="modal" @click="getById">
    <div class="card card-bottom card-top shadow action" :title="'Open Modal'+keep.name ">
      <img class="card-top card-bottom card-img shadow" :src="keep.img" alt="" onerror="this.onerror=null;this.src='https://thiscatdoesnotexist.com/';" />
      <div>
        <h5 class="card-text py-2 text-dark text-center">
          {{ keep.name }}
        </h5>
        <div class="align-p d-flex mb-2" v-if="user.isAuthenticated==true && keep.creatorId === account.id">
          <button class="btn btn-primary" @click.stop="deleteVk">
            Remove Keep
          </button>
        </div>
        <div class="align-p d-flex mb-2" v-else>
        </div>
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
import Swal from 'sweetalert2'
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
      user: computed(() => AppState.user),
      account: computed(() => AppState.account),
      async deleteVk() {
        await Swal.fire({
          title: 'Are you sure?',
          text: 'You are able to add it again.',
          icon: 'warning',
          showCancelButton: true,
          confirmButtonColor: '#3085d6',
          cancelButtonColor: '#d33',
          confirmButtonText: 'Yes, remove it!'
        }).then((result) => {
          if (result.isConfirmed) {
            try {
              vaultkeepsService.delete(props.keep.vaultKeepId)
            } catch (error) {
              Pop.toast(error, 'error')
            }
            Swal.fire(
              'Removed!',
              'Your Keep has been removed from the vault.',
              'success'
            )
          }
        })
      },

      components: {}
    }
  }
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
  justify-content: center;

}
@media only screen and (min-width: 1200px) {
  .card-columns {
    column-count: 4;
  }
}

</style>
