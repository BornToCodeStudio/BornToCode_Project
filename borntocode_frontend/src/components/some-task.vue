<template>
    <button class="task__button">{{ taskname }}</button>
</template>

<script>   
import previewImageDefault from '../assets/default_preview_solution.png';

export default{
    name: "Some-Task",
    props: {
        preview: {
            type: Object,
            default: previewImageDefault
        },
        author: {
            type: String,
            default: ''
        },
        completed: {
            type: Boolean,
            default: false
        },
        description: {
            type: String,
            default: ''
        },
        taskname: {
            type: String,
            default: ''
        }
    }
}

</script>

<style>
    .task__button{
        border-radius: 30px;
        border-color: #1477F8;
        border-width: 1px;
        width: 300px;
        height: 220px;
        padding-block: 50px;
    }

    .task__button:hover{
        box-shadow: 0 12px 16px 0 rgba(0,0,0,0.24), 0 17px 50px 0 rgba(0,0,0,0.19);
    }
</style>