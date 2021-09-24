

namespace Task2dot3
{
    class Program
    {
        static void Main(string[] args)
        {
            
            const string JSON_FILE_PATH = @"C:\Users\PauliusRuikis\Desktop/appsettings.json";
            const string DLL_FILE_PATH = @"C:\Users\PauliusRuikis\source\repos\Task2dot3\";
            var listeners = JSONReader.GetListenersFromConfigJson(JSON_FILE_PATH, DLL_FILE_PATH);
            Logger logger = new Logger(listeners);
            logger.SendMessage("hello");
        }
    }
}
