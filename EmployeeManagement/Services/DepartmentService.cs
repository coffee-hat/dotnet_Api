using EmployeeManagement.Dto.Department;
using EmployeeManagement.Entities;
using EmployeeManagement.Repositories.Interfaces;
using EmployeeManagement.Services.Interfaces;
using EmployeeManagement.Utils.Exception;

namespace EmployeeManagement.Services;

public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<List<ReadDepartment>> GetDepartments()
        {
            var departments = await _departmentRepository.GetDepartmentsAsync();

            List<ReadDepartment> readDepartments = new List<ReadDepartment>();

            foreach (var department in departments)
            {
                readDepartments.Add(new ReadDepartment()
                {
                    Id = department.DepartmentId,
                    Name = department.Name,
                });
            }

            return readDepartments;
        }
        
        public async Task<ReadDepartment> GetDepartmentByIdAsync(int departmentId)
        {
            var department = await _departmentRepository.GetDepartmentByIdAsync(departmentId);

            if (department is null)
                throw new ApiException($"Echec de recupération des informations d'un département car il n'existe pas : {departmentId}");

            return new ReadDepartment()
            {
                Id = department.DepartmentId,
                Name = department.Name,
            };
        }

        public async Task UpdateDepartmentAsync(int departmentId, UpdateDepartment department)
        {
            var departmentGet = await _departmentRepository.GetDepartmentByIdAsync(departmentId)
                ?? throw new ApiException($"Echec de mise à jour d'un département : Il n'existe aucun departement avec cet identifiant : {departmentId}");

            departmentGet = await _departmentRepository.GetDepartmentByNameAsync(department.Name);
            if (departmentGet is not null && departmentId != departmentGet.DepartmentId)
            {
                throw new ApiException($"Echec de mise à jour d'un département : Il existe déjà un département avec ce nom {department.Name}");
            }

            departmentGet.Name = department.Name;
            departmentGet.Description = department.Description;
            departmentGet.Address = department.Address;

            await _departmentRepository.UpdateDepartmentAsync(departmentGet);

        }

        public async Task DeleteDepartmentById(int departmentId)
        {
            var departmentGet = await _departmentRepository.GetDepartmentByIdWithIncludeAsync(departmentId)
              ?? throw new ApiException($"Echec de suppression d'un département : Il n'existe aucun departement avec cet identifiant : {departmentId}");

            if (departmentGet.EmployeeDepartments.Any())
            {
                throw new ApiException("Echec de suppression car ce departement est lié à des employés");
            }

            await _departmentRepository.DeleteDepartmentByIdAsync(departmentId);
        }

        public async Task<ReadDepartment> CreateDepartmentAsync(CreateDepartment department)
        {
            var departmentGet = await _departmentRepository.GetDepartmentByNameAsync(department.Name);
            if (departmentGet is not null)
            {
                throw new ApiException($"Echec de création d'un département : Il existe déjà un département avec ce nom {department.Name}");
            }

            var departementTocreate = new Department()
            {
                Name = department.Name,
                Description = department.Description,
                Address = department.Address,
            };

            var departmentCreated = await _departmentRepository.CreateDepartmentAsync(departementTocreate);

            return new ReadDepartment()
            {
                Id = departmentCreated.DepartmentId,
                Name = departmentCreated.Name,
            };
        }
    }
