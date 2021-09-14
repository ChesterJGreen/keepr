<template>
  <div class="card shadow">
    <img class="w-100 card-top" :src="keep.img">
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
.card {
  border-radius: 15px;
  }
.card-top {
  border-top-left-radius: 15px;
  border-top-right-radius: 15px;
}
</style>
