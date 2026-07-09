using System;

namespace FinancialForecasting
{
    class Program
    {
        static void Main(string[] args)
        {
            double initialValue = 10000;
            double growthRate = 0.10; // 10%
            int years = 6;

            double futureValue =
                FinancialForecast.PredictFutureValue(
                    initialValue,
                    growthRate,
                    years);

            Console.WriteLine(
                $"Future Value after {years} years: {futureValue:F2}");
        }
    }
}