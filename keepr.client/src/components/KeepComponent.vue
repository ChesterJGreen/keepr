<template>
  <div :data-target="'#keep-modal-'+keep.id" data-toggle="modal" @click="getById">
    <div class="card card-bottom card-top action">
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
import { keepsService } from '../services/KeepsService'
import { logger } from '../utils/Logger'
import Pop from '../utils/Notifier'

export default {
  name: 'KeepComponent',
  props: {

    keep: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    return {
      async getById() {
        try {
          logger.log('in component -1')
          console.log('in component - 1')
          console.log(props.keep.id)
          console.log(props.keep)
          const done = await keepsService.getById(props.keep.id)
          console.log('in component - end')
          console.log(done)
          console.log(props.keep)
        } catch (error) {
          Pop.toast(error, 'error')
        }
      }

    }
  },
  components: { }
}
</script>

<style lang="scss" scoped>
.card {
  border-radius: 15px;
  }
.card:hover {
  transform: scale(1.01);
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
