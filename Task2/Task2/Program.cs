using System;
using System.IO;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Пропишите пути к файлам: coords.txt dots.txt");
                return;
            }

            string coordsPath = args[0];
            string dotsPath = args[1];

            string[] lines = File.ReadAllLines(coordsPath);
            string[] linesdot = File.ReadAllLines(dotsPath);

            List<string> lines_result = new List<string>();
            List<string> linesdot_result = new List<string>();

            foreach (string line in lines)
            {
                if (line != "")
                {
                    lines_result.Add(line);
                }
            }

            foreach (string line in linesdot)
            {
                if (line != "")
                {
                    linesdot_result.Add(line);
                }
            }

            string[] lines_clear = lines_result.ToArray();
            string[] linesdot_clear = linesdot_result.ToArray();

            if (lines_clear.Length < 2 ||
                linesdot_clear.Length > 100 ||
                linesdot_clear.Length == 0)
            {
                Console.WriteLine("Данные не соответствуют условию");
                return;
            }

            string[] center = lines_clear[0].Split(' ');
            string[] radius = lines_clear[1].Split(' ');

            try
            {
                float x0 = float.Parse(center[0]);
                float y0 = float.Parse(center[1]);
                float x = float.Parse(radius[0]);
                float y = float.Parse(radius[1]);

                double r0 = (x0 - x) * (x0 - x) + (y0 - y) * (y0 - y);

                foreach (string line in linesdot_clear)
                {
                    string[] dot = line.Split(' ');

                    float a = float.Parse(dot[0]);
                    float b = float.Parse(dot[1]);

                    double r = (x0 - a) * (x0 - a) + (y0 - b) * (y0 - b);

                    if (r0 == r) Console.WriteLine("{0}\n", 0);
                    if (r0 > r) Console.WriteLine("{0}\n", 1);
                    if (r0 < r) Console.WriteLine("{0}\n", 2);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}