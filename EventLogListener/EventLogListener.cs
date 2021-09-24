

using IListenerInterface;
using System.Diagnostics;

namespace EventLogListener
{
    class EventLogListener : IListener
    {
        private EventLog myLog;
        public int Level { get; private set; }
        public EventLogListener(int level)
        {
            Level = level;
            myLog = new EventLog("Application");
           
        }
        public void SendMessage(string message)
        {
            myLog.WriteEntry(message);
        }
    }
}
