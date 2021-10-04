using System;

public class ArrayAnalyzer
{
    public enum SortType
    {
        AscendingOrder,
        DescendingOrder,
        EvenFirst,
        OddsFirst
    }

    /// <summary>
    /// Receives an int array and determines whether or not its contents are continuous. The first number that breaks the sequence stops the verification.
    /// </summary>
    /// <returns>
    ///     Returns: true if it's continuous, or int if there is a number that breaks the sequence.
    /// </returns>
    public static object CheckIfContinuous(int[] arr)
    {
        int prev = arr[0] - 1;
        foreach (int num in arr)
        {
            if (prev != num - 1)
            {
                return num;
            }
            prev = num;

        }

        return true;
    }
    public static object SortArray(int[] array1, int[] array2, SortType sortType)
    {
        if (array1.Length == 0 || array2.Length == 0) { throw new ArgumentException("Array has no items"); }

        switch (sortType)
        {
            case SortType.AscendingOrder:
                int[] merged = MergeArray(array1, array2);
                merged = InsertionSortCrescent(merged);

                return merged;
            case SortType.DescendingOrder:
                merged = MergeArray(array1, array2);
                merged = InsertionSortDecrescent(merged);
                
                return merged;
            case SortType.EvenFirst:
                Tuple<int[], int[]> res = SeparateEvenFromOdd(array1, array2);
                int[] sortedOdds = InsertionSortDecrescent(res.Item1);
                int[] sortedEvens = InsertionSortDecrescent(res.Item2);

                return MergeArray(sortedEvens, sortedOdds);
            case SortType.OddsFirst:
                res = SeparateEvenFromOdd(array1, array2);
                sortedOdds = InsertionSortDecrescent(res.Item1);
                sortedEvens = InsertionSortDecrescent(res.Item2);

                return MergeArray(sortedOdds, sortedEvens);
            default:
                throw new ArgumentException("Invalid Merge Type");
        }
    }

    private static int[] InsertionSortDecrescent(int[] arr)
    {
        int[] sorted = arr;

        for (int i = 0; i < sorted.Length; i++)
        {
            var item = sorted[i];
            var currentIndex = i;

            while (currentIndex > 0 && sorted[currentIndex - 1] < item)
            {
                sorted[currentIndex] = sorted[currentIndex - 1];
                currentIndex--;
            }

            sorted[currentIndex] = item;
        }

        return sorted;
    }
    private static int[] InsertionSortCrescent(int[] arr)
    {
        int[] sorted = arr;

        for (int i = 0; i < sorted.Length; i++)
        {
            var item = sorted[i];
            var currentIndex = i;

            while (currentIndex > 0 && sorted[currentIndex - 1] > item)
            {
                sorted[currentIndex] = sorted[currentIndex - 1];
                currentIndex--;
            }

            sorted[currentIndex] = item;
        }

        return sorted;
    }
    private static Tuple<int[], int[]> SeparateEvenFromOdd(int[] array1, int[] array2)
    {
        int[] merged = MergeArray(array1, array2);
        int[] odd = Array.FindAll(merged, (n => n % 2 != 0));
        int[] even = Array.FindAll(merged, (n => n % 2 == 0));

        return Tuple.Create(odd, even);
    }

    private static int[] MergeArray(int[] array1, int[] array2)
    {
        int[] merged = new int[array1.Length + array2.Length];
        array1.CopyTo(merged, 0);
        array2.CopyTo(merged, array1.Length);

        return merged;
    }
}
//
