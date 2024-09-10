using BilgeKoleji.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BilgeKoleji.Ui.CORE
{
    public static class BİlgeConvert
    {
        public static string JsonSerialize(object data)
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }

        public static UserDTO JsonDeSerializeUserDTO(string data)
        {
            return JsonConvert.DeserializeObject<UserDTO>(data);
        }


    }
}
