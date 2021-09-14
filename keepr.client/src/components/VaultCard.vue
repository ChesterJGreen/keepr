<template>
  <div class="col-md-2 card shadow m-3 p-0">
    <img v-if="vault.img" class="w-100 card-top" :src="vault.img">
    <img v-else class="w-100 card-top" src="https://www.thiscatdoesnotexist.com">
    <h5 class="text-center">
      {{ vault.name }}
    </h5>
  </div>
</template>

<script>
export default {
  name: 'VaultCard',
  props: {
    vault: {
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
