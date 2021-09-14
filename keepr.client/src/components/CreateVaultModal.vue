<template>
  <div class="create-vault-modal">
    <div class="modal fade" id="create-vault-modal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title">
              Create a Keep
            </h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <form>
              <label for="inputName">Name:</label>
              <input type="text"
                     class="form-control"
                     id="inputName"
                     v-model="state.rawVault.name"
                     placeholder="Name..."
                     required
                     minlength="4"
              >

              <label for="inputImg">Image:</label>
              <input type="text" class="form-control" min-length="10" id="inputImg" placeholder="Enter URL...">

              <label class="form-check-label" for="inputIsPrivate">
                Private:
              </label>
              <input class="form-check-input" type="checkbox" value="" id="inputIsPrivate">
              <br>
              <label class="form-check-label" for="inputIsPrivate">
                If checked,<p> only you will be able to see this Vault.
                </p></label>
            </form>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-dismiss="modal">
              Close
            </button>
            <button type="button" class="btn btn-primary">
              Save changes
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { reactive } from '@vue/reactivity'
import Pop from '../utils/Notifier'
import { vaultsService } from '../services/VaultsService'
// import $ from 'jquery'
export default {
  name: 'CreateVaultModal',
  setup() {
    const state = reactive({
      rawVault: {}
    })
    return {
      state,
      async createVault() {
        try {
          await vaultsService.createVault(state.rawVault)
          state.rawVault = {}
          Pop.toast('Vault Created', 'success')
          // $('#create-vault-modal').modal('toggle')
        } catch (error) {
          Pop.toast(error, 'error')
        }
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
