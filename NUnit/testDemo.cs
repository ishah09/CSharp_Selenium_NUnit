using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NUnitDemo.TestDemo
{
    class testDemo
    {
        // private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            ILog Log = LogManager.GetLogger("SampleAppender");
            log4net.GlobalContext.Properties["LogName"] = "Test";
            XmlConfigurator.Configure();
            Log.Info("Hello World");
        }
    }
}
