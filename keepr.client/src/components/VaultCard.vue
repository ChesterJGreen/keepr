<template>
  <div class="col-md-2 card shadow m-3 p-0">
    <img class="w-100 card-top" :src="vault.img" onerror="this.onerror=null;this.src='https://thiscatdoesnotexist.com/';">
    <h5 class="text-center p-2">
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
