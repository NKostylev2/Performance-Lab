using System;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 4)
            {
                Console.WriteLine("Передайте 4 числа: n1 m1 n2 m2");
                return;
            }

            try
            {
                int[] nums = new int[args.Length];

                for (int i = 0; i < args.Length; i++)
                {
                    nums[i] = int.Parse(args[i]);

                    if (nums[i] <= 0)
                    {
                        Console.WriteLine("Некорректные данные");
                        return;
                    }
                }

                Task<string> arr1 = Task.Run(() => BuildPath(nums[0], nums[1]));
                Task<string> arr2 = Task.Run(() => BuildPath(nums[2], nums[3]));
                Task.WaitAll(arr1, arr2);

                string result = arr1.Result + arr2.Result;
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }

        static string BuildPath(int n, int m)
        {
            string path = "";
            int pos = 0;

            do
            {
                path += (pos + 1).ToString();
                pos = (pos + m - 1) % n;
            }
            while (pos != 0);

            return path;
        }
    }
}