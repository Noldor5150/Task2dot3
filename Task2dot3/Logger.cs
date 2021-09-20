
using IListenerInterface;
using System;
using System.Collections.Generic;

namespace Task2dot3
{
    class Logger : IListener
    {
        public string Message { get; set; }
        
        public List<IListener> LoggersList { get; set; }

        public Logger( List<IListener> loggersList)
        {
            LoggersList = loggersList;
        }
        public void SendMessage(string filePath,string message)
        {
            throw new NotImplementedException();
        }
        
    }
}
