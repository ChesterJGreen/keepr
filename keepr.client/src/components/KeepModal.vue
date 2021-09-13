<template>
  <div class="container-fluid keep-modal">
    <div class="row">
      <div class="col-md-6">
        <img :src="keep.img">
      </div>
      <div class="col-md-6">
        <div class="row">
          <div class="col-md-4"></div>
          <div class="col-md-4">
            {{ keep.views }} - {{ keep.shares }}
          </div>
          <div class="col-md-4 justify-content-end">
            <button class="btn">
              X
            </button>
          </div>
        </div>
        <div class="row">
          <div class="col-md-12">
            <h2>{{ keep.name }}</h2>
          </div>
          <div class="col-md-12">
            <p>
              {{ keep.description }}
            </p>
          </div>
        </div>
        <div class="row">
          <div class="col-md-4" v-show="keep.id !==vaultkeep.keep.id">
            <button>
              Add To Vault +
            </button>
          </div>
          <div class="col-md-4" v-show="user.id == keep.creatorId">
          </div>
          <div class="col-md-4">
            <img :src="profile.imgUrl" :alt="profile.nickname">
            {{ profile.name }}
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'KeepModal',
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
