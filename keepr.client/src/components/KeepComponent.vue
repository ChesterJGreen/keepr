<template>
  <div class="col-md-3 mb-4">
    <div class="row m-0">
      <div class="col-md-12 p-0" @click="KeepModal-`{keep.id}`" data-toggel="modal" data-target="'#keep-modal-'{keep.id}">
        <div class="row m-0 card shadow">
          <div class="col-md-12 p-0">
            <img :src="keep.img" class="w-100">
          </div>
          <div class="col-md-12">
            {{ keep.name }}-- {{ keep.description }}
          </div>
          <!-- <KeepModal :keep="k" /> -->
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import KeepModal from './KeepModal.vue'
export default {
  name: 'KeepComponent',
  props: {
    keep: {
      type: Object,
      required: true
    }
  },
  setup() {
    return {}
  },
  components: { KeepModal }
}
</script>

<style lang="scss" scoped>

</style>
