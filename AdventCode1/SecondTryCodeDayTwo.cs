
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

        //public static int  OneDiffErrorCanBeAcccepted(int[] reportArray)
        //{

        //    int counterOfDiffsNOTBetweenOneAndThreeIncl = 0;


        //    for (int i = 1; i < reportArray.Length; i++)
        //    {
        //        if (!(Math.Abs(reportArray[i] - reportArray[i - 1]) >= 1 && Math.Abs(reportArray[i] - reportArray[i - 1]) <= 3))
        //        {

        //            counterOfDiffsNOTBetweenOneAndThreeIncl++;  
        //            break;
        //        }

        //    }

        //    switch (counterOfDiffsNOTBetweenOneAndThreeIncl)
        //    {
        //        case 0:
        //            // Handle when counterOfDiffsNOTBetweenOneAndThreeIncl is 0
        //            break;
        //        case 1:
        //            // Handle when counterOfDiffsNOTBetweenOneAndThreeIncl is 1
        //            break;
        //        case 2:
        //            // Handle when counterOfDiffsNOTBetweenOneAndThreeIncl is 2
        //            break;
        //        default:
        //            // Handle when counterOfDiffsNOTBetweenOneAndThreeIncl is greater than 2
        //            break;
        //    }
        //    return counterOfDiffsNOTBetweenOneAndThreeIncl;

    }
}
