using AdventCode1;

namespace TestProjectAdvent
{
    [TestClass]
    public class CodeDayOneTest
    {
        
        [TestMethod]
        [DataRow("1   2\n3   4\n5   6", 1, 2, 3, 3 ) ]
        [DataRow("3   4\n1   9\n7   2", 1, 2, 3, 3 ) ]
        [DataRow("30   4\n1   9\n7   2", 1, 2, 3, 3) ]
        [DataRow("-3   4\n1   9\n7   2", -3, 2, 3, 3)]

        //[DataRow()]
        public void Test_ConvertInputColumnsToArraysOrderedAsc(string dataRow, int smallestValue0, int smallestValue1, int column0Count, 
            int column1Count)
        {
            // Arrange
            var tempFilePath = Path.GetTempFileName();
            File.WriteAllText(tempFilePath, dataRow);

            //Act
            (int[], int[]) valuesFromAllColumns = CodeDayOne.ConvertInputColumnsToArraysOrderedAsc(tempFilePath);
            int[] valuesFromColumn0 = valuesFromAllColumns.Item1;
            int[] valuesFromColumn1 = valuesFromAllColumns.Item2;

            //Assert
            Assert.AreEqual(column0Count, valuesFromColumn0.Count());
            Assert.AreEqual(column1Count, valuesFromColumn1.Count());
            Assert.AreEqual(smallestValue0, valuesFromColumn0[0]);
            Assert.AreEqual(smallestValue1, valuesFromColumn1[0]);
            
        }

        [TestMethod]
        [DataRow(new int[] { 1, 3, 5 }, new int[] { 2, 6, 6 }, 1,3,1)]
        public void Test_FindDistanceBetweenNumbersInEachLine(int[] array1, int[] array2, int expectedDistancesIndex0, 
            int expectedDistancesIndex1, int expectedDistancesIndex2)
        {
            //Arrange           
            int[] valuesFromColumn0 = [1, 3, 5];
            int[] valuesFromColumn1 = [2, 6, 6];

            //Act
            List<int> distances = CodeDayOne.FindDistanceBetweenNumbersInEachLine(valuesFromColumn0, valuesFromColumn1);

            //Assert
            Assert.AreEqual(expectedDistancesIndex0, distances[0]);
            Assert.AreEqual(expectedDistancesIndex1, distances[1]);
            Assert.AreEqual(expectedDistancesIndex2, distances[2]);
        }

        [TestMethod]
        public void Test_GetTotalDistances()
        {
            //Arrange
            List<int> distances = [1,3,5];

            //Act
            int totalDistance = CodeDayOne.GetTotalDistances(distances);

            //Assert
            Assert.AreEqual(9, totalDistance);
        }

        [TestMethod]
        [DataRow(new int[] {2,4,4,6,7}, new int[] {2,2,2,6,6}, 2,3,4,0,6,2,7,0)]
        [DataRow(new int[] {2, 20, 339, 556, 556 }, new int[] {20, 20, 339, 556, 556}, 2, 0, 20, 2, 339, 1, 556, 2 )]
        public void Test_CalculateSimularityFactors(int[] arrayInput1, int[] arrayInput2, int multipl_1_Factor1, int multipl_1_Factor2,
            int multipl_2_Factor1, int multipl_2_Factor2, int multipl_3_Factor1, int multipl_3_Factor2, int multipl_4_Factor1, int multipl_4_Factor2)
        {
            //Arrange
            int[] array1 = arrayInput1;
            int[] array2 = arrayInput2;

            //Act
            int[] numbersForCalculation = CodeDayOne.CalculateSimularityFactors(array1, array2);

            //Assert
            Assert.AreEqual(multipl_1_Factor1, numbersForCalculation[0]);
            Assert.AreEqual(multipl_1_Factor2, numbersForCalculation[1]);
            Assert.AreEqual(multipl_2_Factor1, numbersForCalculation[2]);
            Assert.AreEqual(multipl_2_Factor2, numbersForCalculation[3]);
            Assert.AreEqual(multipl_3_Factor1, numbersForCalculation[4]);
            Assert.AreEqual(multipl_3_Factor2, numbersForCalculation[5]);
            Assert.AreEqual(multipl_4_Factor1, numbersForCalculation[6]);
            Assert.AreEqual(multipl_4_Factor2, numbersForCalculation[7]);
        }

        [TestMethod]
        [DataRow(new int[] { 2, 3, 4, 0, 6, 6, 7, 0}, 42 )]
        [DataRow(new int[] { 2, 0, 20, 2, 339, 1, 556, 2 }, 1491)]
        public void Test_CalculateSimularityProduct(int[] testFactorsForSimularityCalculation, int expectedProduct) 
        {
            //Arrange
            int[] factorsForSimularityCalculation = testFactorsForSimularityCalculation;

            //Act
            int product = CodeDayOne.CalculateSimularityProduct(factorsForSimularityCalculation);

            //Assert 
            Assert.AreEqual(expectedProduct, product);
        }

    }


}