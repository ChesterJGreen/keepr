<template>
  <div class="col-md-2 card shadow m-3 p-0">
    <img class="w-100" src="https://www.thiscatdoesnotexist.com">
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

</style>
