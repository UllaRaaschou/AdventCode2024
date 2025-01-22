
namespace TestProjectAdvent
{
    public class NewDayTwoCode
    {
        public static (int[] outputArray, bool isSafe) PuzzlePartOne(int[] inputArray)
        {          
            if (!allElementsDiffersBetweenOneAndThree(inputArray))
            {
                return (new int[0], false);
            }

            if(!IsTruelyAscOrDesc(inputArray))
            {
                return (new int[0], false);
            }
            return (inputArray, true);
        }        

        private static bool allElementsDiffersBetweenOneAndThree(int[] inputArray)
        {
            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                if (!IsBetweenOneAndThree(inputArray[i], inputArray[i + 1]))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool IsBetweenOneAndThree(int first, int second)
        {
            return Math.Abs(first - second) >= 1 && Math.Abs(first - second) <= 3;
        }

        private static bool IsTruelyAscOrDesc(int[] inputArray)
        {
            bool allAsc = inputArray.Zip(inputArray.Skip(1), (a, b) => a < b).All(x => x);
            bool allDesc = inputArray.Zip(inputArray.Skip(1), (a, b) => a > b).All(x => x);
            return allAsc || allDesc;
        }





        public static (int[] outputArray, bool isSafe) PuzzlePartTwo(int[] inputArray)
        {
            int[] inputArrayCopy = inputArray.Clone() as int[];
            
            (int[] array, bool isTrue) = PuzzlePartOne((int[])inputArray);
            if (!isTrue)
            {
                for (int i = 0; i < inputArray.Length; i++)
                {
                    int[] subArray = RemoveElementAtIndex(inputArray, i);

                    (int[] refactoredArray, bool isSafe) = PuzzlePartOne(subArray);

                    inputArray = inputArrayCopy.Clone() as int[];
                    
                    if (isSafe)
                    {
                        return (refactoredArray, isSafe);
                    }
                }
                return (new int[0], false);
            }

            return (inputArray, true);
        }

        private static int[] RemoveElementAtIndex(int[] array, int index)
        {
            int[] subArray = new int[array.Length - 1];
            Array.Copy(array, 0, subArray, 0, index);
            Array.Copy(array, index + 1, subArray, index, array.Length - index - 1);
            return subArray;
        }

    }
}