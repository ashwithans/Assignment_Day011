using System;
using System.Diagnostics;

namespace example
{
    class Program
    {
        public static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }

        private static void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(array, left, right);
                QuickSort(array, left, pivotIndex - 1);
                QuickSort(array, pivotIndex + 1, right);
            }
        }

        private static int Partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    Swap(array, i, j);
                }
            }
            Swap(array, i + 1, right);
            return i + 1;
        }

        private static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        public static void MergeSort(int[] arr)
        {
            MergeSort(arr, 0, arr.Length - 1);
        }

        private static void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);
                Merge(arr, left, mid, right);
            }
        }

        private static void Merge(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] L = new int[n1];
            int[] R = new int[n2];

            Array.Copy(arr, left, L, 0, n1);
            Array.Copy(arr, mid + 1, R, 0, n2);

            int i = 0, j = 0;
            int k = left;

            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }

        public static void Print(int[] arr)
        {
            foreach (var element in arr)
            {
                Console.Write(element + " ");
            }
            Console.WriteLine("\n");
        }

        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[] sizes = { 20, 30, 50 };

            foreach (int size in sizes)
            {
                int[] array = new int[size];
                for (int i = 0; i < size; i++)
                {
                    array[i] = rnd.Next(100); // Generates random integers between 0 and 99
                }

                int[] quickSortArray = new int[size];
                array.CopyTo(quickSortArray, 0);

                int[] mergeSortArray = new int[size];
                array.CopyTo(mergeSortArray, 0);

                Stopwatch stopwatch = new Stopwatch();

                // QuickSort
                Console.WriteLine($"\nArray size: {size}");
                stopwatch.Start();
                QuickSort(quickSortArray);
                stopwatch.Stop();
                Console.WriteLine("After Quick Sort:");
                Print(quickSortArray);
                Console.WriteLine($"Quicksort took {stopwatch.Elapsed.TotalMilliseconds} ms");

                // MergeSort
                stopwatch.Reset();
                stopwatch.Start();
                MergeSort(mergeSortArray);
                stopwatch.Stop();
                Console.WriteLine("After Merge Sort:");
                Print(mergeSortArray);
                Console.WriteLine($"Merge Sort took {stopwatch.Elapsed.TotalMilliseconds} ms");
            }

            Console.ReadKey();
        }
    }
}
