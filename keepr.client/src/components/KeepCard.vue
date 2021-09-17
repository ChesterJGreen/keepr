<template>
  <div :data-target="'#keep-modal-'+keep.id" data-toggle="modal" @click="getById">
    <div class="card card-bottom card-top shadow action" :title="'Open Modal'+keep.name ">
      <img :src="keep.img" class="card-img card-bottom card-top">
      <div>
        <h5 class="card-text py-2 text-dark text-center">
          {{ keep.name }}
        </h5>
      </div>
    </div>
  </div>
  <KeepModal :keep="keep" />
</template>
<script>
export default {
  name: 'KeepCardForVault',

  props: {
    keep: {
      type: Object,
      required: true
    }
  },
  setup() {
    return {

    }
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
.backO {
  background: rgba(0, 0, 255, 0.212);
}
</style>
