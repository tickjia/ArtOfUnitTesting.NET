using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogAn.Tests.Stub
{
    class LogAnalyzerWithoutStubTestSubstitute :LogAnalyzerWithoutStub
    {
        public Exception WriteException = null;
        public bool FileNameOK;
        protected override bool IsValid(string fileName)
        {
            return FileNameOK;
        }

        protected override void WriteToFile(string fileName)
        {
            if (WriteException != null) throw WriteException;
        }
    }
}
