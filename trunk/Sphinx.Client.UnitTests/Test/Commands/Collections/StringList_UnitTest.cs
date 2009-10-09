﻿using System;
using System.IO;
using System.Text;
using Sphinx.Client.Commands.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sphinx.Client.IO;
using Sphinx.Client.UnitTests.Mock.IO;

namespace Sphinx.Client.UnitTests.Test.Commands.Collections
{
    
    
    /// <summary>
    ///This is a test class for StringListUnitTest and is intended
    ///to contain all StringList Unit Tests
    ///</summary>
    [TestClass]
    public class StringListUnitTest
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod]
        public void ToStringTest()
        {
            StringList target = new StringList();
            // empty list
            string expected = string.Empty;
            string actual = target.ToString();
            Assert.AreEqual(expected, actual);

            // 1 item in list
            target.Add("test1");
            expected = "test1";
            actual = target.ToString();
            Assert.AreEqual(expected, actual);

            // 2 items in list
            target.Add("test2");
            expected = "test1,test2"; 
            actual = target.ToString();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Serialize
        ///</summary>
        [TestMethod]
        public void SerializeTest()
        {
            StringList target = new StringList();
            MemoryStream stream = new MemoryStream();
            BinaryWriterBase writer = new BinaryWriterMock(stream);
            // empty list
            target.Serialize(writer);
            string expected = "<string></string>";
            string actual = Encoding.UTF8.GetString(stream.ToArray());
            Assert.AreEqual(expected, actual);

            // 1 item in list
            target.Add("A");
            stream.Position = 0;
            target.Serialize(writer);
            expected = "<string>A</string>";
            actual = Encoding.UTF8.GetString(stream.ToArray());
            Assert.AreEqual(expected, actual);

            // 2 items in list
            target.Add("B");
            stream.Position = 0;
            target.Serialize(writer);
            expected = "<string>A,B</string>";
            actual = Encoding.UTF8.GetString(stream.ToArray());
            Assert.AreEqual(expected, actual);
        }
    }
}
