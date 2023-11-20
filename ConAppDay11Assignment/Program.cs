using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppDay11Assignment
{
    internal class Program
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
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine("\n");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the array elements:");
            int[] array = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            Console.WriteLine("\nOriginal Array:");
            Print(array);

            int[] quickSortArray = new int[array.Length];
            array.CopyTo(quickSortArray, 0);

            int[] mergeSortArray = new int[array.Length];
            array.CopyTo(mergeSortArray, 0);

            Stopwatch stopwatch = new Stopwatch();

            // QuickSort
            Console.WriteLine("\nAfter Quick Sort:");
            stopwatch.Start();
            QuickSort(quickSortArray);
            stopwatch.Stop();
            Print(quickSortArray);
            Console.WriteLine($"Quicksort took {stopwatch.Elapsed.TotalMilliseconds} ms");

            // MergeSort
            Console.WriteLine("\nAfter Merge Sort:");
            stopwatch.Reset();
            stopwatch.Start();
            MergeSort(mergeSortArray);
            stopwatch.Stop();
            Print(mergeSortArray);
            Console.WriteLine($"Merge Sort took {stopwatch.Elapsed.TotalMilliseconds} ms");

            Console.ReadKey();

        }
    }
}
