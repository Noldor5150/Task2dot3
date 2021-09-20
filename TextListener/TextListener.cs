using IListenerInterface;
using System.IO;

namespace TextListener
{
   public class TextListener : IListener
    {
        public string Message { get; set; }
        public int Level { get; set; }
        public TextListener()
        {

        }
        public TextListener(string message, int level)
        {
            Message = message;
            Level = level;
        }

        // string path = @"C:\Users\PauliusRuikis\Desktop/TextListener.txt";
        // string txt = "new text";
        public void SendMessage(string filePath, string message)
        {
            if (!File.Exists(filePath))
            {
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    sw.WriteLine(message);

                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filePath))
                {
                    sw.WriteLine(message);
                }
            }

        }
    }

   
}
