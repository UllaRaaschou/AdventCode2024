using AdventCode2024;

namespace TestProjectAdvent
{
    [TestClass]
    public class SecondTryCodeDayTwoTests
    {
        [TestMethod]
        [DataRow(new int[] { 7, 6, 4, 2, 1 }, 0)]
        [DataRow(new int[] { 1, 2, 7, 8, 9 }, 1)]
        public void Test_CounterOfdiffsBetweenOneAndThreeIncl(int[] reportArray, int expectedCounter)
        {
            //Act
            int counter = SecondTryCodeDayTwo.CounterOfdiffsBetweenOneAndThreeIncl(reportArray);

            //Assert
            Assert.AreEqual( expectedCounter, counter);
        }



        [TestMethod]
        [DataRow(new int[] { 7, 6, 4, 2, 1 }, 0)]
        [DataRow(new int[] { 1, 2, 7, 8, 9 }, 0)]
        [DataRow(new int[] { 8, 6, 1, 4, 1 }, 1)]
        public void Test_CounterOfDiffsNotfollowingAscDescPattern(int[] reportArray, int expectedCounter)
        {
            //Act
            int counter = SecondTryCodeDayTwo.CounterOfDiffsNotfollowingAscDescPattern(reportArray);

            //Assert
            Assert.AreEqual(expectedCounter, counter);
        }



        [TestMethod]
        [DataRow(new int[] { 1, 6, 4, 2, 1 }, new int[] {6, 4, 2, 1})]
        [DataRow(new int[] { 8, 6, 1, 4, 1 }, new int[] {8, 6, 4, 1})]
        public void Test_DeleteOneAscDescError(int[] reportArray, int[] expRefactoredArray)
        {
            //Act
            int[] refactoredArray = SecondTryCodeDayTwo.DeleteOneAscDescError(reportArray);
            //Assert
            CollectionAssert.AreEqual(expRefactoredArray, refactoredArray);
        }

        [TestMethod]
        //[DataRow(new int[] { 0, 6, 4, 2, 1 }, new int[] { 6, 4, 2, 1 })]
        [DataRow(new int[] { 8, 6, 1, 4, 1 }, new int[] { 8, 6, 4, 1 })]


        public void Test_DeleteOneLevelDiffError(int[] reportArray, int[] expRefactoredArray)
        {
            //Act
            int[] refactoredArray = SecondTryCodeDayTwo.DeleteOneLevelDiffError(reportArray);

            //Assert
            CollectionAssert.AreEqual(expRefactoredArray, refactoredArray);
        }


    }
}
