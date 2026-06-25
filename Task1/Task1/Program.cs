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
                int n1 = int.Parse(args[0]);
                int m1 = int.Parse(args[1]);
                int n2 = int.Parse(args[2]);
                int m2 = int.Parse(args[3]);

                Task<string> arr1 = Task.Run(() => BuildPath(n1, m1));
                Task<string> arr2 = Task.Run(() => BuildPath(n2, m2));
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