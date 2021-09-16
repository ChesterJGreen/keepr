<template>
  <div :data-target="'#keep-modal-'+keep.id" data-toggle="modal" @click="getById">
    <div class="card card-bottom card-top action">
      <img :src="keep.img" class="card-img card-bottom card-top">
      <h4 class="card-text py-2 card-img-overlay text-light text-left">
        {{ keep.name }}-- {{ keep.description }}
      </h4>
      <div>
        <div
          @click.stop="goToProfile"
        >
          <img :src="keep.creator.picture" class="card-img card-img-overlay w-25 rounded-circle img-end">
        </div>
      </div>
    </div>
    <KeepModal :keep="keep" />
  </div>
</template>

<script>
import { useRouter } from 'vue-router'

import { keepsService } from '../services/KeepsService'
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
    const router = useRouter()
    return {
      async getById() {
        try {
          await keepsService.getById(props.keep.id)
        } catch (error) {
          Pop.toast(error, 'error')
        }
      },
      goToProfile() {
        const profileId = props.keep.creatorId
        router.push({ path: `/profiles/${profileId}` })
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
