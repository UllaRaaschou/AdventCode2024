using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCode2024
{
    public class CodeDayTwo
    {
        public static List<int[]> ConvertStringsToArrays(string filePath)
        {
            string[] allRecordStrings = File.ReadAllLines(filePath);
            List<int[]> reportList = new List<int[]>();

            foreach (string line in allRecordStrings)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    int[] reportArray = line.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                                        .Where(part => part.All(char.IsDigit))
                                        .Select(int.Parse)
                                        .ToArray();
                    reportList.Add(reportArray);
                }
            }
            return reportList;
        }

        public static List<int[]> ReportsWithOKLevelDifferences(List<int[]> reports)
        {
            int counterOfAcceptedReports = 0;
            List<int[]> acceptedReports = new List<int[]>();

            foreach (int[] report in reports)
            {
                IEnumerable<int> levelDifferences = report.Zip(report.Skip(1), (a, b) => Math.Abs(a - b));
                bool IsReportDifferencesAccepted = levelDifferences.All(difference => difference >= 1 && difference <= 3);
                if (IsReportDifferencesAccepted)
                {
                    acceptedReports.Add(report);
                    counterOfAcceptedReports++;
                }
                else
                {
                    Console.WriteLine($"Reports rejected becaurse of level differences: {string.Join(" ", report)}");
                }
            }

            return acceptedReports;
        }

        public static int ReportsWithAllLevelsAscOrDesc(List<int[]> reports)
        {
            int counterOfAcceptedReports = 0;

            foreach (int[] report in reports)
            {
                bool allAsc = report.Zip(report.Skip(1), (a, b) => (a < b)).All(pair => pair);
                bool allDesc = report.Zip(report.Skip(1), (a, b) => (a > b)).All(pair => pair);

                if (allAsc || allDesc)
                {
                    counterOfAcceptedReports++;
                }
                else
                {
                    Console.WriteLine($"Reports rejected becaurse of not all ascending or descending: {string.Join(" ", report)}");
                }
            }
            Console.WriteLine($"Reports accepted: {counterOfAcceptedReports}");        
            return counterOfAcceptedReports;
        }

        public static List<int[]> ReportsWithMaxOneRejectedLevelDifferences(List<int[]> reports)
        {
            List<int[]> acceptedReports = new List<int[]>();

            foreach (int[] reportArray in reports)
            {
                List<int> report = reportArray.ToList();
                List<int> differences = report.Zip(report.Skip(1), (a, b) => Math.Abs(a - b)).ToList();
                bool allDifferencesAccepted = true;

                foreach (int diff in differences)
                {
                    if (diff > 3)
                    {
                        int index = differences.IndexOf(diff);
                        int reportItem = report[index];
                        report.Remove(reportItem);
                        if (report.Count < reportArray.Length - 1)
                        {
                            Console.WriteLine($"Reports rejected because of more than one level difference: {string.Join(" ", reportArray)}");
                            allDifferencesAccepted = false;
                            break;
                        }
                    }
                }

                if (allDifferencesAccepted)
                {
                    acceptedReports.Add(reportArray);
                }
            }
            return acceptedReports;
        }

        public static int ReportsWithMaxOneAscOrDescErrorLevel(List<int[]> reports)
        {
            int counterOfAcceptedReports = 0;
            bool mostAsc = false;
            bool mostDesc = false;
            bool allAscOrDesc = false;
            bool allAscOrDescAfterRemoval = false;            

            foreach (int[] reportArray in reports)
            {
                if(reportArray.Length < 4)
                {
                   counterOfAcceptedReports++;
                   continue;
                }
                
                List<int> report = reportArray.ToList();

                List<bool> isEachStepAsc = report.Zip(report.Skip(1), (a, b) => (a < b)).ToList();
                List<bool> isEachStepDesc = report.Zip(report.Skip(1), (a, b) => (a > b)).ToList();

                mostAsc = isEachStepAsc.Count(step => step == true) > isEachStepAsc.Count(step => step == false);  
                mostDesc = !mostAsc;

                List<bool> ascOrDesc;
                if (mostAsc)
                {
                    ascOrDesc = isEachStepAsc;                    
                }
                else
                {
                    ascOrDesc = isEachStepDesc;
                }

                bool allAscOrAllDesc = isEachStepAsc.All(step => step == true);
                if (allAscOrAllDesc)
                {
                    counterOfAcceptedReports++;
                }

                for (int i = 0; i < ascOrDesc.Count(); i++)
                {
                    if (ascOrDesc[i] == false)
                    {
                        int item = report[i + 1];
                        report.Remove(item);

                        allAscOrDescAfterRemoval = report.Zip(report.Skip(1), (a, b) => (a < b)).All(pair => pair);
                        if (allAscOrDescAfterRemoval == false)
                        {
                            Console.WriteLine($"Reports rejected because of not all asc or all desc after removal : {string.Join(" ", reportArray)}");
                            break;
                        }
                        counterOfAcceptedReports++;
                    }                    
                }                  
                
            }
            return counterOfAcceptedReports;
        }
    }
}

