using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogAn.Utility
{
    public static class Factories
    {
        public static ManagerFactory Managers = new ManagerFactory();

        public static IManagerFactory ManagerFactory= new ManagerFactory();
    }
}
