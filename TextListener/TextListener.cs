using IListenerInterface;
using System.IO;

namespace TextListener
{
   public class TextListener : IListener
    {
        private const string FILE_PATH = @"C:\Users\PauliusRuikis\Desktop/TextListener2dot3.txt";
        public int Level { get; private  set; }
        public TextListener( int level )
        {
            Level = level;
            if (!File.Exists(FILE_PATH))
            {
                using (StreamWriter sw = File.CreateText(FILE_PATH))
                {

                }
            }
        }

        public void SendMessage(string message)
        {
                using (StreamWriter sw = File.AppendText(FILE_PATH))
                {
                    sw.WriteLine(message);
                }
        }
    }

   
}
