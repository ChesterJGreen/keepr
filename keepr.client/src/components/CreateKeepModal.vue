<template>
  <div class="create-keep-modal">
    <div class="modal fade" id="create-keep-modal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title">
              Create a New Keep
            </h5>
            <button type="button" class="close" data-dismiss="modal" title="Close" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <form @submit="createKeep">
            <div class="modal-body">
              <div class="form-group">
                <label for="inputTitle">Title:</label>
                <input type="text"
                       class="form-control"
                       id="inputTitle"
                       v-model="state.rawKeep.name"
                       placeholder="Title..."
                       required
                       minlength="4"
                >
              </div>
              <div class="form-group">
                <label for="inputImg">Image:</label>
                <input type="text"
                       class="form-control"
                       v-model="state.rawKeep.img"
                       min-length="10"
                       id="inputImg"
                       placeholder="Enter URL..."
                >
              </div>
              <div class="form-group">
                <label for="inputDescription">Description:</label>
                <textarea type="textarea"
                          rows="3"
                          class="form-control"
                          v-model="state.rawKeep.description"
                          min-length="10"
                          id="inputDescription"
                          required
                          placeholder="Enter Description..."
                ></textarea>
              </div>
            </div>
            <div class="modal-footer">
              <button type="submit" class="btn btn-primary" data-toggle="modal" data-target="#createKeep">
                Create Keep
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { reactive } from '@vue/reactivity'
import { keepsService } from '../services/KeepsService'
import Pop from '../utils/Notifier'
import $ from 'jquery'

export default {
  name: 'CreateKeepModal',
  setup() {
    const state = reactive({
      rawKeep: {}
    })
    return {
      state,
      async createKeep() {
        try {
          await keepsService.createKeep(state.rawKeep)
          state.rawKeep = {}
          Pop.toast('Keep Created', 'success')
          $('#create-keep-modal').modal('toggle')
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
