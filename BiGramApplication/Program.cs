using System;
using System.Text;
using System.IO;

namespace BiGramApplication
{
    class Program
    {
        private const string acceptedFileExtension = "txt";
        static void Main(string[] args)
        {
            Console.WriteLine("Please emter the input text file full path:");
            string inputFile = Console.ReadLine();
            Console.WriteLine("Please emter a valid output file path:");
            string outputFile = Console.ReadLine();           

            try
            {                
                string inputStr = ReadAllText(inputFile, outputFile);
                ValidateOutputFile(outputFile);
                FileParser parser = new FileParser();
                parser.ParseFile(inputStr);
                parser.WriteFileOut(outputFile);
                Console.WriteLine(string.Format("Successfully created output file: {0}", outputFile));
            }
            catch ( Exception ex )
            {
                Console.WriteLine(ex.Message); 
            }
            
            Console.ReadLine();
        }

        static string ReadAllText(string inputfile, string outputFile)
        {
            string inputStr = "", fileExtension;
            try
            {
                fileExtension = Path.GetExtension(inputfile).Replace(".", "");

                if (fileExtension != acceptedFileExtension)
                {
                    throw new InvalidFileTypeException(inputfile, acceptedFileExtension);
                }

                if (inputfile == outputFile)
                {
                    throw new Exception(string.Format("Input file {0} cannot be the same as output file {1}", inputfile, outputFile));
                }

                inputStr = File.ReadAllText(inputfile, Encoding.UTF8);
            }
            catch (DirectoryNotFoundException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }

            return inputStr;
        }
        static void ValidateOutputFile(string outputFile)
        {            
            string fileExtension = Path.GetExtension(outputFile).Replace(".", "");
            string filePath = Path.GetDirectoryName(outputFile);
            DirectoryInfo dir = new DirectoryInfo(filePath);

            if (outputFile == null || outputFile.Length == 0)
            {
                throw new Exception("Output file cannot be null or empty string.");
            }

            if (fileExtension != acceptedFileExtension)
            {
                throw new InvalidFileTypeException(outputFile, acceptedFileExtension);
            }
            
            if (!dir.Exists)
            {
                throw new Exception(string.Format("Output file path {0} does not exist.", filePath));
            }            
        }
    }
}
