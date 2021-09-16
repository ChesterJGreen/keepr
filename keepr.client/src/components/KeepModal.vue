<template>
  <div class="modal-body "
       data-backdrop="static"
       data-keyboard="false"
  >
    <div class="modal fade"
         :id="'keep-modal-'+ keep.id"
         tabindex="-1"
         data-backdrop="static"
         data-keyboard="false"
         aria-labelledby="keepModalLabel"
         aria-hidden="false"
    >
      <div class="modal-dialog modal-xl">
        <div class="modal-content">
          <div class="modal-body">
            <div class="row">
              <div class="col-md-6">
                <img :src="keep.img" class="w-100">
              </div>
              <div class="col-md-6">
                <div class="row">
                  <div class="col-md-11 text-center ">
                    <i class="mdi mdi-eye mdi-24px"></i>
                    {{ keep.views }} <span>&nbsp; </span>
                    <i class="mdi mdi-floppy mdi-24px"></i>
                    {{ keep.keeps }} <span>&nbsp; </span>
                    <i class="mdi mdi-share-variant mdi-24px"></i>
                    {{ keep.shares }}
                  </div>
                  <div class="col-md-1">
                    <button type="button" class="close" data-dismiss="modal" title="Close" aria-label="Close">
                      <span aria-hidden="true">&times;</span>
                    </button>
                  </div>
                </div>
                <div class="row">
                  <div class="col-md-12 mt-3">
                    <h2>{{ keep.name }}</h2>
                  </div>
                  <div class="col-md-12 mt-5">
                    <p>
                      {{ keep.description }}
                    </p>
                  </div>
                </div>
                <div class="row">
                  <div class="col-md-4 mt-2">
                    <button class="btn btn-primary">
                      Add To Vault +
                    </button>
                  </div>
                  <div class="col-md-4 text-center">
                    <i class="mdi mdi-delete mdi-36px action" @click.stop="deleteKeep" title="Delete Keep"></i>
                  </div>
                  <div class="col-md-4 text-center mt-2">
                    <span><img class="w-25 rounded-circle" :src="keep.creator?.picture" :alt="keep.creator?.name">
                      {{ keep.creator?.name }}
                    </span>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, popScopeId, Text } from '@vue/runtime-core'
import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'
import Pop from '../utils/Notifier'
import Swal from 'sweetalert2'
export default {
  name: 'KeepModal',
  props: {
    keep: {
      type: Object,
      required: true

    }
  },
  setup(props) {
    return {
      async deleteKeep() {
        try {
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
              keepsService.deleteKeep(props.keep.id)
              Swal.fire(
                'Deleted!',
                'Your file has been deleted.',
                'success'
              )
            }
          })
        } catch (error) {
          Pop.toast(info, 'Not deleted')
        }
      },
      activeKeep: computed(() => AppState.activeKeep)
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
.profile{
  align-content: flex-end;
  justify-content: flex-end;
}
</style>
