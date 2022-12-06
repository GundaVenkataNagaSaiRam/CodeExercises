using Retalix.StoreServices.Model.Infrastructure.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retalix.StoreServices.Model.Employee
{
    public interface IEmployeeDao
    {
        EmployeeDto GetEmployee(int employeeId);
        void SaveOrUpdate(EmployeeDto employeeRow);
        void Delete(EmployeeDto employee);
    }
}
