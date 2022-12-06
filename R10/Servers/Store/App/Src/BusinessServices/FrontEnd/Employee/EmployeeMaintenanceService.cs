using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retalix.Contracts.Generated.Common;
using Retalix.Contracts.Generated.Employee;
using Retalix.StoreServices.BusinessServices.Common.Services;
using Retalix.StoreServices.BusinessServices.FrontEnd.AutoMapping;
using Retalix.StoreServices.BusinessServices.FrontEnd.Employee;
using Retalix.StoreServices.Model.Employee;

namespace Retalix.StoreServices.BusinessServices.FrontEnd.Employee
{
    public class EmployeeMaintenanceService : BusinessServiceBase<EmployeeMaintenanceRequest, EmployeeMaintenanceResponse>
    {
        private readonly IEmployeeDao _employeeDAO;
        private readonly DataMapper _mapper;

        public EmployeeMaintenanceService(IEmployeeDao employeeDAO)
        {
            _employeeDAO = employeeDAO;
            _mapper = new DataMapper();
            _mapper.AddConfig(new EmployeeMappingConfiguration());
        }

        protected override EmployeeMaintenanceResponse InternalExecute()
        {
            switch (Request.Action1)
            {
                case ActionTypeCodes.AddOrUpdate:
                case ActionTypeCodes.AddUpdate:
                    {
                        this.ManipulateEmployee(Request.Employee);
                        break;
                    }                
                case ActionTypeCodes.Delete:
                    DeleteEmployee(Request.Employee);
                    break;
                case ActionTypeCodes.Lookup:
                    break;                
                default:
                    break;
            }
            return (EmployeeMaintenanceResponse)(Request.Header.MessageId == null ? BuildResponse() : BuildResponse(Request.Header.MessageId.Value));
        }

        private object BuildResponse()
        {
            throw new NotImplementedException();
        }

        private void ManipulateEmployee(EmployeeType employeeRow)
        {
            var employee = new EmployeeDto()
            {
                EmployeeId = employeeRow.EmployeeId,
                FirstName = employeeRow.FirstName,
                LastName = employeeRow.LastName,
                Email = employeeRow.Email,
            };

            _employeeDAO.SaveOrUpdate(employee);
        }

        private void DeleteEmployee(EmployeeType employeeRow)
        {
            var employee = new EmployeeDto
            {
                EmployeeId = employeeRow.EmployeeId
            };

            _employeeDAO.Delete(employee);
        }

        private EmployeeMaintenanceResponse BuildResponse(string requestId = null)
        {
            return new EmployeeMaintenanceResponse
            {
                Header = new RetalixCommonHeaderType
                {
                    Response = new RetalixResponseCommonData
                    {
                        ResponseCode = "OK",
                        RequestID = requestId
                    }
                }
            };
        }

        public override Model.Infrastructure.Service.IDocumentResponse FormatErrorResponse(Model.Infrastructure.Service.IDocumentRequest request, Exception exception)
        {
            throw new NotImplementedException();
        }
    }
}
