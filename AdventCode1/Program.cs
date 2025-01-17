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


        //List<int[]> okLevelDiff= CodeDayTwo
        //                           .ReportsWithOKLevelDifferences(inputArrays);

        //int safeReports1 = CodeDayTwo
        //                    .ReportsWithMaxOneAscOrDescErrorLevel(okLevelDiff);

        //List<int[]> levelDiffRemoved= CodeDayTwo
        //                                .ReportsWithMaxOneRejectedLevelDifferences(inputArrays);

        //int safeReports2 = CodeDayTwo
        //                    .ReportsWithAllLevelsAscOrDesc(levelDiffRemoved);



        //Console.WriteLine($"Total accepted reportsNow: {safeReports1}, {safeReports2}");



    }
}

