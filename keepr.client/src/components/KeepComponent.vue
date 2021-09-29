<template>
  <div class="pt-3" :data-target="'#keep-modal-'+keep.id" data-toggle="modal" @click="getById">
    <div class="card card-bottom card-top action card-parent">
      <img :src="keep.img" class="card-img card-bottom card-top">
      <h4 class="card-text py-2 card-img-overlay text-light text-left">
        {{ keep.name }}
      </h4>

      <div
        @click.stop="goToProfile"
      >
        <img :src="keep.creator.picture" class="card-img-overlay rounded-circle img-end">
      </div>
    </div>
  </div>
  <KeepModal :keep="keep" />
</template>

<script>
import { computed } from '@vue/runtime-core'
import { useRouter } from 'vue-router'

import { keepsService } from '../services/KeepsService'
import Pop from '../utils/Notifier'
import { AppState } from '../AppState'

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
      keeps: computed(() => AppState.keeps),
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
  box-shadow: -2px -2px 2px rgba(153, 205, 50, 0.534),
              -2px -2px 2px,
              -2px -2px 2px;

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
.card-parent{
  position: relative;

}
.img-end {
  position: absolute ;
  left: 60%;
  width: 120px;
}
img {
  max-height: 450px;

}

</style>
