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

        //[TestMethod]
        //[DataRow(new int[] { 7, 6, 4, 2, 1 }, 0)]
        //public void OneLevelErrorCanBeAccepted(int[] reportArray,  int counterOfDiffsNOTBetweenOneAndThreeIncl)
        //{
        //    //Act
        //    int result = SecondTryCodeDayTwo.OneDiffErrorCanBeAcccepted(reportArray);

        //    //Assert
            
        //    Assert.AreEqual(counterOfDiffsNOTBetweenOneAndThreeIncl, result);
           
        //}
    }
}
