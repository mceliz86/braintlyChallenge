<template>
  <div>
    <h1 class="display-4 text-center">Tasks</h1>
    <hr />
    <div class="col-lg-8 offset-lg-2">
      <div class="card mt-4">
        <div class="card-body">
          <!-- <div class="input-group">
                        <input v-model="task" type="text" class="form-control form-control-lg ml-6" placeholder="Add new task">
                        <input v-model="dueDate" type="date" class="form-control form-control-lg ml-6" placeholder="Due date">
                        <div class="input-group-append">
                            <button v-on:click="addTask()" class="btn btn-success">Add</button>
                        </div>
                    </div> -->
          <form class="row gx-3 gy-2 align-items-center">
            <div class="col-sm-4">
              <label class="visually-hidden" for="title"
                >Name</label
              >
              <input
                v-model="title"
                type="text"
                class="form-control"
                placeholder="Add new task"
                required
              />
            </div>
            <div class="col-sm-3">
              <label
                class="visually-hidden"
                for="dueDate"
                >dueDate</label
              >
              <div class="input-group">
                <input
                  v-model="dueDate"
                  type="date"
                  class="form-control"
                  required
                />
              </div>
            </div>
            <div class="col-sm-3">
              <label class="visually-hidden" for="priority"
                >priority</label
              >
              <select v-model="priorityId" class="form-select">
                <option selected>Priority</option>
                <option value="1">Baja</option>
                <option value="2">Media</option>
                <option value="3">Alta</option>
                <option value="4">Urgente</option>
              </select>
            </div>
            <div class="col-auto">
              <button v-on:click="addTask()" type="submit" class="btn btn-success">Add</button>
            </div>
          </form>

          <br />
          <div v-if="loading" class="text-center">
            <div class="spinner-border" role="status">
              <span class="sr-only">Loading...</span>
            </div>
          </div>
          <h5 v-if="!listTask.length">No tasks!</h5>
          <ul v-if="!loading" class="list-group">
            <li
              v-for="(task, index) in listTask"
              :key="index"
              class="list-group-item d-flex justify-content-between"
            >
              <span
                v-bind:class="{ 'text-success': task.is_completed }"
                class="cursor"
                v-on:click="editStatus(task)"
              >
                <i
                  v-bind:class="[
                    task.is_completed
                      ? 'fa-solid fa-circle-check'
                      : 'fa-regular fa-circle',
                  ]"
                ></i>
              </span>
              Task: {{ task.title }} - Due date: {{ getFormattedDate(task.due_date) }}
              <span class="text-danger cursor">
                <i
                  v-on:click="removeTask(task.id)"
                  class="fa-solid fa-trash"
                ></i>
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
import moment from 'moment';
export default {
  name: "task-component",
  data() {
    return {
      title: "",
      listTask: [],
      loading: false,
      dueDate: moment(new Date()).format('YYYY-MM-DD'),
      priorityId: "",
    };
  },
  methods: {
    addTask() {
      const task = {
        title: this.title,
        due_date: moment(this.dueDate).format('YYYY-MM-DD'),
        priority_id: Number(this.priorityId),
        is_completed: false,
      };
      if (task.title) {
        this.loading = true;
        axios
          .post("http://localhost:5000/api/task/", task)
          .then((response) => {
            console.log(response);
            this.loading = false;
            this.getTasks();
          })
          .catch((error) => {
            console.error(error);
          });
        // this.task = "";
      }
    },
    removeTask(id) {
      this.loading = true;
      axios
        .delete("http://localhost:5000/api/task/" + id)
        .then((response) => {
          console.log(response);
          this.getTasks();
          this.loading = false;
        })
        .catch((error) => {
          console.log(error);
        });
    },
    editStatus(taskItem) {
      const task = {
        title: taskItem.title,
        due_date: taskItem.due_date,
        priority_id: taskItem.priority_id,
        is_completed: !taskItem.is_completed,
        created_at: taskItem.created_at,
      };
      this.loading = true;
      axios
        .put("http://localhost:5000/api/task/" + taskItem.id, task)
        .then(() => {
          this.loading = false;
          this.getTasks();
        })
        .catch((error) => {
          console.log(error);
        });
    },
    getTasks() {
      this.loading = true;
      axios.get("http://localhost:5000/api/task").then((response) => {
        this.listTask = response.data;
        this.loading = false;
      });
    },
    getFormattedDate(date) {
            return moment(date).format("YYYY-MM-DD")
    },
  },
  created: function () {
    this.getTasks();
  },
};
</script>

<style scoped>
.cursor {
  cursor: pointer;
}
</style>