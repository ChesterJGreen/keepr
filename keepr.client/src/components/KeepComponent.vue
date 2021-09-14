<template>
  <div class="card card-bottom card-top action" @click="KeepModal-`{keep.id}`" data-toggel="modal" data-target="'#keep-modal-'{keep.id}">
    <img :src="keep.img" class="card-img card-bottom card-top">
    <h4 class="card-text py-2 card-img-overlay text-light">
      {{ keep.name }}-- {{ keep.description }}
    </h4>
  </div>
</template>
 @click="KeepModal-`{keep.id}`" data-toggel="modal" data-target="'#keep-modal-'{keep.id}">
<script>
import KeepModal from './KeepModal.vue'

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
  components: { KeepModal }
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
