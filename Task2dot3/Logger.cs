
using IListenerInterface;
using System.Collections.Generic;

namespace Task2dot3
{
    class Logger : IListener
    {
        public List<IListener> LoggersList { get; private set; }
        public Logger( List<IListener> loggersList)
        {
            LoggersList = loggersList;
        }
        public void SendMessage(string message)
        {
            foreach (var logger in LoggersList)
            {
                logger.SendMessage(message);
            }
        }
        
    }
}
