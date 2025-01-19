using AdventCode2024;
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


        (List<int[]>, List<int[]>) acceptedRecords = CodeDayTwo.ReportsWithMaxOneRejectedLevelDifferences(inputArrays);

        List<int[]> notChangedReports = acceptedRecords.Item1;
        List<int[]> changedReports = acceptedRecords.Item2;

        int safeReportsPartOne = (CodeDayTwo.ReportsWithMaxOneAscOrDescErrorLevel(notChangedReports)).Item1;
        int safeReportsPartTwo = CodeDayTwo.ReportsWithAllLevelsAscOrDesc(changedReports);

        Console.WriteLine($"Safe reports: {safeReportsPartOne + safeReportsPartTwo}");



    }
}

