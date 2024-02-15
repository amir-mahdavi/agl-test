namespace agl_test.Common.Tools
{
    public class QuickSort
    {
        public static List<T> Sort<T>(List<T> items, Func<T, IComparable> keySelector)
        {
            if (items == null || items.Count <= 1)
                return items?.ToList() ?? new List<T>(); // Create a copy of the original list

            var copy = items.ToList(); // Create a copy to avoid mutating the original list
            QuickSortInternal(copy, keySelector, 0, copy.Count - 1);
            return copy;
        }

        private static void QuickSortInternal<T>(List<T> items, Func<T, IComparable> keySelector, int left, int right)
        {
            if (left >= right)
                return;

            int partitionIndex = Partition(items, keySelector, left, right);

            QuickSortInternal(items, keySelector, left, partitionIndex - 1);
            QuickSortInternal(items, keySelector, partitionIndex + 1, right);
        }

        private static int Partition<T>(List<T> items, Func<T, IComparable> keySelector, int left, int right)
        {
            T pivot = items[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (keySelector(items[j]).CompareTo(keySelector(pivot)) <= 0)
                {
                    i++;
                    Swap(items, i, j);
                }
            }

            Swap(items, i + 1, right);
            return i + 1;
        }

        private static void Swap<T>(List<T> items, int a, int b)
        {
            T temp = items[a];
            items[a] = items[b];
            items[b] = temp;
        }
    }
}
