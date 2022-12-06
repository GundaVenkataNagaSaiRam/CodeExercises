using Retalix.StoreServices.BusinessServices.FrontEnd.AutoMapping;
using Retalix.StoreServices.Model.Infrastructure.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Retalix.Contracts.Generated.Employee;

namespace Retalix.StoreServices.BusinessServices.FrontEnd
{
    public class EmployeeMappingConfiguration :DataMapperConfigurationBase
    {
        public override void Configure(DataMapper mapper)
        {
            if (mapper.HasNoMapFor<IEmployeeConfig, EmployeeType>())
                mapper.CreateMap<IEmployeeConfig, EmployeeType>();
        }
    }
}
