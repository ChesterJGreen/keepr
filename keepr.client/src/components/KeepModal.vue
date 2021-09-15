<template>
  <div class="modal-body">
    <div class="modal fade" :id="'keep-modal-'+ keep.id" tabindex="-1" aria-labelledby="keepModalLabel" aria-hidden="true">
      <div class="modal-dialog modal-lg">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="staticBackdropLabel">
              {{ keep.name }}
            </h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <div class="row">
              <div class="col-md-6">
                <img :src="keep.img" class="w-100">
              </div>
              <div class="col-md-6">
                <div class="row">
                  <div class="col-md-12 text-center ">
                    <i class="mdi mdi-eye mdi-24px"></i>
                    {{ keep.views }} <span>&nbsp; </span>
                    <i class="mdi mdi-floppy mdi-24px"></i>
                    {{ keep.keeps }} <span>&nbsp; </span>
                    <i class="mdi mdi-share-variant mdi-24px"></i>
                    {{ keep.shares }}
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
              </div>
            </div>
          </div>
          <div class="modal-footer">
            <div class="row">
              <!-- <div class="col-md-4" v-if="keep.id !==vaultkeep.keep.id">
                <button>
                  Add To Vault +
                </button>
              </div>
              <div class="col-md-4" v-if="user.id == keep.creatorId">
              </div> -->
              <div class="col-md-5">
                <span><img class="w-25 rounded-circle" :src="keep.creator.picture" :alt="keep.creator.name">
                  {{ keep.creator.name }}
                </span>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from '@vue/runtime-core'
import { AppState } from '../AppState'
export default {
  name: 'KeepModal',
  props: {
    keep: {
      type: Object,
      required: true

    }
  },
  setup() {
    return {
      activeKeep: computed(() => AppState.activeKeep)
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
