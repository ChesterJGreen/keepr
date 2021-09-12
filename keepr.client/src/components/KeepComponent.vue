<template>
  <div class="row keep-component">
    <div class="col-3">
      <p>
        {{ keep.name }}-- {{ keep.body }}
      </p>
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
