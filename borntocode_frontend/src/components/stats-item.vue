<template>
    <div class="stats-item">
        <span id="text">{{ text }}:</span>
        <span id="value">{{ value }}</span>
    </div>
</template>

<script>   
    
export default{
    name: "Stats-Item",
    props: {
        text: {
            type: String,
            default: ''
        },
        value: {
            type: String,
            default: ''
        }
    }
}

</script>

<style>
    .stats-item {
        display: flex;
        flex-direction: row;
        justify-content: space-around;
        width: 125px;
        border-radius: 10px;
        border-width: 0px;
        background-color: #B9BABC;
    }
</style>