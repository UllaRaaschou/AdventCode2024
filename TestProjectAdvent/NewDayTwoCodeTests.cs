namespace TestProjectAdvent
{
    [TestClass]
    public class NewDayTwoCodeTests
    {
        [TestMethod]
        [DataRow(new int[] { 7, 6, 4, 2, 1 }, new int[] { 7, 6, 4, 2, 1 }, true)]
        [DataRow(new int[] { 1, 2, 7, 8, 9 }, new int[0], false)]
        [DataRow(new int[] { 9, 7, 6, 2, 1 }, new int[0], false)]
        [DataRow(new int[] { 1, 3, 2, 4, 5 }, new int[0] , false)]
        [DataRow(new int[] { 8, 6, 4, 4, 1 }, new int[0], false)]
        [DataRow(new int[] { 1, 3, 6, 7, 9 }, new int[] { 1, 3, 6, 7, 9 }, true)]
        public void Test_PuzzlePartOne(int[] inputArray, int[] expectedOutputArray, bool expectedIsSafe) 
        {
            //Act
            (int[] outputArray, bool isSafe) = NewDayTwoCode.PuzzlePartOne(inputArray);

            //Assert
            CollectionAssert.AreEqual(expectedOutputArray, outputArray);
            Assert.AreEqual(expectedIsSafe, isSafe);
        }



        [TestMethod]
        [DataRow(new int[] { 7, 6, 4, 2, 1 }, new int[] { 7, 6, 4, 2, 1 }, true)]
        [DataRow(new int[] { 1, 2, 7, 8, 9 }, new int[0], false)]
        [DataRow(new int[] { 9, 7, 6, 2, 1 }, new int[0], false)]
        [DataRow(new int[] { 1, 3, 2, 4, 5 }, new int[] { 1, 2, 4, 5 }, true)]
        [DataRow(new int[] { 8, 6, 4, 4, 1 }, new int[] { 8, 6, 4, 1 }, true)]
        [DataRow(new int[] { 1, 3, 6, 7, 9 }, new int[] { 1, 3, 6, 7, 9 }, true)]
        public void Test_PuzzlePartTwo(int[] inputArray, int[] expectedOutputArray, bool expectedIsSafe)
        {
            //Act
            (int[] outputArray, bool isSafe) = NewDayTwoCode.PuzzlePartTwo(inputArray);

            //Assert
            CollectionAssert.AreEqual(expectedOutputArray, outputArray);
            Assert.AreEqual(expectedIsSafe, isSafe);
        }






    }
}
