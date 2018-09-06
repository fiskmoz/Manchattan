using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DatabaseManegement
    {
        public void DBwrite()
        {
            //File.WriteAllText(@"DB.json", JsonConvert.SerializeObject("name"));

            

            using(StreamWriter file = File.CreateText(@"DB.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, "namn");
            }
          

        }
    }
}
