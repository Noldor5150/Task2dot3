


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
        public static List <IListener> GetListenersFromConfigJson(string jsonPath, string dllPath)
        {
            var json = File.ReadAllText(jsonPath);
            var rawData = JObject.Parse(json);
            var WindowsList = rawData["WindowsList"];

            List<IListener> list = new List<IListener>();
            foreach (var token in WindowsList)
            {
                list.Add(Create(dllPath, (string)token["title"], (int)token["level"]));
            }
            return list;
        }
        public static  IListener Create(string path, string listenerName, int listenerParamInt)
        {
            Assembly assembly = Assembly.LoadFrom($@"{path}{listenerName}\bin\Debug\net5.0\{listenerName}.dll");
            Type[] types = assembly.GetTypes();
            Type type = Array.Find(types, type => type.Name == listenerName);
            ConstructorInfo constructor = type.GetConstructor(new Type[] { typeof(int) });
            return constructor.Invoke(new object[] { listenerParamInt }) as IListener;
        }

    }
}
