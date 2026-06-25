using System;
using System.IO;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Пропишите путь к файлу: nums.txt");
                return;
            }

            string numsPath = args[0];

            string[] lines = File.ReadAllLines(numsPath);

            List<string> lines_result = new List<string>();

            foreach (string line in lines)
            {
                if (line != "")
                {
                    lines_result.Add(line);
                }
            }

            string[] lines_clear = lines_result.ToArray();


            try
            {
                int[] nums = new int[lines_clear.Length];
                for (int i = 0; i < lines_clear.Length; i++)
                {
                    nums[i] = int.Parse(lines_clear[i]);
                }

                Array.Sort(nums);
                int median = nums[nums.Length / 2];

                int moves = 0;
                foreach (int n in nums)
                {
                    moves += Math.Abs(n - median);
                }

                if (moves <= 20)
                    Console.WriteLine(moves);
                else
                    Console.WriteLine("20 ходов не хватает");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}