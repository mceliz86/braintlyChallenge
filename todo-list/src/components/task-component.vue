<template>
    <div>
        <h1 class="display-4 text-center">Tasks</h1>
        <hr>
        <div class="col-lg-8 offset-lg-2">
            <div class="card mt-4">
                <div class="card-body">
                    <div class="input-group">
                        <input v-model="task" type="text" class="form-control form-control-lg ml-6" placeholder="Add new task">
                        <div class="input-group-append">
                            <button v-on:click="addTask()" class="btn btn-success">Add</button>
                        </div>
                    </div>
                    <br>
                    <h5 v-if="!listTask.length">No tasks!</h5>
                    <ul class="list-group">
                        <li v-for="(task, index) in listTask" :key="index" class="list-group-item d-flex justify-content-between">
                            <span v-bind:class="{'text-success' : task.status}" class="cursor" v-on:click="editTask(task,index)">
                                <i v-bind:class="[task.status ? 'fa-solid fa-circle-check' : 'fa-regular fa-circle']"></i>
                            </span>
                            {{task.name}}
                            <span class="text-danger cursor">
                                <i v-on:click="removeTask(index)" class="fa-solid fa-trash"></i>
                            </span>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: 'task-component', 
    data(){
        return{
            task: '',
            listTask: []
        }
    },
    methods: {
        addTask(){
            const task = {
                name: this.task,
                status: false,
            }
            if(task.name){
                this.listTask.push(task);
                this.task = '';
            }
        },
        removeTask(index){
            this.listTask.splice(index, 1);
        },
        editTask(task, index){
            this.listTask[index].status = !task.status;
        }
    },
}
</script>

<style scoped>
    .cursor{
        cursor: pointer;
    }
</style>