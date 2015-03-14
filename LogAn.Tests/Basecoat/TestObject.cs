using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogAn.Tests.Basecoat
{
    public class TestObject
    {
        string ID = "";
        public TestObject(string id)
        {
            this.ID = id;
        }

        public override bool Equals(object obj)
        {
            return  this.ID==((TestObject)obj).ID;
        }
        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }
    }
}
