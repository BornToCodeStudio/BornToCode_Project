<template>
    <div class='pages__holder'>
        <ItemSwitcherButton v-bind:key="index" v-for="(pages, index) in getNumbers()" :number="pages"/>
    </div>
</template>

<script>
import ItemSwitcherButton from '../components/item-switcher-button.vue'

export default {
    name: "home-view",
    components: {
        ItemSwitcherButton
    },
    props: {
        pagesCount: {
            type: Number,
            default: 0
        }
    },
    methods: {
        getNumbers() {
            let pages = [];
            for (let i = 1; i <= this.pagesCount; i++) {
                pages.push(i)
            }

            return pages;
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
        gap: 10px;
    }
</style>