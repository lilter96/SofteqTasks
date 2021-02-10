using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace task1
{
    static class Coefficients
    {
        static public decimal A { get; } = 1M;
        static public decimal B { get; } = 1.2M;
        static public decimal C { get; } = -20M;
        static public decimal D { get; } = 0M;
        static public decimal E { get; } = 123.456M;
    }

    class InputModel
    {
        public int TestsCount { get; set; }
        public List<decimal> Numbers { get; set; }
    }

    static class InputData
    {
        static public NumberFormatInfo FormatInfo { get; private set; } = new NumberFormatInfo();
        static public InputModel Get()
        {
            FormatInfo.NumberDecimalSeparator = ".";

            var testsCount = int.Parse(Console.ReadLine().Trim());
            var numbers = new List<decimal>();
            while (testsCount-- > 0)
            {
                var number = decimal.Parse(Console.ReadLine().Trim(), FormatInfo);
                numbers.Add(number);
            }
            var model = new InputModel() { TestsCount = testsCount, Numbers = numbers };
            return model;
        }
    }
    static class Polynomial
    {
        static public decimal GetPolynomialValue(decimal x)
        {
            return x * x * x * x * Coefficients.A + x * x * x * Coefficients.B + x * x * Coefficients.C +
                    x * Coefficients.D + Coefficients.E;
        }
    }

    static class SolveTask
    {
        public static List<decimal> GetAnswer(InputModel model)
        {
            var result = new List<decimal>();
            model.Numbers.ForEach(item => result.Add(Polynomial.GetPolynomialValue(item)));
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SolveTask.GetAnswer(InputData.Get()).ForEach(x => Console.WriteLine("{0:F3}", x));
        }
    }
}
