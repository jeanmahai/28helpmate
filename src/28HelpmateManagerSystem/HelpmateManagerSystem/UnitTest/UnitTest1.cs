﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using DataEntity;

namespace UnitTest
{
    /// <summary>
    /// UnitTest1 的摘要说明
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，该上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        //
        // 编写测试时，可以使用以下附加特性:
        //
        // 在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在运行每个测试之前，使用 TestInitialize 来运行代码
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在每个测试运行完之后，使用 TestCleanup 来运行代码
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestLogin()
        {
            string result = "";
            SystemUser user = new SystemUser();
            result = SystemUserLogic.Login("admin", "123", "127.0.0.1", out user);
        }
        [TestMethod]
        public void TestChangePwd()
        {
            var result = SystemUserLogic.ChangePwd(100000, "1234", "123");
        }

        [TestMethod]
        public void TestCreatePayCard()
        {
            string result = "";
            result = PayCardLogic.CreatePayCard(PayCardCategory.Day, 1000, DateTime.Now, DateTime.Now.AddYears(2));
        }
        [TestMethod]
        public void TestQueryPayCard()
        {
            var data = PayCardLogic.QueryPayCard(2, 9, null, null, null, null);
        }
        [TestMethod]
        public void TestGetPayCardBySysNo()
        {
            var data = PayCardLogic.GetBySysNo(18651);
        }
        [TestMethod]
        public void TestEnablePayCard()
        {
            var data = PayCardLogic.EnablePayCard(18651);
        }
        [TestMethod]
        public void TestDisablePayCard()
        {
            var data = PayCardLogic.DisablePayCard(18651);
        }
        [TestMethod]
        public void TestDeletePayCard()
        {
            var data = PayCardLogic.DeletePayCard(18651);
        }
        [TestMethod]
        public void TestEditPayCard()
        {
            PayCard entity = new PayCard();
            entity.SysNo = 18652;
            entity.CategorySysNo = PayCardCategory.Month;
            entity.Status = PayCardStatus.Invalid;
            entity.BeginTime = DateTime.Now.AddDays(-1);
            entity.EndTime = DateTime.Now;
            var data = PayCardLogic.Edit(entity);
        }

        [TestMethod]
        public void TestGetUserPayLog()
        {
            var data = PayLogLogic.GetUserPayLog(1, 8, 2);
        }
        [TestMethod]
        public void TestGetPayLogByBatch()
        {
            var data = PayLogLogic.GetPayLogByBatch(1, 8, DateTime.Now.AddYears(-1), DateTime.Now.AddYears(1));
        }
    }
}
