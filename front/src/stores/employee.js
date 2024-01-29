import axios from 'axios';

export function getEmployee(){
    return axios.get('http://localhost:5254/api/employees')
}

export function deleteEmployee(employeeId){
    return axios.delete(`http://localhost:5254/api/employees/${employeeId}`)
}

export function createEmployee(data){
    return axios.post('http://localhost:5254/api/employees', {
        FirstName: data[0].value,
        LastName: data[1].value,
        BirthDate: data[2].value,
        email: data[3].value,
        phoneNumber: data[4].value,
        position: data[5].value,
      })
}

export function getEmployeeColumns() {
    return [
        {
        key: 'firstName',
        label: 'FirstName',
        value: 'firstName',
        },
        {
        key: 'lastName',
        label: 'LastName',
        value: 'lastName',
        },
        {
        key: 'birthDate',
        label: 'BirthDate',
        value: '2024-01-29T20:03:42.549Z',
        },
        {
        key: 'email',
        label: 'Email',
        value: `user${Math.floor(Math.random() * 1000)}@example.com`,
        },
        {
        key: 'phoneNumber',
        label: 'PhoneNumber',
        value: '06 00 00 00 00',
        },
        {
        key: 'position',
        label: 'Position',
        value: 'position',
        }
    ]
}
