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
            var file = "../../test_files/lorem ipsum.pdf";

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
            var ocr = new AdvancedOcr()
            {
                Language = IronOcr.Languages.English.OcrLanguagePack,
                ColorSpace = AdvancedOcr.OcrColorSpace.GrayScale,
                EnhanceResolution = true,
                EnhanceContrast = true,
                CleanBackgroundNoise = true,
                ColorDepth = 4,
                RotateAndStraighten = false,
                DetectWhiteTextOnDarkBackgrounds = false,
                ReadBarCodes = false,
                Strategy = AdvancedOcr.OcrStrategy.Fast,
                InputImageType = AdvancedOcr.InputTypes.Document
            };

            var results = ocr.ReadPdf(@file);
            //Console.WriteLine(results.Text);
            //Console.ReadLine();

            foreach (var page in results.Pages)
            {
                foreach (var paragraph in page.Paragraphs)
                {
                    foreach (var line in paragraph.Lines)
                    {
                        double line_ocr_accuracy = line.Confidence;
                        Console.WriteLine(line_ocr_accuracy);
                        Console.ReadLine();
                    }
                }
            }            
        }
    }
}
