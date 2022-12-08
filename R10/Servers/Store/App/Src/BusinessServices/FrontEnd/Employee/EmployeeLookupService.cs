using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retalix.Contracts.Generated.Common;
using Retalix.Contracts.Generated.Employee;
using Retalix.StoreServices.BusinessServices.Common.Services;
using Retalix.StoreServices.BusinessServices.FrontEnd.AutoMapping;
using Retalix.StoreServices.BusinessServices.FrontEnd;
using Retalix.StoreServices.Model.AccessServices;
using Retalix.StoreServices.Model.Infrastructure.Service;
using Retalix.StoreServices.Model.Employee;

namespace Retalix.StoreServices.BusinessServices.FrontEnd.Employee
{
    public class EmployeeLookupService : BusinessServiceBase<EmployeeLookupRequest, EmployeeLookupResponse>
    {
        private readonly IEmployeeDao _employeeDao;
        private readonly DataMapper _mapper;

        public EmployeeLookupService(IEmployeeDao employeeDao)
        {
            _employeeDao = employeeDao;
            _mapper = new DataMapper();
            _mapper.AddConfig(new EmployeeMappingConfiguration());
        }

        public override IDocumentResponse FormatErrorResponse(IDocumentRequest request, Exception exception)
        {
            string resultMessage = exception.Message;
            return new DocumentStringResponse(resultMessage);
        }

        protected override EmployeeLookupResponse InternalExecute()
        {
                if (Request != null && Request.Request != null && Request.Request.EmployeeId == 0)
                    throw new Exception("Invalid Request");

            var employee = _employeeDao.GetEmployee(Request.Request.EmployeeId); 

            return CreateResponseForKey(employee);
        }

        private static EmployeeLookupResponse CreateResponseForKey(EmployeeDto employeeRow)
        {
            var response = new EmployeeLookupResponse { Header = new RetalixCommonHeaderType() };
            var employee = new EmployeeType
            {
                FirstName = employeeRow.FirstName,
                LastName = employeeRow.LastName,
                Email = employeeRow.Email,
            };

            if (employeeRow != null)
            {
                response.Response = new EmployeeType[1] { employee };
            }
            return response;
        }
    }
}
