using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gyumolcsok
{
    internal static class Program
    {
        public static FormMain openForm = null;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            openForm = new FormMain();
            Application.Run(openForm);
        }
    }
}
