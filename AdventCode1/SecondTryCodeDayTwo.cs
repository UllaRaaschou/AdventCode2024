
using System.Linq;

namespace AdventCode2024
{
    public class SecondTryCodeDayTwo
    {
        // All level diff >=1 &&  level diff <= 3
        // All levels must be asc or desc
        // Max one level must be ignored
        public static int CounterOfdiffsBetweenOneAndThreeIncl(int[] reportArray)
        {
            int counter = 0;

            for (int i = 1; i < reportArray.Length; i++)
            {
                if (!(Math.Abs(reportArray[i] - reportArray[i - 1]) >= 1 && Math.Abs(reportArray[i] - reportArray[i - 1]) <= 3))
                {
                    counter++;
                    if(counter > 2)
                    {
                        return counter;
                    }
                }
            }
            return counter;
        }

        public static (int[]?, bool) ArrayPassingLevelDiffControl(int[] inputArray)
        {
            int counterOfDiffsErrors = CounterOfdiffsBetweenOneAndThreeIncl(inputArray);

            switch (counterOfDiffsErrors)
            {
                case int x when x == 0:
                    return (inputArray, false);
                case int x when x == 1 || x == 2:
                    return (DeleteOneLevelDiffError(inputArray), true);
                default:
                    return (null, false);
                    break;
            }
        }


        public static int[] DeleteOneLevelDiffError(int[] reportArray)
        {
            List<int> reportListCopy1 = reportArray.ToList();
            List<int> reportListCopy2 = reportArray.ToList();

            List<int> reportList = reportArray.ToList();
            for (int i = 1; i < reportList.Count; i++)
            {
                if (Math.Abs(reportList[i] - reportList[i - 1]) > 3)
                {

                    int[] refactoredArray = RemoveAt(i - 1, reportListCopy1);
                    if (refactoredArray != null)
                    {
                        return refactoredArray;
                    }

                    refactoredArray = RemoveAt(i, reportListCopy2);
                    if (refactoredArray != null)
                    {
                        return refactoredArray;
                    }
                }
            }
            return null;
        }



        //public static int CounterOfDiffsNotfollowingAscDescPattern(int[] reportArray)
        //{
        //    int ascCounter = 0;
        //    int descCounter = 0;
        //    int notAscDescCounter = 0;

        //    for (int i = 1; i < reportArray.Length; i++)
        //    {
        //        if (reportArray[i] > reportArray[i - 1])
        //        {
        //            descCounter++;
        //        }
        //        if (reportArray[i] < reportArray[i - 1])
        //        {
        //            ascCounter++;
        //        }
        //        if (reportArray[i] == reportArray[i - 1])
        //        {
        //            notAscDescCounter++;
        //        }
        //    }
        //    if ((Math.Abs(ascCounter - descCounter) > 1) || (notAscDescCounter > 1))
        //    {
        //        int counterOfDominatingAscOrDescDiffs = Math.Max(ascCounter, descCounter);
        //        int counterOfDiifsNotFollowingAscDescPattern = (reportArray.Length - 1) - counterOfDominatingAscOrDescDiffs;
        //        return counterOfDiifsNotFollowingAscDescPattern;
        //    }
        //    return -1;

        //}


        public static bool AllReportIsAscOrDesc(int[]? reportArray)
        {
            if(reportArray != null) 
            {
                bool allAsc = reportArray.Zip(reportArray.Skip(1), (a, b) => a < b).All(x => x);
                bool allDesc = reportArray.Zip(reportArray.Skip(1), (a, b) => a > b).All(x => x);
                return allAsc || allDesc;
            }
            return false;

        }

        public static int[] DeleteOneAscDescError(int[] reportArray)
        {
            int asc = 0;
            int desc = 0;

            for (int i = 1; i < reportArray.Length; i++)
            {
                if (reportArray[i] > reportArray[i - 1])
                {
                    asc++;
                }
                else if (reportArray[i] < reportArray[i - 1])
                {
                    desc++;
                }
            }

            List<int> reportList = reportArray.ToList();

            if (asc > desc)  // If asc array, delete the desc element
            {
                for (int i = 1; i < reportList.Count; i++)
                {
                    if (reportList[i] <= reportList[i - 1])
                    {
                        reportList.RemoveAt(i - 1);
                        int[] refactoredArray = reportList.ToArray();
                        bool allNowDescOrAsc = AllReportIsAscOrDesc(refactoredArray);
                        if (allNowDescOrAsc)
                        {
                            return refactoredArray;
                        }
                        reportList.RemoveAt(i);
                        refactoredArray = reportList.ToArray();
                        bool allNowDescOrAsc2 = AllReportIsAscOrDesc(refactoredArray);
                        if (allNowDescOrAsc2)
                        {
                            return refactoredArray;
                        }
                    }
                }
                if (asc < desc)  // If desc array, delete the asc element
                {
                    for (int i = 1; i < reportList.Count; i++)
                    {

                        if (reportList[i] >= reportList[i - 1])
                        {
                            reportList.RemoveAt(i - 1);
                            int[] refactoredArray = reportList.ToArray();
                            bool allNowDescOrAsc = AllReportIsAscOrDesc(refactoredArray);
                            if (allNowDescOrAsc)
                            {
                                return refactoredArray;
                            }
                            if (!allNowDescOrAsc)
                            {
                                reportList.RemoveAt(i);
                                int[] refactoredArray2 = reportList.ToArray();
                                bool allNowDescOrAsc2 = AllReportIsAscOrDesc(refactoredArray);
                                if (allNowDescOrAsc2)
                                {
                                    return refactoredArray2;
                                }


                            }

                        }
                    }
                    
                }
            }
            return reportList.ToArray();
        }

        

        public static int[] RemoveAt(int index, List<int> actualList)
        {
            actualList.RemoveAt(index);
            bool reportNowSafe = actualList.Zip(actualList.Skip(1), (a, b) => Math.Abs(a - b) <= 3).All(x => x);
            int[] refactoredArray = reportNowSafe ? actualList.ToArray() : null;
            return refactoredArray;
        }

        

        public static bool PassingAscDescControlGivesFinalResult(int[] inputArray, bool oneLevelIsDeleted)
        {
            bool reportIsSAFE = false;

            if (oneLevelIsDeleted)            {

                bool reportSAFE = AllReportIsAscOrDesc(inputArray);
                if (reportSAFE) 
                {
                    reportIsSAFE = true;
                }
            }
            if(!oneLevelIsDeleted)
            {
                int[] arrayWithOneDeletion = DeleteOneAscDescError(inputArray);
                bool reportSAFE2 = AllReportIsAscOrDesc(arrayWithOneDeletion);
                if (reportSAFE2)
                {
                    reportIsSAFE = true;
                }
            }

            return reportIsSAFE;
        }

        public static bool PassingLevelDiffAndAscDescControl(int[] inputArray)
        {
            (int[]?, bool) SAFEReportAccordingToLevelDiffs = ArrayPassingLevelDiffControl(inputArray);
            bool finalReportIsSAFE = PassingAscDescControlGivesFinalResult(SAFEReportAccordingToLevelDiffs.Item1, SAFEReportAccordingToLevelDiffs.Item2);
            return finalReportIsSAFE;



        }

        public static int Puzzle(List<int[]> recordsArrayList)
        {
            int counterOfSafeReports = 0;

            foreach (int[] reportArray in recordsArrayList)
            {
                bool finalReportIsSAFE = PassingLevelDiffAndAscDescControl(reportArray);
                if (finalReportIsSAFE)
                {
                    counterOfSafeReports++;
                }
            }
            return counterOfSafeReports;
        }
    }

}
