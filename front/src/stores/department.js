import axios from 'axios';

export function getDepartment(){
    return axios.get('http://localhost:5254/api/Departments')
}

export function deleteDepartment(id){
    return axios.delete(`http://localhost:5254/api/Departments/${id}`)
}

export function createDepartment(data){
    return axios.post('http://localhost:5254/api/Departments', {
        Name: data[0].value,
        Description: data[1].value,
        Address: data[2].value
      })
}

export function updateDepartment(id, data){
    return axios.put(`http://localhost:5254/api/Departments/${id}`, {
        Name: data[0].value,
        Description: data[1].value,
        Address: data[2].value
      })
}

export function getDepartmentColumns() {
    return [
        {
        key: 'name',
        label: 'Name',
        value: 'name',
        },
        {
        key: 'description',
        label: 'Description',
        value: 'description',
        },
        {
        key: 'address',
        label: 'Address',
        value: 'address',
        }
    ]
}
