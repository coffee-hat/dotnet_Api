<template>
    <table class="w-full text-left text-sm text-gray-500 dark:text-gray-400">
      <button
              @click="sendData"
              class="mr-2 flex items-center justify-center rounded-lg bg-green-700 px-4 py-2 text-sm font-medium text-white hover:bg-blue-800 focus:outline-none focus:ring-4 focus:ring-green-300 dark:bg-green-600 dark:hover:bg-green-700 dark:focus:ring-green-800"
            >
              Confirm
      </button>
      <tbody>
        <tr class="border-b dark:border-gray-700">
          <td v-for="item in currentData" :key="item.key" class="px-4 py-3">
            <input v-model="item.value" :placeholder="item.value"/>
          </td>
        </tr>
      </tbody>
    </table>
  </template>

<script>
export default {
    props: {
        data: Array,
        columns: Array
    },
    data(){
      return {
        currentData: this.getData(),
      }
    },
    methods: {
        sendData(){
            this.$emit('action-entity', this.data['id'], this.currentData)
        },
        getData(){
            return this.columns.map(el => {
                let item = []
                item.key = el.key
                item.value = this.data[el.key]
                return item
            }) 
        }
    },
    watch: {
        data(){
            this.currentData = this.getData()
        }
    }
}
</script>