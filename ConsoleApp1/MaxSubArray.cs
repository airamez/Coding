using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    public class MaxSubArray
    {
        public static void Main (string[] args)
        {
            Console.WriteLine(GetMaxSubArraySumBruteForce(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }));
            Console.WriteLine(GetMaxSubArraySumDP_1(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }));
            Console.WriteLine(GetMaxSubArraySumDP_2(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }));
            Console.WriteLine(GetMaxSubArraySumDP_3(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }));

            Console.WriteLine(GetMaxSubArraySumBruteForce(new int[] { -2, -5, 6, -2, -3, 1, 5, -6 }));
            Console.WriteLine(GetMaxSubArraySumDP_1(new int[] { -2, -5, 6, -2, -3, 1, 5, -6 }));
            Console.WriteLine(GetMaxSubArraySumDP_2(new int[] { -2, -5, 6, -2, -3, 1, 5, -6 }));
            Console.WriteLine(GetMaxSubArraySumDP_3(new int[] { -2, -5, 6, -2, -3, 1, 5, -6 }));
        }

        private static int GetMaxSubArraySumBruteForce(int[] a)
        {
            int maxSum = a[0];
            for (int i = 0; i < a.Length; i++) {
                int currentSum = a[i];
                for (int j = i + 1; j < a.Length; j++) {
                    currentSum += a[j];
                    if (currentSum > maxSum)
                        maxSum = currentSum;
                }
            }

            return maxSum;
        }

        private static int GetMaxSubArraySumDP_1(int[] a)
        {
            int[] subs = new int[a.Length];
            subs[0] = a[0];
            for (int i = 1; i < subs.Length; i++) {
                int sum = subs[i - 1] + a[i];
                if ( sum > a[i]) {
                    subs[i] = sum;
                } else {
                    subs[i] = a[i];
                }
            }
            int max = subs[0];
            for (int i = 1; i < a.Length; i++)
                if (subs[i] > max)
                    max = subs[i];
            return max;
        }

        private static int GetMaxSubArraySumDP_2(int[] a)
        {
            int maxSum = a[0];
            int[] subs = new int[a.Length];
            subs[0] = a[0];
            for (int i = 1; i < subs.Length; i++) {
                int sum = subs[i - 1] + a[i];
                if (sum > a[i]) {
                    subs[i] = sum;
                } else {
                    subs[i] = a[i];
                }
                if (subs[i] > maxSum)
                    maxSum = subs[i];
            }
            return maxSum;
        }

        private static int GetMaxSubArraySumDP_3(int[] a)
        {
            int max = a[0];
            int maxLocal = max;
            for (int i = 1; i < a.Length; i++) {
                maxLocal = Math.Max(maxLocal + a[i], a[i]);
                max = Math.Max(max, maxLocal);
            }
            return max;
        }

        private static void Print(int[] a)
        {
            foreach(int i in a) {
                Console.Write(i + ", ");
            }
            Console.WriteLine();
        }
    }
}
