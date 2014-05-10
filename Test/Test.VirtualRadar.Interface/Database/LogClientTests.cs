﻿// Copyright © 2010 onwards, Andrew Whewell
// All rights reserved.
//
// Redistribution and use of this software in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
//    * Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
//    * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
//    * Neither the name of the author nor the names of the program's contributors may be used to endorse or promote products derived from this software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE AUTHORS OF THE SOFTWARE BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualRadar.Interface.Database;
using Test.Framework;
using InterfaceFactory;

namespace Test.VirtualRadar.Interface.Database
{
    [TestClass]
    public class LogClientTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void LogClient_Constructor_Inititalises_To_Known_State_And_Properties_Work()
        {
            var logClient = new LogClient();

            TestUtilities.TestProperty(logClient, "Id", 0L, 12L);
            TestUtilities.TestProperty(logClient, "IpAddress", null, "Ab");
            TestUtilities.TestProperty(logClient, "ReverseDns", null, "Hh");
            TestUtilities.TestProperty(logClient, "ReverseDnsDate", null, DateTime.Now);
        }

        [TestMethod]
        [DataSource("Data Source='DataTests.xls';Provider=Microsoft.Jet.OLEDB.4.0;Persist Security Info=False;Extended Properties='Excel 8.0'",
                    "LogClientAddress$")]
        public void LogClient_Address_Is_Conversion_Of_IpAddress_Property()
        {
            var worksheet = new ExcelWorksheetData(TestContext);

            var logClient = new LogClient() { IpAddress = worksheet.EString("IpAddress") };

            var expected = worksheet.String("Address");
            if(expected == null) Assert.IsNull(logClient.Address);
            else                 Assert.AreEqual(expected, logClient.Address.ToString());
        }

        [TestMethod]
        [DataSource("Data Source='DataTests.xls';Provider=Microsoft.Jet.OLEDB.4.0;Persist Security Info=False;Extended Properties='Excel 8.0'",
                    "LogClientIsLocal$")]
        public void LogClient_IsLocal_Is_Conversion_Of_IpAddress_Property()
        {
            var worksheet = new ExcelWorksheetData(TestContext);

            var logClient = new LogClient() { IpAddress = worksheet.EString("IpAddress") };

            Assert.AreEqual(worksheet.Bool("IsLocal"), logClient.IsLocal);
        }
    }
}
