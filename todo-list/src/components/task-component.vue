<template>
    <div>
        <h1 class="display-4 text-center">Tasks</h1>
        <hr>
        <div class="col-lg-8 offset-lg-2">
            <div class="card mt-4">
                <div class="card-body">
                    <div class="input-group">
                        <input type="text" class="form-control form-control-lg" placeholder="Add new task">
                        <div class="input-group-append">
                            <button class="btn btn-success btn-lg">Add</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: 'task-component'
}
</script>

<style scoped>
    
</style>