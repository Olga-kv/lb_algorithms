using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace lb_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 6000;

            Console.WriteLine("Bubble sort");
            int[] arr1 = BubbleSort(n);

            Console.WriteLine("Insert Sort");
            int[] arr2 = InsSort(n);

            Console.WriteLine("QuickSort");
            int[] arr3 = QuickSort(n);
            
            /*for(int i=0;i<n;i++)
            {
                Console.Write(arr3[i] + " ");
            }*/
             
            Console.Read();
        }

        //Програма сортування обмінами
        static int[] BubbleSort(int n)
        {
            int[] arr = new int[n];
            Random rand = new Random();

            for (int k = 0; k < n; k++)
            {
                arr[k] = rand.Next(1, 10);
            }

            int b = 0;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = n-1;i>=0;i--)
            {
                for(int j=0; j<i; j++)
                {
                    if(arr[j]>arr[j+1])
                    {
                        b = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = b;
                    }
                }
            }

            stopwatch.Stop();
            
            Console.WriteLine("Потрачено на выполнение: " + stopwatch.Elapsed.TotalSeconds);

            return arr;
        }

        //Програма сортування вставками
        static int[] InsSort(int n)
        {
            int[] arr = new int[n];
            Random rand = new Random();

            for (int k = 0; k < n; k++)
            {
                arr[k] = rand.Next(1, 10);
            }


            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int x;
            int j;
            int b=0;

            for (int i = 0; i < n; i++)
            {
                x = arr[i];
                j = i;
                while (j > 0 && arr[j - 1] > x)
                {
                    arr[j] = arr[j-1];
                    arr[j - 1] = b;
                    j -= 1;
                }
                arr[j] = x;
            }
            stopwatch.Stop();

            Console.WriteLine("Потрачено на выполнение: " + stopwatch.Elapsed.TotalSeconds);

            return arr;
        }

        //Програма швидкого сортування
        static int[] QuickSort(int n)
        {
            int[] arr = new int[n];
            Random rand = new Random();

            for (int k = 0; k < n; k++)
            {
                arr[k] = rand.Next(1, 10);
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Hoare(arr, 0, n-1);

            stopwatch.Stop();

            Console.WriteLine("Потрачено на выполнение: " + stopwatch.Elapsed.TotalSeconds);

            return arr;
        }

        static void Swap(int[] arr,int i,int j)
        {
            int temp;

            temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        static void Hoare(int[] arr,int L, int R)
        {
            int left, right;
            int x;
            if (L < R)
            {
                x = arr[(L + R) / 2];
                left = L;
                right = R;
                while (left < right)
                {
                    while (arr[left] < x)
                    {
                        left = left + 1;
                    }
                    while (arr[right] > x)
                    {
                        right = right - 1;
                    }
                    if (left <= right)
                    {
                        Swap(arr, left, right);
                        left = left + 1;
                        right = right - 1;
                    }
                }
                Hoare(arr,L, right);
                Hoare(arr,left, R);

            }
        }
    }
}
