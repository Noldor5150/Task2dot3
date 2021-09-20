

namespace Task2dot3
{
    class Program
    {
        static void Main(string[] args)
        {
            
            const string JSON_FILE_PATH = @"C:\Users\PauliusRuikis\Desktop/appsettings.json";
            var listeners = JSONReader.GetListenersFormConfigJson(JSON_FILE_PATH);
            Logger logger = new Logger(listeners);

        }
    }
}
