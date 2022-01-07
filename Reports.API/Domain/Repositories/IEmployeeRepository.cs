using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reports.API.Domain.Models;
using Task = System.Threading.Tasks.Task;

namespace Reports.API.Domain.Repositories
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
    }
}