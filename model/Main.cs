using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class main
    {
        public static void Main()
        {
            
            DatabaseManegement db = new DatabaseManegement();
            db.DBwrite();
        }
    }
}
