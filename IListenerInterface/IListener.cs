

namespace IListenerInterface
{
    public interface IListener
    {
         public string Message { get; set; }
         public void SendMessage(string filePath,string message);
        
    }

}
