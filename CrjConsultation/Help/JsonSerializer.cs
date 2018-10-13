using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrjConsultation.Help
{
    public class JsonSerializer
    {
        public static T DeserializeObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
        public static string SerializeObject<T>(T t)
        {
            return JsonConvert.SerializeObject(t);
        }
    }
}
