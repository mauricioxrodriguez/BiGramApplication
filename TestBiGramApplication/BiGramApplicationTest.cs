using Microsoft.VisualStudio.TestTools.UnitTesting;
using BiGramApplication;
using System.Collections.Generic;

namespace TestBiGramApplication
{
    [TestClass]
    public class BiGramApplicationTest
    {
        [TestMethod]
        public void ShouldParseFileBiGramString()
        {
            //Arrange
            FileParser fileParser = new FileParser();
            string inputStr = "The quick brown fox and the quick blue hare.";
            List<biGramCnt> biGramCntList = new List<biGramCnt>();
            biGramCntList.Add(new biGramCnt { BiGram = "the quick", Count = 2 });
            biGramCntList.Add(new biGramCnt { BiGram = "quick brown", Count = 1 });
            biGramCntList.Add(new biGramCnt { BiGram = "brown fox", Count = 1 });
            biGramCntList.Add(new biGramCnt { BiGram = "fox and", Count = 1 });
            biGramCntList.Add(new biGramCnt { BiGram = "and the", Count = 1 });
            biGramCntList.Add(new biGramCnt { BiGram = "quick blue", Count = 1 });
            biGramCntList.Add(new biGramCnt { BiGram = "blue hare.", Count = 1 });

            //Act
            fileParser.ParseFile(inputStr);

            //Assert
            Assert.AreEqual(biGramCntList.Count, fileParser.BiGramCntList.Count);
            Assert.AreEqual(biGramCntList[0].BiGram, fileParser.BiGramCntList[0].BiGram);
            Assert.AreEqual(biGramCntList[0].Count, fileParser.BiGramCntList[0].Count);
            Assert.AreEqual(biGramCntList[1].BiGram, fileParser.BiGramCntList[1].BiGram);
            Assert.AreEqual(biGramCntList[1].Count, fileParser.BiGramCntList[1].Count);
            Assert.AreEqual(biGramCntList[2].BiGram, fileParser.BiGramCntList[2].BiGram);
            Assert.AreEqual(biGramCntList[2].Count, fileParser.BiGramCntList[2].Count);
            Assert.AreEqual(biGramCntList[3].BiGram, fileParser.BiGramCntList[3].BiGram);
            Assert.AreEqual(biGramCntList[3].Count, fileParser.BiGramCntList[3].Count);
            Assert.AreEqual(biGramCntList[4].BiGram, fileParser.BiGramCntList[4].BiGram);
            Assert.AreEqual(biGramCntList[4].Count, fileParser.BiGramCntList[4].Count);
            Assert.AreEqual(biGramCntList[5].BiGram, fileParser.BiGramCntList[5].BiGram);
            Assert.AreEqual(biGramCntList[5].Count, fileParser.BiGramCntList[5].Count);
            Assert.AreEqual(biGramCntList[6].BiGram, fileParser.BiGramCntList[6].BiGram);
            Assert.AreEqual(biGramCntList[6].Count, fileParser.BiGramCntList[6].Count);
        }
    }
}
