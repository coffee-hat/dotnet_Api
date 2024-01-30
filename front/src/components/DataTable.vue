<template>
  <table class="w-full text-left text-sm text-gray-500 dark:text-gray-400">
    <thead
      class="bg-gray-50 text-xs uppercase text-gray-700 dark:bg-gray-700 dark:text-gray-400"
    >
      <tr>
        <th v-for="column in columns" :key="column.key" class="px-4 py-4">
          {{ column.label }}
        </th>
        <th class="px-4 py-4">action</th>
      </tr>
    </thead>
    <tbody>
      <tr v-if="rows.length === 0">
        <td :colspan="columns.length + 1" class="px-4 py-3 text-center">
          {{ emptyList }}
        </td>
      </tr>
      <tr
        v-for="row in rows"
        :key="row.id"
        @click="selected(row.id, isSelectable)"
        :class="{'hover:bg-gray-300': isSelectable}"
        class="border-b dark:border-gray-700"
      >
        <td v-for="column in columns" :key="column.key" class="px-4 py-3">
          {{ row[column.key] }}
        </td>
        <td class="flex items-center px-4 py-3">
          <button
              v-if="isEditable"
              @click="editEntity(row)"
              class="mr-2 flex items-center justify-center rounded-lg bg-blue-700 px-4 py-2 text-sm font-medium text-white hover:bg-blue-800 focus:outline-none focus:ring-4 focus:ring-green-300 dark:bg-green-600 dark:hover:bg-green-700 dark:focus:ring-green-800"
            >
              Edit
        </button>
          <button
            @click="deleteEntity(row.id)"
            class="flex items-center justify-center rounded-lg bg-red-700 px-4 py-2 text-sm font-medium text-white hover:bg-red-800 focus:outline-none focus:ring-4 focus:ring-green-300 dark:bg-green-600 dark:hover:bg-green-700 dark:focus:ring-green-800"
          >
            Delete
          </button>
        </td>
      </tr>
    </tbody>
  </table>
</template>

<script setup>
const emit = defineEmits(['edit', 'delete', 'selected-action'])

const { rows, columns } = defineProps({
  rows: {
    type: Array,
    required: true
  },
  columns: {
    type: Array,
    required: true
  },
  isEditable: {
    type: Boolean,
    default: false
  },
  isSelectable: {
    type: Boolean,
    default: false
  },
  emptyList: {
    type: String,
    default: "😃 Item List Empty!"
  }
})

const editEntity = (row) => {
  emit('edit', row)
}

const deleteEntity = (todoId) => {
  emit('delete', todoId)
}

const selected = (id, isEmitable) => {
  if(isEmitable){
    emit('selected-action', id)
  }
}
</script>
