using System;
using System.Collections.Generic;
using System.IO;

namespace BiGramApplication
{
    public class FileParser
    {
        #region properties        
        public List<biGramCnt> BiGramCntList { get; set; }       
        #endregion properties      

        #region public methods
        public void ParseFile(string input)
        {
            string[] inputArry = input.ToLower().Split(' ');
            string[] biGramArry = new string[inputArry.Length];            
            List<biGramCnt> biGramCntList = new List<biGramCnt>();
            string firstWord, secWord, element;
            int counter, i, j;

            //create bigram array
            for (i = 0; i < inputArry.Length - 1; i++)
            {
                firstWord = inputArry[i];
                secWord = inputArry[i + 1];
                biGramArry[i] = firstWord + (" ") + secWord;
            }

            //create biGramCnt list 
            for (i = 0; i <= biGramArry.Length - 1; i++)
            {
                element = biGramArry[i];
                if (!string.IsNullOrEmpty(element))
                {
                    counter = 0;
                    for (j = 0; j <= biGramArry.Length - 1; j++)
                    {
                        if (element == biGramArry[j])
                        {
                            counter++;
                        }
                    }
                    if (Array.IndexOf(biGramArry, element) == i)
                    {
                        biGramCntList.Add(new biGramCnt { BiGram = element, Count = counter });
                    }
                }
            }
            BiGramCntList = biGramCntList;
        }

        public void WriteFileOut(string filePath)
        {
            StreamWriter file = new System.IO.StreamWriter(filePath);
            string outputStr = "";
         
            foreach (var biGramCnt in BiGramCntList)
            {                
                outputStr += string.Format("\"{0}\" {1}{2}", biGramCnt.BiGram, biGramCnt.Count, Environment.NewLine);
            }            
            
            file.WriteLine(outputStr);
            file.Close();
        }
        #endregion public methods
    }
}
