<template>
  <div class="Container-fluid home flex-grow-1  align-items-center justify-content-center">
    <div class="row m-0 mt-5 ">
      <div v-if="loading" class="col text-center">
        <i class="fa fa-spinner fa-spin fa-lg" aria-hidden="true"></i>
      </div>

      <KeepComponent v-for="k in keeps" :key="k.id" :keep="k" class="masonry" />
    </div>
  </div>
</template>

<script>
import { computed, onMounted, ref } from '@vue/runtime-core'
import { AppState } from '../AppState'
import Pop from '../utils/Notifier'
import { keepsService } from '../services/KeepsService'

export default {
  name: 'Home',
  window,

  setup() {
    const loading = ref(true)
    onMounted(async() => {
      try {
        await keepsService.getAll()
        loading.value = false
      } catch (error) {
        Pop.toast(error, 'error')
      }
    })
    // function resizeGridItem(item) {
    //   grid = document.getElementsByClassName('grid')[0]
    //   rowHeight =
    //     parseInt(window.getComputedStyle(grid).getPropertyValue('grid-auto-rows'))
    //   rowGap =
    //     parseInt(window.getComputedStyle(grid).getPropertyValue('grid-row-gap'))
    //   rowSpan =
    //     Mathc.ceil((item.querySelector('.content').getBoundingClientRect().height + rowGap) / (rowHeight + rowGap))
    //   item.style.gridRowEnd = 'span ' + rowSpan
    // }
    // function resizeAllGridItems() {
    //   allItems = document.getElementsByClassName('item')
    //   for (x = 0; x < allItems.length; x++) {
    //     resizeGridItem(allItems[x])
    //   }
    // }
    return {
      loading,
      keeps: computed(() => AppState.keeps)
      //  window.onload = resizeAllGridItems(),
      // window.addEventListener('resize', resizeAllGridItems),

    }
  }
}
</script>

<style scoped lang="scss">
.home{
  text-align: center;
  user-select: none;
  > img{
    height: 200px;
    width: 200px;
  }
}
.grid {
  display: grid;
  grid-gap: 10px;
  grid-template-columns: repeat(auto-fill, minmax(250px,1fr));
  grid-auto-rows: 600px
}
  :root {
    counter-reset: masonry;
  }
  .masonry {
    display: grid;
    grid-gap: 10px;
    grid-template-columns: repeat(auto-fill, minmax(200px,1fr));
    grid-auto-rows: 0;
  }

  .masonry-item {
    border-radius: 5px;
  }

  .masonry-item {
     background-color: #eee;
     border-radius: 5px;
     overflow: hidden;
  }

  .masonry-item,
  .masonry-item img {
     position: relative;
  }

  .masonry-item:after {
    font-weight: bold;
    background-color: rgba(0, 0, 0, .5);
    content: counter(masonry);
    counter-increment: masonry;
    position: absolute;
    top: 0;
    left: 0;
    height: 100%;
    width: 100%;
    color: white;
    display: flex;
    justify-content: center;
    align-items: center;
    transition: all .1s ease-in;
  }

  .masonry-item:hover:after {
    font-size: 30px;
    background-color: rgba(0, 0, 0, .75);
  }
</style>
