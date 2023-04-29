<template>
    <div class='pages__holder'>
        <ItemSwitcherButton v-bind:key="pages" v-for="pages in pagenumber" :number="pages"/>
    </div>
</template>

<script>
import ItemSwitcherButton from '../components/item-switcher-button.vue'
import previewImageDefault from '../assets/default_preview_solution.png';

export default {
  name: "home-view",
  components: {
    ItemSwitcherButton
},
    data() {
        return { 
            pagenumber: [1,2,3,4,5,6,7],
            tasks: [{author: "author1", isTried: false, name: "работа с JSON", description: "aboba", previewimage: previewImageDefault},
            {author: "author2", isTried: true, name: "работа с JSON1", description: "abob1a", previewimage: previewImageDefault}]

}
    }
    }
</script>

<style lang="scss" scoped>
    .pages__holder {
        width: 30%;
        height: 68px;
        border-radius: 10px;
        border: 1px dashed #7AA7E2;
        background-color: #ECF4FE;
        display: flex;
        flex-direction: row;
        justify-content: space-between;
        gap: 0px;
    }
</style>