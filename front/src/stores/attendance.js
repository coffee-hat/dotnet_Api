import axios from 'axios';

export function getAttendance(id){
    return axios.get(`http://localhost:5254/api/Attendance/${id}`)
}

export function deleteAttendance(id){
    return axios.delete(`http://localhost:5254/api/Attendance/${id}`)
}

export function createAttendance(employeeId, data){
    return axios.post('http://localhost:5254/api/Attendance', {
        EmployeeId: employeeId,
        ArrivingDate: data[1].value,
        DepartureDate: data[2].value
      })
}

export function getAttendanceColumns() {
    return [
        {
        key: 'employeeId',
        label: 'EmployeeId',
        value: 'employeeId',
        },
        {
        key: 'arrivingDate',
        label: 'ArrivingDate',
        value: '2024-01-23T19:12:10',
        },
        {
        key: 'departureDate',
        label: 'DepartureDate',
        value: '2024-01-23T19:12:10',
        }
    ]
}
