using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WR.Tools
{
    public static class Logger
    {
        private static ILog _log = null;     

        static Logger()
        {
            
            using (var stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("WR.Tools.Log4Net.config"))
            {
                log4net.Config.XmlConfigurator.Configure(stream);
            }                
            _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        public static void Error(string msg, Exception ex = null)
        {
            _log.Error(msg, ex);
        }
    }
}
