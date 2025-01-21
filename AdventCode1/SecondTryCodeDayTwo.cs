
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
                    break;
                }

            }
            return counter;
        }

        public static int CounterOfDiffsNotfollowingAscDescPattern(int[] reportArray)
        {
            int ascCounter = 0;
            int descCounter = 0;
            int notAscDescCounter = 0;

            for (int i = 1; i < reportArray.Length; i++)
            {
                if (reportArray[i] > reportArray[i - 1])
                {
                    descCounter++;
                }
                if (reportArray[i] < reportArray[i - 1])
                {
                    ascCounter++;
                }
                if (reportArray[i] == reportArray[i - 1])
                {
                    notAscDescCounter++;
                }
            }
            if ((Math.Abs(ascCounter - descCounter) > 1) || (notAscDescCounter > 1))
            {
                int counterOfDominatingAscOrDescDiffs = Math.Max(ascCounter, descCounter);
                int counterOfDiifsNotFollowingAscDescPattern = (reportArray.Length - 1) - counterOfDominatingAscOrDescDiffs;
                return counterOfDiifsNotFollowingAscDescPattern;
            }
            return -1;

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
                if (reportArray[i] < reportArray[i - 1])
                {
                    desc++;
                }

            }

            List<int> reportList = reportArray.ToList();

            if (asc > desc)  // If asc array, delete the desc element
            {
                for (int i = 1; i < reportList.Count; i++)
                {
                    if (reportList[i] < reportList[i - 1])
                    {
                        reportList.RemoveAt(i - 1);
                    }
                }
            }
            if (asc < desc)  // If desc array, delete the asc element
            {
                for (int i = 1; i < reportList.Count; i++)
                {
                    
                    if (reportList[i] > reportList[i - 1])
                    {
                        reportList.RemoveAt(i - 1);
                    }
                }
            }
            return reportList.ToArray();
        }

        public static int[] DeleteOneLevelDiffError(int[] reportArray)
        {          
            
            List<int> reportList = reportArray.ToList();
            for (int i = 1; i < reportList.Count; i++)
            {
                if (Math.Abs(reportList[i] - reportList[i - 1]) > 3)
                {
                    List<int> reportListCopy = reportList;

                    int[] refactoredArray = RemoveAt(i - 1, reportListCopy);
                    if (refactoredArray != null)
                    {
                        return refactoredArray;
                    }

                    refactoredArray = RemoveAt(i, reportList);
                    if (refactoredArray != null)
                    {
                        return refactoredArray;
                    }
                }
            }
            return reportArray;
        }

        public static int[] RemoveAt(int index, List<int> actualList)
        {
            actualList.RemoveAt(index);
            bool reportNowSafe = actualList.Zip(actualList.Skip(1), (a, b) => Math.Abs(a - b) <= 3).All(x => x);
            int[] refactoredArray = reportNowSafe ? actualList.ToArray() : null;
            return refactoredArray;
        }
    }   

}
