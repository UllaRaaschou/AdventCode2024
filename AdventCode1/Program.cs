using AdventCode1;
class Program
{
    static void Main()
    {
        (int[]array1, int[]array2) columns = CodeDayOne
                                                    .ConvertInputColumnsToArraysOrderedAsc(
                                                    "C:\\Users\\ullar\\source\\repos\\AdventCode1\\" +
                                                    "AdventCode1\\Input\\ListsOfData.txt");
        List<int> distances = CodeDayOne
                      .FindDistanceBetweenNumbersInEachLine(columns.array1, columns.array2);

        int totalDistances = CodeDayOne.GetTotalDistances(distances);

        int[] simularityFactors = CodeDayOne.CalculateSimularityFactors(columns.array1, columns.array2);

        int simularityProduct = CodeDayOne.CalculateSimularityProduct(simularityFactors);

        Console.WriteLine($"simularityproduct: {simularityProduct}");



    }
}

