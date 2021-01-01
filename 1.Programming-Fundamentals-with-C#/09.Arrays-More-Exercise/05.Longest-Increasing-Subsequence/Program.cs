using System;
using System.Linq;

namespace _05.Longest_Increasing_Subsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] index = new int[nums.Length];

            int maxIndex = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                for (int z = 0; z < i; z++)
                {
                    if (nums[z] < nums[i] && index[z] > index[i] - 1)
                    {
                        index[i] = index[z] + 1;

                        if (index[i] > index[maxIndex])
                        {
                            maxIndex = i;
                        }
                    }
                }
            }

            ResultPrint(maxIndex, nums, index);
        }

        static void ResultPrint(int maxIndex, int[] nums, int[] index)
        {
            bool isFirst = true;

            for (int i = 0; i < maxIndex; i++)
            {
                if (nums[i] < nums[maxIndex] && index[i] == index[maxIndex] - 1 && isFirst)
                {
                    isFirst = false;

                    ResultPrint(i, nums, index);
                }
            }

            Console.Write(nums[maxIndex] + " ");
        }
    }
}
