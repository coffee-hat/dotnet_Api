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

        <div
          class="flex flex-col items-center justify-between space-y-3 p-4 md:flex-row md:space-x-4 md:space-y-0"
        >
          <div
            class="flex w-full flex-shrink-0 flex-col items-stretch justify-end space-y-2 md:w-auto md:flex-row md:items-center md:space-x-3 md:space-y-0"
          >
            <AddForm :data="columns" @create-entity="createEntity"/>
          </div>
        </div>
        <div class="overflow-x-auto">
          <DataTable
            :rows="rows"
            :columns="columns"
            @edit="openEditModal"
            @delete="deleteEntity"
          />
        </div>
      </div>
    </div>
    <BaseModel :modalActive="modalActive" @close-modal="toggleModal">
      <TodoForm @close-modal="toggleModal" v-model:entityId="entityId" />
    </BaseModel>
  </section>
</template>

<script>
import DataTable from '@/components/DataTable.vue'
import BaseModel from '@/components/BaseModal.vue'
import TodoForm from '@/components/TodoForm.vue'
import AddForm from '@/components/AddForm.vue'

import { getEmployee, getEmployeeColumns, deleteEmployee, createEmployee } from '../stores/employee'

export default {
  components: {
    DataTable,
    BaseModel,
    TodoForm,
    AddForm
  },
  data(){
    return {
      rows: [],
      columns: getEmployeeColumns(),
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
        console.log(res.data)
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
    openEditModal(id){
      entityId = id
      toggleModal()
    },
    toggleModal(){
      this.modalActive = !this.modalActive
      if (!modalActive.value) {
        this.entityId = null
      }
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