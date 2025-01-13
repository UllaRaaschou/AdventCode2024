using AdventCode2024;
using System.Data;

namespace TestProjectAdvent
{
    [TestClass]
    public class CodeDayTwoTests
    {
        [TestMethod]
        [DataRow("2 4 6 1 5\n 3 6 3 8 5\n 0 4 7 2 8", new int[] {1,2,4,5,6}, new int[] {3,3,5,6,8}, new int[] {0,2,4,7,8})]
        public void Test_ConvertStringsToArraysSortedAsc(string inputString, int[] report1Array, int[]report2Array,
        int[]report3Array)
        {
            //Arrange
            var tempFilePath = Path.GetTempFileName();
            File.WriteAllText(tempFilePath, inputString);
            string reportString = tempFilePath;

            //Act
            int[][] reports = CodeDayTwo.ConvertStringsToArraysSortedAsc(tempFilePath);
            int[] report1 = reports[0];
            int[] report2 = reports[1];
            int[] report3 = reports[2];

            //Assert
            CollectionAssert.AreEqual(report1Array, report1);
            CollectionAssert.AreEqual(report2Array, report2);
            CollectionAssert.AreEqual(report3Array, report3);
        }
    }
}
