using AdventCode2024;

namespace TestProjectAdvent
{
    [TestClass]
    public class SecondTryCodeDayTwoTests
    {
        [TestMethod]
        //[DataRow(new int[] { 7, 6, 4, 2, 1 }, 0)]
        //[DataRow(new int[] { 1, 2, 7, 8, 9 }, 1)]
        [DataRow(new int[] { 8, 6, 4, 4, 1 }, 1)]
        public void Test_CounterOfdiffsBetweenOneAndThreeIncl(int[] reportArray, int expectedCounter)
        {
            //Act
            int counter = SecondTryCodeDayTwo.CounterOfdiffsBetweenOneAndThreeIncl(reportArray);

            //Assert
            Assert.AreEqual(expectedCounter, counter);
        }

        [TestMethod]
        //[DataRow(new int[] { 0, 6, 4, 2, 1 }, new int[] { 6, 4, 2, 1 })]
        //[DataRow(new int[] { 8, 6, 1, 4, 1 }, new int[] { 8, 6, 4, 1 })]
        [DataRow(new int[] { 8, 6, 4, 4, 1 }, new int[] { 8, 6, 4, 1 })]
        public void Test_DeleteOneLevelDiffError(int[] reportArray, int[] expRefactoredArray)
        {
            //Act
            int[] refactoredArray = SecondTryCodeDayTwo.DeleteOneLevelDiffError(reportArray);

            //Assert
            CollectionAssert.AreEqual(expRefactoredArray, refactoredArray);
        }

        //[TestMethod]
        //[DataRow(new int[] { 7, 6, 4, 2, 1 }, 0)]
        //[DataRow(new int[] { 1, 2, 7, 8, 9 }, 0)]
        //[DataRow(new int[] { 8, 6, 1, 4, 1 }, 1)]
        //public void Test_CounterOfDiffsNotfollowingAscDescPattern(int[] reportArray, int expectedCounter)
        //{
        //    //Act
        //    int counter = SecondTryCodeDayTwo.CounterOfDiffsNotfollowingAscDescPattern(reportArray);

        //    //Assert
        //    Assert.AreEqual(expectedCounter, counter);
        //}

        [TestMethod]
        [DataRow(new int[] { 7, 6, 4, 2, 1 }, true)]
        [DataRow(new int[] { 1, 2, 7, 3, 9 }, false)]
        [DataRow(new int[] { 8, 6, 1, 4, 1 }, false)]
        public void Test_AllReportIsAscOrDesc(int[] reportArray, bool expectedAllDescOrAllAsc)
        {
            //Act
            bool allDescOrAllAsc = SecondTryCodeDayTwo.AllReportIsAscOrDesc(reportArray);

            //Assert
            Assert.AreEqual(expectedAllDescOrAllAsc, allDescOrAllAsc);
        }

        [TestMethod]
        //[DataRow(new int[] { 1, 6, 4, 2, 1 }, new int[] { 6, 4, 2, 1 })]
        //[DataRow(new int[] { 8, 6, 1, 4, 1 }, new int[] { 8, 6, 4, 1 })]
        [DataRow(new int[] { 10, 11, 13, 16, 15 }, new int[] { 10, 11, 13, 15 })]
        public void Test_DeleteOneAscDescError(int[] reportArray, int[] expRefactoredArray)
        {
            //Act
            int[] refactoredArray = SecondTryCodeDayTwo.DeleteOneAscDescError(reportArray);
            //Assert
            CollectionAssert.AreEqual(expRefactoredArray, refactoredArray);
        }

        

        [TestMethod]
        [DataRow(new int[] { 0, 6, 4, 2, 1 }, new int[] { 6, 4, 2, 1 }, true)]
        [DataRow(new int[] { 8, 6, 1, 4, 1 }, new int[] { 8, 6, 4, 1 }, true)]
        [DataRow(new int[] { 8, 6, 1, 9, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, null, false)]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, false)]
        public void Test_ArrayPassingLevelDiffControl(int[] inputArray, int[] expectedArray, bool oneLevelIsDeleted)
        {
            //Act
            (int[]?, bool?) result = SecondTryCodeDayTwo.ArrayPassingLevelDiffControl(inputArray);

            //Assert
            CollectionAssert.AreEqual(expectedArray, result.Item1);
            Assert.AreEqual(oneLevelIsDeleted, result.Item2);
        }

        [TestMethod]
        [DataRow(new int[] { 1, 2, 3, 4, 5 }, true, true)]
        [DataRow(new int[] { 1, 2, 3, 4, 4 }, false, true)]
        [DataRow(new int[] { 1, 2, 3, 4, 4 }, true, false)]
        public void Test_PassingAscDescControlGivesFinalResult(int[] inputArray, bool oneLevelIsDeleted, bool expectedFinalResult)
        {
            //Act
            bool reportIsSAFE = SecondTryCodeDayTwo.PassingAscDescControlGivesFinalResult(inputArray, oneLevelIsDeleted);

            //Assert
            Assert.AreEqual(expectedFinalResult, reportIsSAFE);
        }

        [TestMethod]
        [DataRow(new int[] { 1, 2, 3, 4, 5 }, true)]
        [DataRow(new int[] { 8, 6, 1, 4, 1 }, true)]
        [DataRow(new int[] { 8, 13, 1, 2, 1 }, false)]
        public void Test_PassingLevelDiffAndAscDescControl(int[] inputArray, bool expectedSafeStatus)
        {
            //Act
            bool finalReportIsSAFE = SecondTryCodeDayTwo.PassingLevelDiffAndAscDescControl(inputArray);

            //Assert
            Assert.AreEqual(expectedSafeStatus, finalReportIsSAFE);
        }


        [TestMethod]
        [DataRow(new int[] { 7, 6, 4, 2, 1 }, 1)]
        [DataRow(new int[] { 1, 2, 7, 8, 9 }, 0)]
        [DataRow(new int[] { 9, 7, 6, 2, 1 }, 0)]
        [DataRow(new int[] { 1, 3, 2, 4, 5 }, 1)]
        [DataRow(new int[] { 8, 6, 4, 4, 1 }, 1)]
        [DataRow(new int[] { 1, 3, 6, 7, 9 }, 1)]

        public void PuzzleTest(int[] inputArray1,  int expectedResult) 
        {
            //Arrange
            List<int[]> recordsArrayList = new List<int[]>();
            recordsArrayList.Add(inputArray1);
           

            //Act
            int result = SecondTryCodeDayTwo.Puzzle(recordsArrayList);  

            //Assert
            Assert.AreEqual(expectedResult, result);
        }




        [TestMethod]
        public void PuzzleTestWithListOfArrays()
        {
            //Arrange
            List<int[]> recordsArrayList = new List<int[]>();
            recordsArrayList.Add(new int[] { 7, 6, 4, 2, 1 });
            recordsArrayList.Add(new int[] { 1, 2, 7, 8, 9 });
            recordsArrayList.Add(new int[] { 9, 7, 6, 2, 1 });
            recordsArrayList.Add(new int[] { 1, 3, 2, 4, 5 });
            recordsArrayList.Add(new int[] { 8, 6, 4, 4, 1 });
            recordsArrayList.Add(new int[] { 1, 3, 6, 7, 9 });
           

            //Act
            int result = SecondTryCodeDayTwo.Puzzle(recordsArrayList);

            //Assert
            Assert.AreEqual(4, result);
        }


    }
}
