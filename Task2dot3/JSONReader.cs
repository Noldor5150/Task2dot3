


using IListenerInterface;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Task2dot3
{
   public static class JSONReader
    {
        

        private const string DLL_FILE_PATH = @"C:\Users\PauliusRuikis\source\repos\Task2dot3\";

        public static List <IListener> GetListenersFormConfigJson(string jsonPath)
        {
            var json = File.ReadAllText(jsonPath);
            var rawData = JObject.Parse(json);
            var WindowsList = rawData["WindowsList"];

            List<IListener> list = new List<IListener>();
            foreach (var token in WindowsList)
            {
                list.Add(Create(DLL_FILE_PATH, (string)token["title"], (string)token["message"], (int)token["level"]));

            }
            return list;
        }
        public static  IListener Create(string path, string listenerName, string listenerParamString, int listenerParamInt)
        {
            Assembly assembly = Assembly.LoadFrom($@"{path}{listenerName}\bin\Debug\net5.0\{listenerName}.dll");
            Type[] types = assembly.GetTypes();
            Type type = Array.Find(types, type => type.Name == listenerName);
            ConstructorInfo constructor = type.GetConstructor(new Type[] { typeof(string), typeof(int) });
            return constructor.Invoke(new object[] { listenerParamString, listenerParamInt }) as IListener;
        }

    }
}
