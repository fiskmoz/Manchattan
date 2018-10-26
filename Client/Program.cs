using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
			Controller.ClientDriver client = new Controller.ClientDriver();
            Application.EnableVisualStyles();
            client.Run();
        }
    }
}
