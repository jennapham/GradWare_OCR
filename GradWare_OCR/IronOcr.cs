using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using IronOcr;

namespace OCR_Prototyping
{
    public class IronOcrClass
    {
        public IronOcrClass()
        {
            // file location
            var file = "../../test_files/lorem ipsum.pdf";

            // initializes list to be serialized into JSON
            var OutputList = new List<Result>();
            
            // reads .txt file
            //string text = File.ReadAllText(file);
            //Console.WriteLine("Contents of test.txt = {0}", text);
            //// `{0}` denotes the value of second argument, `text`
            //Console.ReadLine();

            // reads .pdf file
            var OCR = new AdvancedOcr()
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

            var Result = OCR.ReadPdf(@file);
            var ResultText = Result.Text;
            //Console.WriteLine("Entire Result: {0}\n", resultText);

            foreach (var page in Result.Pages)
            {
                foreach (var paragraph in page.Paragraphs)
                {
                    var paragraphText = paragraph.Text;
                    //Console.WriteLine("Result Paragraph: {0}", paragraphText);

                    double paragraphConfidence = Math.Round(paragraph.Confidence, 2);
                    //Console.WriteLine("Confidence score per paragraph: {0}\n", paragraphConfidence);

                    // add values to list
                    OutputList.Add(new Result() { Text = paragraphText, Confidence = paragraphConfidence });

                    //foreach (var line in paragraph.Lines)
                    //{
                    //    double lineConfidence = line.Confidence;
                    //    Console.WriteLine("Confidence score per line: {0}", lineConfidence);
                    //}
                }
            }
            var serializer = new JavaScriptSerializer();
            var serializedOutputList = serializer.Serialize(OutputList);

            Console.WriteLine(serializedOutputList);
            Console.ReadLine();
        }
    }
}
