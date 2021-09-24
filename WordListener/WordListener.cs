
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using IListenerInterface;
using System.IO;

namespace WordListener
{
    class WordListener : IListener
    {

        private const string WORD_FILE_PATH = @"C:\Users\PauliusRuikis\Desktop/WordListener2dot3.docx";
        public int Level { get; private set; }

        public WordListener( int level )
        {
            Level = level;
           if (!File.Exists(WORD_FILE_PATH))
            {
                using (WordprocessingDocument wordDocument =
                WordprocessingDocument.Create(WORD_FILE_PATH, WordprocessingDocumentType.Document))
                {
                    MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                    mainPart.Document = new Document();
                    Body body = mainPart.Document.AppendChild(new Body());
                    Paragraph para = body.AppendChild(new Paragraph());
                    Run run = para.AppendChild(new Run());
                    run.AppendChild(new Text("Create text in body - CreateWordprocessingDocument"));

                }
            }
        }
        public void SendMessage( string message )
        {
                using (WordprocessingDocument wordprocessingDocument =
                     WordprocessingDocument.Open(WORD_FILE_PATH, true))
                {
                    Body body = wordprocessingDocument.MainDocumentPart.Document.Body;
                    Paragraph para = body.AppendChild(new Paragraph());
                    Run run = para.AppendChild(new Run());
                    run.AppendChild(new Text(message));
                    wordprocessingDocument.Close();
                }
        }
        
    }
}
