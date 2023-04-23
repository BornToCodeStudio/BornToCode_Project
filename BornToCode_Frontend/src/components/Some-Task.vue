<template>
    <button class="task__button">{{ taskname }}</button>
</template>

<script>

export default {
    name: "Some-Task",
    props: {
        taskname: String
    }
}

</script>