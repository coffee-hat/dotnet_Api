<template>
  <Employee title="Employee" @selected-action="setEmployeeId"/>

  <Department title="Department"/>

  <Attendance title="Attendances" :employeeId="employeeId"/>

  <LeaveRequest title="LeaveRequests" :employeeId="employeeId"/>
</template>

<script>
import Employee from '@/components/Elements/Employee.vue'
import Department from '@/components/Elements/Department.vue'
import Attendance from '@/components/Elements/Attendance.vue'
import LeaveRequest from '@/components/Elements/LeaveRequest.vue'

export default {
  components: {
    Employee,
    Department,
    Attendance,
    LeaveRequest
  },
  data(){
    return {
      employeeId: Number
    }
  },
  methods: {
    setEmployeeId(id){
      this.employeeId = id
    }
  }
}

</script>

<style scoped>
/* Apply Tailwind CSS classes here */
</style>
