using System;
using System.Collections.Generic;
using System.Linq;

namespace task22
{
    class InputModel
    {
        public int N { get; set; }
        public int M { get; set; }
        public List<int> WheelSpeeds { get; set; }
    }
    static class InputManager
    {
        static public InputModel GetInput()
        {
            var data = Console.ReadLine().Trim().Split(' ').Select(value => int.Parse(value)).ToList();
            int n = data[0];
            int m = data[1];
            var speeds = new List<int>();
            for (int i = 0; i < n; i++)
            {
                speeds.Add(int.Parse(Console.ReadLine().Trim()));
            }

            var model = new InputModel() { N = n, M = m, WheelSpeeds = speeds };
            return model;
        }
    }

    static class SolveTask
    {
        static public double GetAnswer(InputModel model)
        {
            var consumption = model.WheelSpeeds.Select(speed => 1.0 / speed);
            return model.M / consumption.Sum();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("{0:F3}", SolveTask.GetAnswer(InputManager.GetInput()));
        }
    }
}
