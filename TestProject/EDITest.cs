using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EDI_Parser;
using System.IO;

namespace TestProject
{
    [TestClass]
    public class EDITest
    {
        [TestMethod]
        public void ParseMessage()
        {
            EDIParser parser = new EDIParser();           
            parser.LoadFile(new StringReader(Properties.Resources.EDI_837));
            var ret =parser.Groups[0].TransactionSet[0].GetMessage();
        }
    }
}
