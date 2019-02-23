using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronOcr;

namespace OCR_Prototyping
{
    public class IronOcrClass
    {
        public IronOcrClass()
        {
            var file = "../../test_files/hello.pdf";

            // checks if file exists
            //if (File.Exists(file))
            //{
            //    var fileName = Path.GetFileName(file);
            //    Console.WriteLine("file exists: {0}", fileName);
            //    Console.ReadLine();
            //}
            //else
            //{
            //    var currentPath = Path.GetFullPath(file);
            //    Console.WriteLine("file DNE; looking in: {0}", currentPath);
            //    Console.ReadLine();
            //}

            // reads .txt file
            //string text = File.ReadAllText(file);
            //Console.WriteLine("Contents of test.txt = {0}", text);
            //// `{0}` denotes the value of second argument, `text`
            //Console.ReadLine();

            // reads .pdf file
            var Ocr = new IronOcr.AutoOcr();
            var Results = Ocr.ReadPdf(@file);
            Console.WriteLine(Results.Text);
            Console.ReadLine();
        }
    }
}
