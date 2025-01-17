using AdventCode2024;
using System.Data;

namespace TestProjectAdvent
{
    [TestClass]
    public class CodeDayTwoTests
    {
        [TestMethod]
        [DataRow("2 4 6 1 5\n 3 6 3 8 5\n 0 4 7 2 8", new int[] { 2, 4, 6, 1, 5 }, new int[] { 3, 6, 3, 8, 5 }, new int[] { 0, 4, 7, 2, 8 })]
        [DataRow("2 4 6\n 3 6 3 8 5\n 0 4 7 2 8", new int[] { 2, 4, 6 }, new int[] { 3, 6, 3, 8, 5 }, new int[] { 0, 4, 7, 2, 8 })]
        public void Test_ConvertStringsToArrays(string inputString, int[] report1Array, int[]report2Array,
        int[]report3Array)
        {
            //Arrange
            var tempFilePath = Path.GetTempFileName();
            File.WriteAllText(tempFilePath, inputString);
            
            //Act
            List<int[]> reports = CodeDayTwo.ConvertStringsToArrays(tempFilePath);
            int[] report1 = reports[0];
            int[] report2 = reports[1];
            int[] report3 = reports[2];

            //Assert
            CollectionAssert.AreEqual(report1Array, report1);
            CollectionAssert.AreEqual(report2Array, report2);
            CollectionAssert.AreEqual(report3Array, report3);
        }

        /// <summary>
        /// Eftersom jeg returnerer en collection af arrays i ovenstående metode, som jeg tænkte skulle bruges som parameter i næste metode, 
        /// ville jeg mægtig gerne have indsat en form for collection i nedenstående DataRow. 
        /// 
        //[DataRow(new int[ , ] { new int[] { 2, 4, 6, 1, 5 }, new int[] { 3, 6, 3, 8, 5 }, new int[] { 0, 4, 7, 2, 8 } })]
        /// 
        /// Det LOD til at at en "array creation expression" burde have været ok (CS0182), men i praksis kunne jeg ikke få det til at virke.
        /// </summary>
        [TestMethod]
        public void Test_ReportsWithOKLevelDifferences()  
        {
            // Arrange
            List<int[]> reports = new List<int[]>
            {
                new int[] { 2, 4, 6, 1, 5 },
                new int[] { 3, 6, 3, 12, 5 },
                new int[] { 0, 4, 7, 2, 8 },
                new int[] { 1, 2, 3, 4, 5 },
                new int[] { 3, 6, 3, 4, 7, 8 }, 
                new int[] {11, 8, 7, 4, 11 }
            };

            // Act
            List<int[]> acceptedRecords = CodeDayTwo.ReportsWithOKLevelDifferences(reports);

            // Assert
            CollectionAssert.AreEqual(reports[3], acceptedRecords[0]);
            CollectionAssert.AreEqual(reports[4], acceptedRecords[1]);
           
        }

        [TestMethod]
        public void Test_ReportsWithAllLevelsAscOrDesc
            () 
        {
            // Arrange
            List<int[]> reports = new List<int[]>
            {
                new int[] { 2, 4, 6, 1, 5 },
                new int[] { 3, 6, 3, 12, 5 },
                new int[] { 0, 4, 7, 2, 8 },
                new int[] { 1, 2, 3, 4, 5 },
                new int[] { 3, 6, 3, 4, 7, 8 },
            };

            // Act
            int numberOfAcceptedRecords = CodeDayTwo.ReportsWithAllLevelsAscOrDesc(reports);

            // Assert
            Assert.AreEqual(1, numberOfAcceptedRecords);
        }

        [TestMethod]
        public void Test_ReportsWithMaxOneRejectedLevelDifferences() 
        {
            // Arrange
            List<int[]> reports = new List<int[]>
            {
                new int[] { 2, 4, 6, 1, 5 },
                new int[] { 3, 6, 3, 12, 5 },
                new int[] { 0, 4, 7, 2, 8 },
                new int[] { 1, 2, 3, 4, 5 },
                new int[] { 3, 6, 3, 4, 7, 8 },
                new int[] {11, 8, 7, 4, 11 }
            };

            //Act

            (List<int[]>, List<int[]>) acceptedRecords = CodeDayTwo.ReportsWithMaxOneRejectedLevelDifferences(reports);

            //Assert
            //Assert.AreEqual(reports[0], acceptedRecords.Item2[0]);
            CollectionAssert.AreEqual(reports[1], acceptedRecords.Item2[0]);
            CollectionAssert.AreEqual(reports[2], acceptedRecords.Item2[1]);
            CollectionAssert.AreEqual(reports[3], acceptedRecords.Item1[0]);
            CollectionAssert.AreEqual(reports[4], acceptedRecords.Item1[1]);
            CollectionAssert.AreEqual(reports[5], acceptedRecords.Item2[2]);



        }

        [TestMethod]
        public void Test_ReportsWithMaxOneAscOrDescErrorLevel()
        {
            // Arrange
            List<int[]> reports = new List<int[]>
            {
                new int[] { 2, 4, 6, 1, 5 },
                new int[] { 3, 6, 3, 12, 5 },
                new int[] { 0, 4, 7, 2, 8 },
                new int[] { 1, 2, 3, 4, 5 },
                new int[] { 3, 6, 3, 4, 7, 8 },
                new int[] {11, 8, 7, 4, 11 }
            };

            //Act

            (int count, List<int[]> acceptedRecords) = CodeDayTwo.ReportsWithMaxOneAscOrDescErrorLevel(reports);

            //Assert
            Assert.AreEqual(3, count);
            CollectionAssert.AreEqual(new List<int[]> { reports[2], reports[3], reports[5] }, acceptedRecords);
        }

        //[TestMethod]
        //public void Test_CombiOfNonSortedLevelDiffAndRemovedAscDesc() 
        //{
        //    // Arrange
        //    List<int[]> reports = new List<int[]>
        //    {
        //        new int[] { 7, 6, 4, 2, 1 },
        //        new int[] { 1, 2, 7, 8, 9 },
        //        new int[] { 9, 7, 6, 2, 1 },
        //        new int[] { 1, 3, 2, 4, 5 },
        //        new int[] { 8, 6, 4, 4, 1 },
        //        new int[] {1, 3, 6, 7, 9 }
        //    };

        //    //Act
        //    List<int[]> okLevelDiff = CodeDayTwo
        //                           .ReportsWithOKLevelDifferences(reports);

        //    int safeReports1 = CodeDayTwo
        //                        .ReportsWithMaxOneAscOrDescErrorLevel(okLevelDiff);


        //    //Assert
        //    Assert.AreEqual(3, safeReports1);
        //}

        //[TestMethod]    
        //public void Test_CombiOfRemovedLevelDiffAndNotSortedAscDesc() 
        //{
        //    // Arrange
        //    List<int[]> reports = new List<int[]>
        //    {
        //        new int[] { 7, 6, 4, 2, 1 },
        //        new int[] { 1, 2, 7, 8, 9 },
        //        new int[] { 9, 7, 6, 2, 1 },
        //        new int[] { 1, 3, 2, 4, 5 },
        //        new int[] { 8, 6, 4, 4, 1 },
        //        new int[] {1, 3, 6, 7, 9 }
        //    };

        //    //Act

        //    List<int[]> levelDiffRemoved = CodeDayTwo
        //                                     .ReportsWithMaxOneRejectedLevelDifferences(reports);

        //    int safeReports2 = CodeDayTwo
        //                        .ReportsWithAllLevelsAscOrDesc(levelDiffRemoved);

        //    //Assert
        //    Assert.AreEqual(4, safeReports2);

        //}

    }
}
