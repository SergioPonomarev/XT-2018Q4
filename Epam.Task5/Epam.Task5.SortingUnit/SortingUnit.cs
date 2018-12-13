using System;
using System.Diagnostics;
using System.Threading;

namespace Epam.Task5.SortingUnit
{
    public class SortingUnit<T>
    {
        private static Stopwatch sw = new Stopwatch();

        private readonly object lockOn = new object();

        private double timePerformance;

        public event EventHandler<SortingUnitEventArgs> EndOfSorting;

        public Thread SortingUnitThread { get; set; }

        public void RunSortInNewThread(T[] arr, Func<T, T, int> compareMethod)
        {
            this.SortingUnitThread = new Thread(() => this.CustomSort(arr, compareMethod));
            this.SortingUnitThread.Start();
        }

        public void CustomSort(T[] arr, Func<T, T, int> compareMethod)
        {
            SortingUnit<T>.sw.Start();
            this.CustomSort(arr, 0, arr.Length - 1, compareMethod);
            SortingUnit<T>.sw.Stop();
            this.timePerformance = sw.Elapsed.TotalMilliseconds;
            SortingUnit<T>.sw.Reset();
            this.OnEndOfSorting(new SortingUnitEventArgs("End of sorting.", this.timePerformance));
        }

        protected virtual void OnEndOfSorting(SortingUnitEventArgs e)
        {
            this.EndOfSorting?.Invoke(this, e);
        }

        private void CustomSort(T[] arr, int l, int r, Func<T, T, int> compareMethod)
        {
            int i = l;
            int j = r;
            T x = arr[l + ((r - l) / 2)];

            while (i <= j)
            {
                while (compareMethod(arr[i], x) < 0)
                {
                    i++;
                }

                while (compareMethod(arr[j], x) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    T temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    i++;
                    j--;
                }
            }

            if (l < j)
            {
                this.CustomSort(arr, l, j, compareMethod);
            }

            if (i < r)
            {
                this.CustomSort(arr, i, r, compareMethod);
            }
        }
    }
}
