using System;
using System.Collections.Generic;

namespace Francespo.Extensions
{
    public static class StringExtensions
    {
        public enum DistanceAlgorithm { Hamming, Levenshtein, DamerauLevenshtein }
        public static int FindDistance(this string str1, string str2, DistanceAlgorithm algorithm = DistanceAlgorithm.DamerauLevenshtein)
        {
            if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2))
                throw new ArgumentNullException();

            switch (algorithm)
            {
                case DistanceAlgorithm.Hamming:
                    return StringMethods.GetHammingDistance(str1, str2);
                case DistanceAlgorithm.Levenshtein:
                    return StringMethods.LevenshteinDistance(str1, str2);
                case DistanceAlgorithm.DamerauLevenshtein:
                    return StringMethods.GetDamerauLevenshteinDistance(str1, str2);
                default:
                    throw new Exception();
            }
        }
        public static string FindSimilarityFrom(this string str1, IEnumerable<string> strings)
        {
            string toReturn = string.Empty;
            int best = 10000000;
            foreach (string str in strings)
            {
                int current = str1.FindDistance(str);
                if (current < best)
                {
                    toReturn = str;
                    best = current;
                }

            }
            return toReturn;
        }

    }
}
