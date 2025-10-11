// 代码生成时间: 2025-10-11 21:03:34
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAnalysisApp
{
    /// <summary>
    /// Provides functionalities to analyze data.
    /// </summary>
    public class DataAnalyzer
    {
        private const string ErrorPrefix = "DataAnalyzer: ";

        /// <summary>
        /// Calculates the mean (average) of a list of numbers.
        /// </summary>
        /// <param name="numbers">List of numbers to calculate the mean.</param>
        /// <returns>The mean of the numbers.</returns>
        public double CalculateMean(List<double> numbers)
        {
            if (numbers == null || numbers.Count == 0)
                throw new ArgumentException(ErrorPrefix + "List of numbers is null or empty.");
            return numbers.Average();
        }

        /// <summary>
        /// Calculates the median of a list of numbers.
        /// </summary>
        /// <param name="numbers">List of numbers to calculate the median.</param>
        /// <returns>The median of the numbers.</returns>
        public double CalculateMedian(List<double> numbers)
        {
            if (numbers == null || numbers.Count == 0)
                throw new ArgumentException(ErrorPrefix + "List of numbers is null or empty.");
            numbers = numbers.OrderBy(n => n).ToList();
            int middle = numbers.Count / 2;
            if (numbers.Count % 2 == 0)
                return (numbers[middle - 1] + numbers[middle]) / 2;
            else
                return numbers[middle];
        }

        /// <summary>
        /// Calculates the mode of a list of numbers.
        /// </summary>
        /// <param name="numbers">List of numbers to calculate the mode.</param>
        /// <returns>The mode of the numbers.</returns>
        public double CalculateMode(List<double> numbers)
        {
            if (numbers == null || numbers.Count == 0)
                throw new ArgumentException(ErrorPrefix + "List of numbers is null or empty.");
            var mode = numbers.GroupBy(x => x)
                .OrderByDescending(g => g.Count())
                .ThenBy(g => g.Key)
                .FirstOrDefault();
            return mode != null ? mode.Key : 0;
        }

        /// <summary>
        /// Calculates the standard deviation of a list of numbers.
        /// </summary>
        /// <param name="numbers">List of numbers to calculate the standard deviation.</param>
        /// <returns>The standard deviation of the numbers.</returns>
        public double CalculateStandardDeviation(List<double> numbers)
        {
            if (numbers == null || numbers.Count == 0)
                throw new ArgumentException(ErrorPrefix + "List of numbers is null or empty.");
            double mean = CalculateMean(numbers);
            double variance = numbers.Average(n => (n - mean) * (n - mean));
            return Math.Sqrt(variance);
        }
    }
}
