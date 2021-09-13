<template>
  <div class="col-md-2 mb-4 ">
    <div class="row m-0">
      <div class="col-md-12 p-0">
        <div class="row m-0 card shadow" @click="keep-modal">
          <div class="col-md-12 p-0">
            <img :src="keep.img" class="w-100">
          </div>
          <div class="col-md-12">
            {{ keep.name }}-- {{ keep.description }}
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
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
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
