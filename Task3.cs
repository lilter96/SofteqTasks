using System;
using System.Linq;

namespace task3
{
    class InputModel
    {
        public long A { get; set; }
        public long B { get; set; }
        public long N { get; set; }
    }

    static class InputManager
    {
        static public InputModel GetInput()
        {
            var data = Console.ReadLine().Trim().Split(' ').Select(value => long.Parse(value)).ToList();
            long a = data[0];
            long b = data[1];
            long n = data[2];
            InputModel input = new InputModel() { A = a, B = b, N = n };
            return input;
        }
    }

    static class SolveTask
    {
        static public long GetAnswer(InputModel model)
        {
            long maxValue = Math.Max(model.A, model.B);
            long minValue = Math.Min(model.A, model.B);
            long ans = 0;
            for (int countMinValue = 0; countMinValue * minValue <= model.N; countMinValue++)
            {
                long remainder = model.N - countMinValue * minValue;
                if (remainder % maxValue == 0)
                {
                    ans = Math.Max(ans, (long)(Math.Pow(minValue, countMinValue) * Math.Pow(maxValue, remainder / maxValue)));
                }
            }
            return ans;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SolveTask.GetAnswer(InputManager.GetInput()));
        }
    }
}
