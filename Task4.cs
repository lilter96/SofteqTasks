using System;
using System.Linq;

namespace task4
{
    class InputModel
    {
        public int N { get; set; }
        public int M { get; set; }
    }

    static class InputManager
    {
        static public InputModel GetInput()
        {
            var data = Console.ReadLine().Trim().Split(' ').Select(value => int.Parse(value)).ToList();
            int n = data[0];
            int m = data[1];
            InputModel input = new InputModel() { N = n, M = m };
            return input;
        }
    }

    static class SolveTask
    {
        static public int GetAnswer(InputModel model)
        {
            int n = model.N;
            int m = model.M;
            if (n < m)
            {
                int tmp = n;
                n = m;
                m = tmp;
            }
            return 2 * n + 1 + (n + 1) * (m - 1);
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
