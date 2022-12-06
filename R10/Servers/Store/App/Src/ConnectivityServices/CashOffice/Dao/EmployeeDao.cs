using Retalix.StoreServices.Model.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retalix.StoreServices.Model;
using Retalix.StoreServices.Model.Employee;
using Retalix.StoreServices.Model.Infrastructure.Employee;
using NHibernate;
using NHibernate.Criterion;
using Retalix.StoreServices.Model.Cache;
namespace Retalix.StoreServices.Connectivity.CashOffice.Dao
{
    public class EmployeeDao : IEmployeeDao
    {
       private readonly ISessionProvider<ISession> _sessionProvider;       
       public EmployeeDao(ISessionProvider<ISession> sessionProvider)
       {
           _sessionProvider = sessionProvider;
       }

        public void Delete(EmployeeDto employee)
        {           
            var existingEmployee = GetEmployee(employee.EmployeeId);
            if (existingEmployee != null)
            {
                _sessionProvider.Session.Clear();               
                _sessionProvider.Session.Delete(existingEmployee);               
            }
        }

       
        public EmployeeDto GetEmployee(int employeeId)
        {
            var result = _sessionProvider.Session.QueryOver<EmployeeDto>().Where(x => x.EmployeeId == employeeId).SingleOrDefault();

            EmployeeDto employeeDto = null;

            if (result != null)
            {
                employeeDto = new EmployeeDto()
                {
                    EmployeeId = result.EmployeeId,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    Email = result.Email                   
                };
            }

            return employeeDto;
        }

        public void SaveOrUpdate(EmployeeDto employeeRow)
        {
            var existingEmployee = GetEmployee(employeeRow.EmployeeId);
            if (existingEmployee != null)
            {

                (existingEmployee).FirstName = (employeeRow).FirstName;
                (existingEmployee).LastName = (employeeRow).LastName;
                (existingEmployee).Email = (employeeRow).Email;               
            }
            else
            {
                existingEmployee = employeeRow;
            }

            _sessionProvider.Session.Merge(existingEmployee);            
        }
    }
}
