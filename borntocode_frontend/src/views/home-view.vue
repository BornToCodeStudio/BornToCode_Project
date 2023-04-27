<template>
    <main>
      <div class="main__upper">
        <input type="text" id="search__bar" placeholder="Search..">
        <button id="create__task">Create Task</button>
      </div>
      <hr>
    </main>
</template>

<script>
export default {
  name: "home-view"
};
</script>

<style lang="scss" scoped>
    main {
      

      .main__upper {
        display: flex;
        flex-direction: column;
        align-items: center;

        #search__bar {
          width: 1100px;
          height: 45px;
          border-radius: 15px;
        }
      }
    }
</style>