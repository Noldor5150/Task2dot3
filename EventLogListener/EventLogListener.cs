

using IListenerInterface;

namespace EventLogListener
{
    class EventLogListener : IListener
    {
        public string Message { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void SendMessage(string filePath,string message)
        {
            throw new System.NotImplementedException();
        }
    }
}
