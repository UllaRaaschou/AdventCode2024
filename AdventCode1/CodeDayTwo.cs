using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode2024
{
    public class CodeDayTwo
    {
        public static int[][] ConvertStringsToArraysSortedAsc(string filePath)
        {
            string[] allRecordStrings = File.ReadAllLines(filePath);

            List<int[]> reportList = new List<int[]>();
           foreach (string line in allRecordStrings) 
            {
                if(!string.IsNullOrWhiteSpace(line)) 
                {
                int[] reportArray = line.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                                    .Where(part => part.All(char.IsDigit))
                                    .Select(int.Parse)
                                    .OrderBy(num => num)
                                    .ToArray();
                    reportList.Add(reportArray);
            }
            return reportList.ToArray();
        }
    }
}
