namespace Retalix.Contracts.Generated.Employee
{
    using Retalix.Contracts.Generated.Common;
    using Retalix.Contracts.Generated.Arts.PosLogV6.Source;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("BatchContractGenerator.Console", "14.200.999")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://retalix.com/R10/services")]
    [Retalix.Commons.Contracts.ContractDocumentationAttributes.ContractSourceAttribute("Schemas\\Employee\\EmployeeLookupAndMaintenance.xsd")]
    public partial class EmployeeLookupRequestRequest
    {
        
        private int employeeIdField;
        
        private bool EmployeeIdFieldSpecified;
        
        [Retalix.Commons.Contracts.ContractValidationAttributes.ContractRequiredAttribute()]
        public int EmployeeId
        {
            get
            {
                return this.employeeIdField;
            }
            set
            {
                this.employeeIdField = value;
                this.EmployeeIdSpecified = true;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public virtual bool EmployeeIdSpecified
        {
            get
            {
                return this.EmployeeIdFieldSpecified;
            }
            set
            {
                this.EmployeeIdFieldSpecified = value;
            }
        }
    }
}
