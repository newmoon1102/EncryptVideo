using System;
using log4net;
using System.Windows.Forms;
using LoggingConfiguration;

namespace EncryptVideo
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            LogConfiguration.SetupLog4net();
            ILog log = LogManager.GetLogger(typeof(Program));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new EncryptVideoForm(log));
        }
    }
}
