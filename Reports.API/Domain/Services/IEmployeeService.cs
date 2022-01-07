using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Reports.API.DTO;

namespace Reports.API.Domain.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllAsync();
        Task<EmployeeDto> GetEmployeeAsync(Int32 id);
        Task CreateEmployeeAsync(EmployeeDto employee);
        Task UpdateEmployeeAsync(EmployeeDto employee);
        Task DeleteEmployeeAsync(Int32 id);
    }
}