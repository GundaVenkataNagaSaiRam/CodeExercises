namespace Retalix.Contracts.Generated.Employee
{
    using Retalix.Contracts.Generated.Common;
    using Retalix.Contracts.Generated.Arts.PosLogV6.Source;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("BatchContractGenerator.Console", "14.200.999")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://retalix.com/R10/services")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://retalix.com/R10/services", IsNullable=false)]
    [Retalix.Commons.Contracts.ContractDocumentationAttributes.ContractSourceAttribute("Schemas\\Employee\\EmployeeLookupAndMaintenance.xsd")]
    public partial class EmployeeLookupResponse : Retalix.Contracts.Interfaces.IHeaderResponse
    {
        
        private RetalixCommonHeaderType headerField;
        
        private EmployeeType[] responseField;
        
        private string majorVersionField;
        
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        public RetalixCommonHeaderType Header
        {
            get
            {
                return this.headerField;
            }
            set
            {
                this.headerField = value;
            }
        }
        
        [System.Xml.Serialization.XmlArrayItemAttribute("EmployeeRow", IsNullable=false)]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        public EmployeeType[] Response
        {
            get
            {
                return this.responseField;
            }
            set
            {
                this.responseField = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string MajorVersion
        {
            get
            {
                return this.majorVersionField;
            }
            set
            {
                this.majorVersionField = value;
            }
        }
    }
}
