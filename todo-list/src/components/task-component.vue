<template>
    <div>
        <h1 class="display-4 text-center">Tasks</h1>
        <hr>
        <div class="col-lg-8 offset-lg-2">
            <div class="card mt-4">
                <div class="card-body">
                    <div class="input-group">
                        <input v-model="task" type="text" class="form-control form-control-lg" placeholder="Add new task">
                        <div class="input-group-append">
                            <button v-on:click="addTask()" class="btn btn-success btn-lg">Add</button>
                        </div>
                    </div>
                    <br>
                    <ul class="list-group">
                        <li v-for="(task, index) in listTask" :key="index" class="list-group-item d-flex justify-content-between">
                            <span class="cursor">
                                <i class="fa-regular fa-circle"></i>
                            </span>
                            {{task.name}}
                            <span class="text-danger cursor">
                                <i class="fa-solid fa-trash"></i>
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
            this.listTask.push(task);
            this.task = '';
        }
    },
}
</script>

<style scoped>
    .cursor{
        cursor: pointer;
    }
</style>