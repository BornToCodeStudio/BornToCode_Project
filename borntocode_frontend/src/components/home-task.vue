<template>
    <div class="home__tasks">
        <div class="left__part">
            <img :src="task.previewimage" ref='taskImg' alt="unload" class="image__preview">
            <span class="author">{{task.author}}</span>
            <span class="is__tried">{{task.isTried}}</span>
        </div>
        <div class="right__part">
            <span class="task__name">{{task.name}}</span>
            <span class="task__description">{{task.description}}</span>
        </div>
    </div>
</template>

<script>

export default{
    name: "Home-Task",
    props: { 
        task: {
            type: Object,
            default: null
        }
    }
}
</script>

<style lang="scss" scoped>
    .home__tasks {
        display: flex;
        flex-direction: row;
        justify-content: space-evenly;
        background-color: #EFEFEF;
        border-radius: 15px;
        width: 40%;
        gap: 10px;
        user-select: none;

        .left__part {
            margin: 10px;
            display: flex;
            flex-direction: column;
            justify-content: space-around;
            gap: 10px;

            .image__preview {
                width: 186px;
                height: 186px;
                border-radius: 15px;
                pointer-events: none;
            }

            .author {
                text-align: center;
                background-color: #8D939F;
                border-radius: 15px;
                height: 46px;
                
            }

            .is__tried {
                text-align: center;
                background-color: #A8C9F3;
                border-radius: 15px;
                height: 30px;
            }
        }

        .right__part {
            margin: 10px;
            display: flex;
            flex-direction: column;
            gap: 10px;
            width: 70%;

            .task__name {
                gap: 10px;
                background-color: #D9D9D9;
                border-radius: 15px;
                height: 15%;
            }

            .task__description {
                background-color: #D9D9D9;
                border-radius: 15px;
                height: 100%;
            }
        }
    }
</style>
