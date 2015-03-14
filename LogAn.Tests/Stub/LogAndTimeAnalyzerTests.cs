using LogAn.Tests.Utility;
using LogAn.Utility;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogAn.Tests.Stub
{
    [TestFixture]
    public class LogAndTimeAnalyzerTests
    {
        LogAndTimeAnalyzer analyzer = null;
        [SetUp]
        public void SetUp()
        {
            //如果没有用桩，将依赖扩展配置与服务
            //analyzer = new LogAndTimeAnalyzer();

            #region 加桩
           
            var fakeExtManager = new StubExtensionManager();
            fakeExtManager.ShouldExtensionBeValid = true;
            var fakeSystemTimeManager = new StubSystemTimeManager();
            DateTime dt=DateTime.Now;
            fakeSystemTimeManager.AmericanTime = dt.AddHours(-14);
            fakeSystemTimeManager.ChineseTime = dt;
            fakeSystemTimeManager.NowTime = dt;
           
            analyzer = new LogAndTimeAnalyzer(fakeExtManager, fakeSystemTimeManager);


            #region 参数对象重构
            //UtilityObject utilities = new UtilityObject();
            //utilities.ExtensionManager = fakeExtManager;
            //utilities.SystemTimeManager = fakeSystemTimeManager;
            //analyzer = new LogAndTimeAnalyzer(utilities);
            #endregion

            #region 使用set依赖注入

            //analyzer.ExtensionManager = fakeExtManager;
            //analyzer.SystemTimeManager = fakeExtManager;

            #endregion

            #endregion


        }

        [TearDown]
        public void TearDown()
        {
            analyzer = null;
            
        }
        [Test]
        public void IsValid_LowerCaseFileName_ReturnTrue()
        {
            Assert.IsTrue(analyzer.IsValid("Test.slf"), "valid extension file name!");
        }

        [Test]
        public void MoreThanChineseTime_NowPassOneMinute_ReturnTrue()
        {
            Assert.IsTrue(analyzer.MoreThanChineseTime(DateTime.Now.AddMinutes(1)), "More than chinese time!");
        }

        [Test]
        public void MoreThanAmericanTime_Now_ReturnTrue()
        {
            Assert.IsTrue(analyzer.MoreThanAmericanTime(DateTime.Now), "More than americal time!");
        }

        /// <summary>
        /// 系统时间服务桩；测试替代WCF
        ///** 注：如果桩对够用只用于一个测试中，把它与测试代码放入同一个文件。**
        /// </summary>
        internal class StubSystemTimeManager : ISystemTimeManager
        {
            public DateTime AmericanTime=DateTime.Now.AddHours(-14), ChineseTime=DateTime.Now,NowTime=DateTime.Now;
            
            public DateTime GetAmericanTime()
            {
                return AmericanTime;
            }

            public DateTime GetChineseTime()
            {
                return ChineseTime;
            }

            public DateTime GetNow()
            {
                return NowTime;
            }
        }


    }
}
