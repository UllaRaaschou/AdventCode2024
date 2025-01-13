using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode1
{
    public static class CodeDayOne
    {
        public static (int[]firstColumn, int[]secondColumn) ConvertInputColumnsToArraysOrderedAsc(string filePath)
        {
            string[] allColumnValues = File.ReadAllLines(filePath);
            int[] firstColumn = allColumnValues
                                    .Where(line => !string.IsNullOrWhiteSpace(line))
                                    .Select(line => int.Parse(line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0]))
                                    .OrderBy(num => num)
                                    .ToArray();
            int[]secondColumn = allColumnValues
                                    .Where(line => !string.IsNullOrWhiteSpace(line))
                                    .Select(line => int.Parse(line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1]))
                                    .OrderBy(num => num)
                                    .ToArray();
            return (firstColumn, secondColumn);
        }

        public static List<int> FindDistanceBetweenNumbersInEachLine(int[]firstColumn, int[]secondColumn)
        {
            if (firstColumn.Any() && secondColumn.Any())
            {
                List<int> distances = new List<int>();
                for (int i = 0; i < firstColumn.Length; i++)
                {
                    var d = Math.Abs(firstColumn[i] - secondColumn[i]);
                    distances.Add(d);
                }
                return distances;
            }
            Console.WriteLine("Error: Empty column(s)");
            return new List<int>();
        }
       
        public static int GetTotalDistances(List<int> distances)
        {
            int result = 0;
            foreach (int distance in distances)
            {
                result += distance;
            }
            return result;
        }

        public static int[] CalculateSimularityFactors(int[] array1, int[] array2)
        {
            List<int> factorList = new List<int>();
            for (int i = 0; i < array1.Length; i++)
            {
                int factor = array1[i];

                if (i > 0 && factor == array1[i - 1])
                {
                    continue;
                }

                factorList.Add(factor);
                int duplicationCount = 0;
                foreach (int array2Number in array2)
                {
                    if (array2Number == factor)
                    {
                        duplicationCount++;
                    }
                }
                factorList.Add(duplicationCount);
            }
            return factorList.ToArray();
        }

        public static int CalculateSimularityProduct(int[] factorsForSimularityCalculation)
        {
            int product = 0;
            for (int i = 0; i < factorsForSimularityCalculation.Length; i++)
            {
                int partialProduct = factorsForSimularityCalculation[i] * factorsForSimularityCalculation[i + 1];
                product += partialProduct;
                i = i + 1;
            }
            return product;
        }
    }
}
