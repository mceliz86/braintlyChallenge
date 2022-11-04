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
                    <div v-if="loading" class="text-center">
                        <div class="spinner-border" role="status">
                        <span class="sr-only">Loading...</span>
                    </div>
                    </div>
                    <h5 v-if="!listTask.length">No tasks!</h5>
                    <ul v-if="!loading" class="list-group">
                        <li v-for="(task, index) in listTask" :key="index" class="list-group-item d-flex justify-content-between">
                            <span v-bind:class="{'text-success' : task.is_completed}" class="cursor" v-on:click="editTask(task.id)">
                                <i v-bind:class="[task.is_completed ? 'fa-solid fa-circle-check' : 'fa-regular fa-circle']"></i>
                            </span>
                            {{task.title}}
                            <span class="text-danger cursor">
                                <i v-on:click="removeTask(task.id)" class="fa-solid fa-trash"></i>
                            </span>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import axios from "axios";
export default {
    name: 'task-component', 
    data(){
        return{
            task: '',
            listTask: [],
            loading: false,
        }
    },
    methods: {
        addTask(){
            const task = {
                title: this.task,
                due_date: new Date(),
                priority_id: 1,
                is_completed: false,
                created_at:new Date(),
            }
            if(task.title){
                this.loading = true;
                axios.post("http://localhost:5000/api/task/", task).then(response =>{
                    console.log(response);
                    this.loading=false;
                    this.getTasks();
                    }).catch(error => {
                        console.error(error);
                    });
                this.task = '';
            }
        },
        removeTask(id){
            this.loading = true;
            axios.delete("http://localhost:5000/api/task/" + id).then(response => {
                console.log(response);
                this.getTasks();
                this.loading = false;
            }).catch(error => {console.log(error)
            });
        },
        editTask(id){
            this.loading=true;
            axios.put("http://localhost:5000/api/task/" + id).then( () => {
               this.loading=false;
               this.getTasks();
            }).catch(error =>{console.log(error)});
        },
        getTasks(){
            this.loading = true;
            axios.get("http://localhost:5000/api/task").then(response => {
            this.listTask = response.data;
            this.loading = false;
        });
        }
    },
    created: function(){
        this.getTasks();
    }
}
</script>

<style scoped>
    .cursor{
        cursor: pointer;
    }
</style>