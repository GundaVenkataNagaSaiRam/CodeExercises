namespace Retalix.Contracts.Generated.Employee
{
    using Retalix.Contracts.Generated.Common;
    using Retalix.Contracts.Generated.Arts.PosLogV6.Source;
    
    
    /// <summary>
    /// Maintenance service for Employee Type.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("BatchContractGenerator.Console", "14.200.999")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://retalix.com/R10/services")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://retalix.com/R10/services", IsNullable=false)]
    [Retalix.Commons.Contracts.ContractDocumentationAttributes.ContractSourceAttribute("Schemas\\Employee\\EmployeeLookupAndMaintenance.xsd")]
    public partial class EmployeeMaintenanceRequest : MaintenanceServiceRequestAbstract
    {
        
        private EmployeeType employeeField;
        
        private ActionTypeCodes action1Field;
        
        private bool Action1FieldSpecified;
        
        /// <summary>
        /// The Employee  Type for maintenance (Add / Update / Delete).
        /// </summary>
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        public EmployeeType Employee
        {
            get
            {
                return this.employeeField;
            }
            set
            {
                this.employeeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Action")]
        public ActionTypeCodes Action1
        {
            get
            {
                return this.action1Field;
            }
            set
            {
                this.action1Field = value;
                this.Action1Specified = true;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public virtual bool Action1Specified
        {
            get
            {
                return this.Action1FieldSpecified;
            }
            set
            {
                this.Action1FieldSpecified = value;
            }
        }
    }
}
