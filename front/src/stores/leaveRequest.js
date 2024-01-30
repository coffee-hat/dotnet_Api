import axios from 'axios';

export function getLeaveRequest(id){
    return axios.get(`http://localhost:5254/api/LeaveRequest/${id}`)
}

export function deleteLeaveRequest(id){
    return axios.delete(`http://localhost:5254/api/LeaveRequest/${id}`)
}

export function createLeaveRequest(employeeId, data){
    return axios.post('http://localhost:5254/api/LeaveRequest', {
        EmployeeId: employeeId,
        Status: 0,
        RequestDate: data[1].value,
        StartDate: data[2].value,
        EndDate: data[3].value
      })
}

export function getLeaveRequestColumns() {
    return [
        {
        key: 'employeeId',
        label: 'EmployeeId',
        value: 'employeeId',
        },
        {
        key: 'requestDate',
        label: 'RequestDate',
        value: '2024-01-23T19:12:10',
        },
        {
        key: 'startDate',
        label: 'StartDate',
        value: '2024-01-23T19:12:10',
        },
        {
        key: 'endDate',
        label: 'EndDate',
        value: '2024-01-23T19:12:10',
        }
    ]
}
