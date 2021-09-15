<template>
  <div :data-target="'#keep-modal-'+keep.id" data-toggle="modal">
    <div class="card card-bottom card-top action" @click="KeepModal-`${keep.id}`" data-toggel="modal" data-target="'#keep-modal-'{keep.id}">
      <img :src="keep.img" class="card-img card-bottom card-top">
      <h4 class="card-text py-2 card-img-overlay text-light text-left">
        {{ keep.name }}-- {{ keep.description }}
      </h4>
      <!-- <div class="align-items-end">
        <router-link :to="{ name: 'PofilePage', params: {id: keep.creatorId } }" @click.stop="">
          <img :src="keep.creator.picture" class="card-img card-img-overlay w-25 rounded-circle img-end">
        </router-link>
      </div> -->
    </div>
    <KeepModal :keep="keep" />
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
    return {
    }
  },
  components: { }
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
.card-bottom {
  border-bottom-left-radius: 15px;
  border-bottom-right-radius: 15px;
}

img {
  background-size: cover;
  background-image: center;
}
h4 {
  text-shadow: 3px 3px 3px rgb(75, 59, 59),
               -3px 3px 3px rgb(75, 59, 59),
               3px -3px 3px rgb(75, 59, 59);

}

</style>
