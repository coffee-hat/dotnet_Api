<template>
    <!-- Start block -->
  <section class="bg-gray-50 p-3 antialiased dark:bg-gray-900 sm:p-5">
    <div class="mx-auto max-w-screen-xl px-4 lg:px-12">
      <!-- Start coding here -->
      <div
        class="relative overflow-hidden bg-white shadow-md dark:bg-gray-800 sm:rounded-lg"
      >
        <nav
          class="flex flex-col items-start justify-between space-y-3 p-4 md:flex-row md:items-center md:space-y-0"
          aria-label="Table navigation"
        >
          <h2
            class="mb-4 text-3xl font-extrabold leading-none tracking-tight text-gray-900 dark:text-white md:text-4xl"
          >
            {{ title }}
          </h2>
        </nav>
        <div>
          <AddForm :data="columns" @action-entity="createEntity" />
          <EditForm v-if="activeEdit" :columns="columns" :data="editData" @action-entity="editEntity"/>
        </div>
        <div class="overflow-x-auto">
          <DataTable
            :rows="rows"
            :columns="columns"
            @edit="displayEntity"
            @delete="deleteEntity"
          />
        </div>
      </div>
    </div>
  </section>
</template>

<script>
import DataTable from '@/components/DataTable.vue'
import AddForm from '@/components/AddForm.vue'
import EditForm from '@/components/EditForm.vue'

import { getEmployee, getEmployeeColumns, deleteEmployee, createEmployee, updateEmployee } from '../../stores/employee'

export default {
  components: {
    DataTable,
    AddForm,
    EditForm
  },
  data(){
    return {
      rows: [],
      columns: getEmployeeColumns(),
      editData: [],
      activeEdit: false,
      entityId: Number,
      modalActive: false
    }
  },
  props: {
    title: {
      type: String,
      default: ""
    }
  },
  methods: {
    getEntity() {
      getEmployee().then((res) => {
        this.rows = res.data
      })
    },
    deleteEntity(id){
      deleteEmployee(id)
      .then(
        () => this.getEntity())
    },
    createEntity(data){
      createEmployee(data).then(
        () => this.getEntity()
      )
    },
    displayEntity(row){
      this.editData = row
      this.activeEdit = true;
    },
    editEntity(id, data){
      this.activeEdit = false;
      updateEmployee(id, data).then(
        () => this.getEntity()
      )
    }
  },
  mounted() {
    this.getEntity()
  }
}

</script>

<style scoped>
/* Apply Tailwind CSS classes here */
</style>