using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogAn.Utility
{
    public class FileExtensionManager : IExtensionManager
    {
        public bool IsValid(string fileName)
        {
            string extensionName = System.Configuration.ConfigurationSettings.AppSettings["extension"];            
            if (!fileName.EndsWith(extensionName))
                return false;
            return true;
        }
        
    }
}
