<template>
<body>
    <main>    
        <section class="Profile_column">
            <span id="Profile__Image"></span>
            <span id="Nick">Nickname</span>
            <span id="About">About me:</span>
            <textarea id="About__Text" style="resize: none;"></textarea>
            <button id="Subscribe">Subscribe</button>
            
            <section id="Menu__Counters">
                <button id="Likes">Likes</button>
                <button id="Subscribers">Subscribers</button>
                <button id="Subscriptions">Subscriptions</button>
                <button id="Views">Views</button>
            </section>
        </section>
        <section class="Tasks">
            <section class="Upper__Task">
                <button id="Completed_Tasks">Completed Tasks</button>
                <button id="Created_Tasks">Created Tasks</button>
            </section>
            <section class="Footer__tasks">
                <section id="Fblock">
                    <SomeTask v-for="(name) in tasksF" :taskname="name"/>
                </section>
                <section id="Sblock">
                    <SomeTask v-for="(name) in tasksS" :taskname="name"/>
                </section>
            </section>
        </section>
    </main>
</body>
    
</template>
    
<script>
import SomeTask from './Some-Task.vue';

export default{
    name: "Profile",
    components: {
        SomeTask
    },
    data() {
        return {
            tasksF: ["Some task 1", "Some task 2", "Some task 3"],
            tasksS: ["Some task 4", "Some task 5", "Some task 6"]
        }
    }
}

</script>