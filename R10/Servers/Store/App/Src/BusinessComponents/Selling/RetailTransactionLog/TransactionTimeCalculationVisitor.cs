using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Retalix.Contract.Schemas.Schema.ARTS.PosLog_V6.Objects;
using Retalix.StoreServices.Model.Infrastructure.StoreApplication;
using Retalix.StoreServices.Model.Selling;
using Retalix.StoreServices.Model.Selling.RetailTransaction.RetailTransactionLog;
using Retalix.StoreServices.Model.Document.ControlTransaction;
using Retalix.StoreServices.Model.Infrastructure.Audit;
using Retalix.StoreServices.Model.Infrastructure.Counter;
using Retalix.StoreServices.Model.Infrastructure.Globalization;
using Retalix.StoreServices.Model.Infrastructure.Service;
using Retalix.StoreServices.Model.Infrastructure.StoreApplication;
using Retalix.StoreServices.Model.Selling;
using Retalix.StoreServices.Model.Selling.Returns;

namespace Retalix.StoreServices.BusinessComponents.Selling.RetailTransactionLog
{
    public class TransactionTimeCalculationVisitor : IRetailTransactionLogDocumentCreationCoreVisitor
    {
        private readonly IAuditLogDao _auditLogDao;
        private readonly IFactory _factory;

        public TransactionTimeCalculationVisitor(IAuditLogDao auditLogDao, IFactory factory)
        {
            _auditLogDao = auditLogDao;
            _factory = factory;
        }
        
        public void Visit(IRetailTransaction retailTransaction, IRetailTransactionLogDocumentWriter writer)
        {
            var transaction = writer.LogDocument.ObjectContent as TransactionDomainSpecific;
            XmlElement transactionDurationElement =
                ToXmlElement(new XElement("TransactionTime", (retailTransaction.EndTime - retailTransaction.StartTime).ToString(@"hh\:mm\:ss"), new XAttribute("format", "hh:mm:ss")));
            transaction.Any = new List<XmlElement> { transactionDurationElement };
            writer.UpdateArtsTransaction(transaction);
        }
        
        private static XmlElement ToXmlElement(XElement el)
        {
            var doc = new XmlDocument();
            doc.Load(el.CreateReader());
            return doc.DocumentElement;
        }
    }
}
