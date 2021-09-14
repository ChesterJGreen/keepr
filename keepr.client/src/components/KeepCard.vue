<template>
  <div class="col-md-2 card shadow m-3 p-0">
    <img class="w-100" :src="keep.img">
    <h5 class="text-center">
      {{ keep.name }}
    </h5>
  </div>
</template>

<script>
export default {
  name: 'KeepCard',
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
