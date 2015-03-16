using LogAn.Utility;
using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogAn.Tests.RhinoMock
{
    [TestFixture]
    public class RhinoMockReturnStubTests
    {
        [Test]
        public void ReturnResultsFromMock()
        {
            MockRepository mocks = new MockRepository();
            IGetResults resultGetter = mocks.DynamicMock<IGetResults>();
            using (mocks.Record())
            {
                resultGetter.GetSomeNumber("a");
                LastCall.Return(1);
                resultGetter.GetSomeNumber("a");
                LastCall.Return(2);
                resultGetter.GetSomeNumber("b");
                LastCall.Return(3);
            }
            int result1 = resultGetter.GetSomeNumber("b");
            Assert.AreEqual(3, result1);
            int result2 = resultGetter.GetSomeNumber("a");
            Assert.AreEqual(1, result2);
            int result3 = resultGetter.GetSomeNumber("a");
            Assert.AreEqual(1, result3);
        }

        [Test]
        public void UnstrickMocksFromMockNoVerifyFailure()
        {
            MockRepository mocks = new MockRepository();
            IGetResults resultGetter = mocks.DynamicMock<IGetResults>();
            using (mocks.Record())
            {
                resultGetter.GetSomeNumber("a");
                LastCall.Return(1);
                resultGetter.GetSomeNumber("b");
                LastCall.Return(2);
            }
            int result1 = resultGetter.GetSomeNumber("b");
            int result2 = resultGetter.GetSomeNumber("a");
            int result3 = resultGetter.GetSomeNumber("c");//非严格模拟对象不会导致调用失败
            mocks.Verify(resultGetter); //模拟对象没有调用会导致失败
        }


        [Test]
        public void StrickMocksFromMockNoVerifyFailure()
        {
            MockRepository mocks = new MockRepository();
            IGetResults resultGetter = mocks.StrictMock<IGetResults>();
            using (mocks.Record())
            {
                resultGetter.GetSomeNumber("a");
                LastCall.Return(1);
                resultGetter.GetSomeNumber("b");
                LastCall.Return(2);
            }
            int result1 = resultGetter.GetSomeNumber("b");
           // int result2 = resultGetter.GetSomeNumber("a");
            int result3 = resultGetter.GetSomeNumber("c");//严格模拟对象没有设置预期，导致调用失败
            mocks.Verify(resultGetter); //如果预置其它有一个没有调将导致测试失败，如a;多调不会导致失败,如c
        }


        [Test]
        public void StubFromMockNoVerifyFailure()
        {
            MockRepository mocks = new MockRepository();
            IGetResults resultGetter = mocks.Stub<IGetResults>();
            using (mocks.Record())
            {
                resultGetter.GetSomeNumber("a");
                LastCall.Return(1);
            }
            int result1 = resultGetter.GetSomeNumber("b");
            int result2 = resultGetter.GetSomeNumber("c");
            mocks.Verify(resultGetter); //桩不会导致验证失败
        }



        delegate int ParseIntDlg(string key);

        private int ParseInt(string key)
        {
            return int.Parse(key);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException),ExpectedMessage = "File length is less!")]
        public void ReturnResultsFromMockCommand()
        {
            MockRepository mocks = new MockRepository();
            IGetResults resultGetter = mocks.DynamicMock<IGetResults>();
            using (mocks.Record())
            {
                resultGetter.GetSomeNumber("a.slf");
                LastCall.Throw(new ArgumentException("File length is less!"));
                resultGetter.GetSomeNumber("12");
                LastCall.Do(new ParseIntDlg(ParseInt));
            }            
            int result2 = resultGetter.GetSomeNumber("12");
            Assert.AreEqual(12, result2);
            int result1 = resultGetter.GetSomeNumber("a.slf");
        }

        [Test]
        public void PropertyFromMock()
        {
            MockRepository mockRepo = new MockRepository();
            IGetResults resultGetter = mockRepo.Stub<IGetResults>();
            resultGetter.CacheNumber = "V";
            var v = resultGetter.Version;
            Assert.AreEqual("V", resultGetter.CacheNumber);
        }



    }
}
