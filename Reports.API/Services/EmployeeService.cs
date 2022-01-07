using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Reports.API.DTO;
using Reports.API.Domain.Services;
using Reports.API.Domain.Models;
using Reports.API.Domain.Repositories;
using Reports.API.Persistence.Contexts;
using Reports.API.Persistence.Repositories;

namespace Reports.API.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _repository;

        public EmployeeService(ReportAppContext context, IMapper mapper)
        {
            _repository = new EmployeeRepository(context);
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            var employeeEntities = await _repository.GetAllAsync();
            return employeeEntities
                .Select(employeeEntity => _mapper.Map<EmployeeDto>(employeeEntity))
                .ToList();
            }

        public async Task<EmployeeDto> GetEmployeeAsync(Int32 id)
        {
            var employee = await _repository.GetByIdAsync(id);
            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task CreateEmployeeAsync(EmployeeDto employee)
        {
            var employeeEntity = _mapper.Map<Employee>(employee);
            await _repository.InsertAsync(employeeEntity);
            await _repository.SaveAsync();
        }

        public async Task UpdateEmployeeAsync(EmployeeDto employee)
        {
            var employeeEntity = _mapper.Map<Employee>(employee);
            await _repository.UpdateAsync(employeeEntity);
            await _repository.SaveAsync();
        }

        public async Task DeleteEmployeeAsync(Int32 id)
        {
            await _repository.DeleteAsync(id);
            await _repository.SaveAsync();
        }
    }
}