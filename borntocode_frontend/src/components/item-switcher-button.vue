<template>
    <button class="number">{{number}}</button>
</template>


<script>
export default {
    name: "Item-Switcher-Button",
    props: { 
        number: {
            type: Number,
            default: null
        }
    }
    }

</script>

<style lang="scss" scoped>
    .number {
        width: 68px;
        text-align: center;
        border-radius: 35px;
        background-color: #D9D9D9;
        border: 1px dashed #7AA7E2;
    }
</style>