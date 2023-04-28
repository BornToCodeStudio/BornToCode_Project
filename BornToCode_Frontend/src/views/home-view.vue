<template>
    <main>
      <div class="main__upper">
        <input type="text" id="search__bar" placeholder="Search..">
        <button id="create__task">Create Task</button>
      </div>
      <hr>
      <div class="main__body">
        <div class="filters">
          <div class="left__filters">
            <button id="filter__new">New</button>
            <button id="filter__solutions">Solutions</button>
            <button id="filter__likes">Likes</button>
          </div>
          <span id="tasks">Tasks</span>
          <div class="right__filters">
            <button id="filter__html">HTML</button>
            <button id="filter__css">CSS</button>
            <button id="filter__js">JavaScript</button>
          </div>
        </div>
        <div class="filtered__tasks">
          <img :src="getPreview()" ref='taskImg' alt="unload" class="task__preview">
        </div>
      </div>
    </main>
</template>

<script>

//import FilteredTask from../components/home-tasks.vue";
import axios from 'axios';
import previewImageDefault from '../assets/default_preview_solution.png';

export default {
  name: "home-view",
  components: {
    //FilteredTask
},
    data() {
        return {
          title: '',
          author: '',
          shortdescription: '',
          fulldescription: '',
          createdat: null,
          codeexample: '',
          solutions: null,
          taskcomments: '',
          tasklikes: null,
          id: null,
          previewimage: "",
          tasks: []
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

        getPreview(id) {
          let task = this.tasks.find(t => t.id == id);
          if (!task)
            return previewImageDefault;
            
          return task.previewimage;
        }
    }
};
</script>

<style lang="scss" scoped>
  main {
    display: flex;
    flex-direction: column;
    justify-content:space-between;

    hr {
        background-color: #A0C6F8;
        height: 0.4px;
        width: 100%;
    }
      
    .main__upper {
      display: flex;
      flex-direction: column;
      align-items: center;
      gap: 10px;

      #search__bar {
        width: 70%;
        height: 45px;
        border-radius: 15px;
        border-width: 1px;
        border-color: #7AA7E2;
        background-color: #ECF4FE;
      }

      #create__task {
        width: 15%;
        height: 40px;
        margin-left: 50%;
        border-radius: 20px;
        border-width: 0px;
        background-color: #9EB4EE;
      }
    }
    
    .filters {
      display: flex;
      flex-direction: row;
      height: 30px;
      justify-content: space-evenly;

      .left__filters {
        display:flex;
        flex-direction: row;
        justify-content: space-evenly;
        background-color: #EFEFEF;
        border-radius: 15px;
        width: 20%;


        #filter__new , #filter__solutions, #filter__likes{
          background-color: #A0C6F8;
          border-width: 0px;
          border-radius: 15px;
          width: 27%;
        }
      }

      #tasks {
        text-align: center;
        background-color: #9AA5AC;
        color: white;
        border-radius: 15px;
        width:10%;        } 

      .right__filters {
        display:flex;
        flex-direction: row;
        justify-content: space-evenly;
        background-color: #EFEFEF;
        border-radius: 15px;
        width: 20%;

        #filter__html , #filter__css, #filter__js{
          background-color: #A0C6F8;
          border-width: 0px;
          border-radius: 15px;
          width: 27%;
        }
      }
    }
  }
    
</style>