using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using IListenerInterface;
using System.IO;

namespace WordListener
{
    class WordListener : IListener
    {
        public string Message { get; set; }

        public int Level { get; set; }

       // string path = @"C:\Users\PauliusRuikis\Desktop/WordListener.docx";
       
       // string txt = "new text";

        public WordListener(string message, int level)
        {
            Message = message;
            Level = level;
        }
        public void SendMessage(string filePath, string txt)
        {
            if (!File.Exists(filePath))
            {
                using (WordprocessingDocument wordDocument =
                    WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
                {
                    MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                    mainPart.Document = new Document();
                    Body body = mainPart.Document.AppendChild(new Body());
                    Paragraph para = body.AppendChild(new Paragraph());
                    Run run = para.AppendChild(new Run());
                    run.AppendChild(new Text(txt));
                }
            }
            else
            {
                using (WordprocessingDocument wordprocessingDocument =
                     WordprocessingDocument.Open(filePath, true))
                {
                    Body body = wordprocessingDocument.MainDocumentPart.Document.Body;
                    Paragraph para = body.AppendChild(new Paragraph());
                    Run run = para.AppendChild(new Run());
                    run.AppendChild(new Text(txt));
                  //  wordprocessingDocument.Close();
                }

            }

        }

    }
}
