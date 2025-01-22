using AdventCode2024;
using TestProjectAdvent;
class Program
{
    static void Main()
    {
        // DAY ONE ********

        //(int[]array1, int[]array2) columns = CodeDayOne
        //                                            .ConvertInputColumnsToArraysOrderedAsc(
        //                                            "C:\\Users\\ullar\\source\\repos\\AdventCode2024\\" +
        //                                            "AdventCode1\\Input\\ListsOfData.txt");
        //List<int> distances = CodeDayOne
        //              .FindDistanceBetweenNumbersInEachLine(columns.array1, columns.array2);

        //int totalDistances = CodeDayOne.GetTotalDistances(distances);

        //int[] simularityFactors = CodeDayOne.CalculateSimularityFactors(columns.array1, columns.array2);

        //int simularityProduct = CodeDayOne.CalculateSimularityProduct(simularityFactors);

        //Console.WriteLine($"simularityproduct: {simularityProduct}");


        // DAY TWO ********

        List<int[]> inputArrays = CodeDayTwo
                                  .ConvertStringsToArrays(
                                   "C:\\Users\\ulee\\Source\\Repos\\AdventCode2024\\AdventCode1\\Input\\Reports.txt");
        // *** part ONE ***

        //List<int[]> okLevelDifferncesPartOne = CodeDayTwo
        //                           .ReportsWithOKLevelDifferences(inputArrays);

        //int OkLevelAscOrDescPartOne = CodeDayTwo
        //                           .ReportsWithAllLevelsAscOrDesc(okLevelDifferncesPartOne);


        // *** part TWO ***

        int counter = 0; // Initialize counter variable

        foreach (int[] inputArray in inputArrays)
        {
            (int[] outputArray, bool isSafe) = NewDayTwoCode.PuzzlePartTwo
                
                
                (inputArray);
            if (isSafe)
            {
                counter++;
            }
        }

        Console.WriteLine(counter); // Output the value of counter


    }
}

