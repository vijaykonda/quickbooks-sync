﻿using NUnit.Framework;
using QbSync.QbXml.Objects;
using QbSync.QbXml.Tests.Helpers;

namespace QbSync.QbXml.Tests.QbXml
{
    [TestFixture]
    class InvoiceQueryResponseTests
    {
        [Test]
        public void BasicInvoiceResponseTest()
        {
            var invoiceRet = "<InvoiceRet><TxnID>80000001-1422671082</TxnID><TimeCreated>2015-01-30T18:24:42-08:00</TimeCreated><TimeModified>2015-01-30T18:24:42-08:00</TimeModified><EditSequence>1422671082</EditSequence><CustomerRef><ListID>123456</ListID></CustomerRef><TxnDate>2015-02-19</TxnDate></InvoiceRet>";

            var response = new QbXmlResponse();
            var rs = response.GetSingleItemFromResponse<InvoiceQueryRsType>(QuickBooksTestHelper.CreateQbXmlWithEnvelope(invoiceRet, "InvoiceQueryRs"));
            var invoices = rs.InvoiceRet;
            var invoice = invoices[0];

            Assert.AreEqual(1, invoices.Length);
            Assert.AreEqual("80000001-1422671082", invoice.TxnID);
            Assert.AreEqual("123456", invoice.CustomerRef.ListID);
        }
    }
}