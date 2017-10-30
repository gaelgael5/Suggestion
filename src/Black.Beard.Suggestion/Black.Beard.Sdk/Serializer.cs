using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pssa.Biz.Rerouting.ComponentModel
{
    public static class Serializer
    {


        public static void SaveFile<T>(T model, string filename)
        {
            if (File.Exists(filename))
                File.Delete(filename);

            JsonSerializer serializer = new JsonSerializer();
            string txt = JsonConvert.SerializeObject(model, Formatting.Indented);
            File.WriteAllText(filename, txt, Encoding.UTF8);
        }

        /// <summary>
        /// Deserialize file in the specified generic type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="file"></param>
        /// <returns></returns>
        public static T LoadFile<T>(string file)
        {

            if (!File.Exists(file))
                throw new FileNotFoundException(file);
            string payload = File.ReadAllText(file, Encoding.UTF8);
            T _result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(payload);
            return _result;

        }

        /// <summary>
        /// Deserialize file in the specified generic type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="file"></param>
        /// <returns></returns>
        public static T LoadContent<T>(string content)
        {
            T _result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(content);
            return _result;

        }


    }
}
