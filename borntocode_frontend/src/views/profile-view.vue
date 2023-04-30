<template>
<body>
    <main>    
        <div class="profile__column">
            <div class="profile__info">
                <img :src="avatarUrl" ref='profileImg' alt="unload" class="profile__image">

                <span id="profile__nickname">{{ nickname }}</span>
                <span id="profile__aboutme">About me:</span>

                <textarea id="profile__aboutme-text" style="resize: none;" v-model="aboutme"></textarea>

                <button id="subscribe__button">Subscribe</button>

                <input type="file" ref="file" @change="selectFile()">
                <button class="Send__photo" @click="sendFile()">Отправить фото</button>
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
                    <SomeTask v-bind:key="index" v-for="(task, index) in tasks" :taskname="task.name"/>
                </div>
            </div>
        </div>
    </main>
</body>
    
</template>
    
<script>
import axios from 'axios';
import SomeTask from '../components/some-task.vue';
import StatsItem from '../components/stats-item.vue';
import profileImage from '../assets/default_avatar.png';


export default{
    name: "profile-page",
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
            avatarUrl: '../assets/default_avatar.png',
            likes: "0",
            subscribers: "0",
            subscriptions: "0",
            views: "0"
        }
    },
    methods: {
        async loadTasks() {
            let data = await axios({
                method: 'get',
                url: process.env.VUE_APP_API_URL,
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
                    url: process.env.VUE_APP_API_URL,
                    responseType: 'text'
                }).then(function (response) {
                    if (response.status == 200) {
                        return response.data;
                    }

                    return 0;
                });

                this.tasksCount = data;
            } catch (error) {
                console.log(error);
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
            let data = null;
            try {
                data = await axios({
                    method: 'get',
                    url: process.env.VUE_APP_API_URL,
                    responseType: 'json'
                }).then((response) => {
                    if (response.status == 200)
                        return response.data;

                    return null;
                });
            }
            catch(error) {
                this.$refs.profileImg.src = profileImage;
            }

            if (data == null) {
                this.$refs.profileImg.src = profileImage;

                return;
            }

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

<style lang="scss" scoped>
    main {
        display: flex;
        flex-direction: row;
        justify-content: space-between;
    }

    .profile__column {
        display: flex;
        flex-direction: column;
        gap:15px;
        margin: 10px;
        border: 1px dashed black;
        width: 25%;
        height: 630px;
        background-color: #EFEFEF;
        border-radius: 45px;
        border-color: #1477F8;
    }

    .profile__info {
        padding-top: 30px;
        display: flex;
        flex-direction: column;
        align-items: center;
        gap: 15px;
    }

    #profile__nickname {
        text-align: center;
        background-color: #99B0ED;
        border-radius: 15px;
        width: 92px;
        height: 20px;

        @media (max-width: 1400px) {
            width: 92px;
        }
    }

    #profile__aboutme {
        text-align: center;
        background-color: #B9BABC;
        border-radius: 15px;
        width: 92px;
        height: 20px;
    }

    #profile__aboutme-text {
        background-color: #B9BABC;
        border-color: #1477F8;
        border-radius: 10px;  
    }

    #subscribe__button {
        text-align: center;
        background-color: #99B0ED;
        border-radius: 20px;
        border-width: 0px;
        transition: 0.5s;
    }

    #subscribe__button:hover{
        background-color: #1477F8;;
    }

    #profile__stats {
        display: flex;
        flex-direction: column;
        justify-content:left;
        margin-top: 40px;
        margin-left: 10px;
        width: 100px;
        gap: 10px;
    }

    .tasks {
        display: flex;
        flex-direction: column;
        grid-column: 2;
        padding-right: 30px;
        gap: 20px;
        width: 65%;
    }

    .tasks__buttons {
        display: flex;
        flex-direction: row;
        justify-content: space-between;
    }

    #completed-tasks__button {
        border-radius: 30px;
        border-width: 0px;
        background-color: #AFCFF9;
        width: 45%;
        height: 55px;
        transition: 0.5s;
        
        @media (max-width: 800px) {
            width: 110px;
        }
    }

    #created-tasks__button {
        border-radius: 30px;
        border-width: 0px;
        background-color: #AFCFF9;
        width: 45%;
        height: 55px;
        transition: 0.5s;

        @media (max-width: 800px) {
            width: 110px;
        }
    }


    .profile__image {
        width: 100px;
        height: 100px;
        border-radius: 50px;
        transition: 1s;
    }

    .profile__image:hover {
        transform: scale(1.25);
    }

    .tasks__items {
        display: flex;
        flex-direction: column;
        align-items: center;
        gap: 30px;
    }

    #task-item {
        display: flex;
        flex-direction: row;
        justify-content: space-between;
        width: 100%;
        gap: 30px;
        flex-wrap: wrap;
    }

    .Send__photo{
        display: flex;
        flex-direction: column;
        border: 2px solid black;
        border-style: ridge;
        border-radius: 15px;
        text-align: center;
        transition: 0.5s;
    }

    #completed-tasks__button:hover, #created-tasks__button:hover{
        background-color: #1477F8;
    }

</style>