using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SoftEngChatClient
{
    class Program
    {
        
        static void Main(string[] args)
        {
			Controller.ClientDriver client = new Controller.ClientDriver();
            client.Run();
        }
    }
}
