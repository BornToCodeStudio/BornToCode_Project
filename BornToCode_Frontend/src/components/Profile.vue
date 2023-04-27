<template>
<body>
    <main>    
        <div class="profile__column">
            <div class="profile__info">
                <img :src="avatarUrl" alt="unload" class="profile__image">

                <span id="profile__nickname">{{ nickname }}</span>
                <span id="profile__aboutme">About me:</span>

                <textarea id="profile__aboutme-text" style="resize: none;">{{ aboutme }}</textarea>

                <button id="subscribe__button">Subscribe</button>

                <input type="file" ref="file" @change="selectFile()">
                <button @click="sendFile()">Отправить фото</button>
            </div>
            <div id="profile__stats">
                <StatsItem text="Likes" :value="likes"/>
                <StatsItem text="Subscribers" :value="subscribers"/>
                <StatsItem text="Subscriptions" :value="subscriptions"/>
                <StatsItem text="Views" :value="views"/>
            </div>
        </div>
        <div class="tasks">
            <div class="tasks__buttons">
                <button id="completed-tasks__button">Completed Tasks</button>
                <button id="created-tasks__button" @click="loadTasks()">Created Tasks ({{ tasksCount }} шт.)</button>
            </div>
            <div class="tasks__items">
                <div id="task-item">
                    <SomeTask v-for="(task) in tasks" :taskname="task.name"/>
                </div>
            </div>
        </div>
    </main>
</body>
    
</template>
    
<script>
import axios from 'axios';
import SomeTask from './Some-Task.vue';
import StatsItem from './Stats-Item.vue';

export default{
    name: "Profile",
    components: {
    SomeTask,
    StatsItem
},
    data() {
        return {
            tasksCount: 0,
            tasks: [],
            nickname: "",
            aboutme: "",
            file: "",
            avatarUrl: '',
            likes: 0,
            subscribers: 0,
            subscriptions: 0,
            views: 0
        }
    },
    methods: {
        async loadTasks() {
            let data = await axios({
                method: 'get',
                url: '',
                responseType: 'json'
            }).then(function (response) {
                if (response.status == 200) {
                    return response.data;
                }

                return [];
            });

            this.tasks = data;
        },
        async loadTasksCount() {
            try {
                let data = await axios({
                    method: 'get',
                    url: '',
                    responseType: 'text'
                }).then(function (response) {
                    if (response.status == 200) {
                        return response.data;
                    }

                    return 0;
                });

                this.tasksCount = data;
            } catch (error) {
                
            }
        },
        selectFile() {
            let file = this.$refs.file.files[0];
            let size = this.formatBytes(file.size);
            if (size > 3) {
                alert("Максимальный размер аватарки не более 3 МБ");
                
                this.$refs.file.value = null;                

                return;
            }

            this.file = file;
        },
        async sendFile() {
            if (this.file == "")
                return;

            let formData = new FormData();
            formData.append('formFile', this.file);

            await axios({
                data: formData,
                method: 'post',
                url: ''
            }).then((response) => {
                if (response.status == 200) {
                    this.file = "";
                    this.$refs.file.value = null;

                    alert("Аватарка обновлена");

                    this.loadAvatar();
                }
            });
        },
        async loadAvatar() {
            let data = await axios({
                method: 'get',
                url: '',
                responseType: 'json'
            }).then((response) => {
                if (response.status == 200)
                    return response.data;

                return null;
            });

            this.avatarUrl = "data:image/jpg;base64," + data.avatar;
        },
        formatBytes(bytes, decimals = 2) {
            if (bytes === 0) {
                return '0';
            } else {
                var k = 1024;
                var dm = decimals < 0 ? 0 : decimals;
                return parseFloat((bytes / Math.pow(k, 2)).toFixed(dm));
            }
        }
    },
    mounted() {
        this.loadTasksCount();
        this.loadAvatar();
    }
}

</script>