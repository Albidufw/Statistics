using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace Statistics
{
  
    public static class Statistics
    {
        public static int[] source = JsonConvert.DeserializeObject<int[]>(File.ReadAllText("data.json"));

        public static dynamic DescriptiveStatistics()
        {
            Dictionary<string, dynamic> StatisticsList = new Dictionary<string, dynamic>()
            {
                { "Maximum", Maximum() },
                { "Minimum", Minimum() },
                { "Medelvärde", Mean() },
                { "Median", Median() },
                { "Typvärde", String.Join(", ", Mode()) },
                { "Variationsbredd", Range() },
                { "Standardavvikelse", StandardDeviation() }
                
            };

            string output =
                $"Maximum: {StatisticsList["Maximum"]}\n" +
                $"Minimum: {StatisticsList["Minimum"]}\n" +
                $"Medelvärde: {StatisticsList["Medelvärde"]}\n" +
                $"Median: {StatisticsList["Median"]}\n" +
                $"Typvärde: {StatisticsList["Typvärde"]}\n" +
                $"Variationsbredd: {StatisticsList["Variationsbredd"]}\n" +
                $"Standardavvikelse: {StatisticsList["Standardavvikelse"]}";

            return output;
        }

        public static int Maximum()
        {
            Array.Sort(Statistics.source);
            Array.Reverse(source);
            int result = source[0];
            return result;
        }

        public static int Minimum()
        {
            Array.Sort(Statistics.source);
            int result = source[0];
            return result;
        }

        public static double Mean()
        {
            double total = 0;

            for (int i = 0; i < source.Length; i++)
            {
                total += source[i];
            }
            return total / source.Length;
        }

        public static double Median()
        {
            Array.Sort(source);
            int size = source.Length;
            int mid = size / 2;
            int dbl = source[mid];
            return dbl;
        }

        public static int[] Mode()
        {
           //Skapa ett dictionary för att lagra repetioner för varje unikt nummer
           Dictionary<int, int> repetitionDictionary = new Dictionary<int, int>();
            
            //Upprepa genom varje nummer i source array
           foreach (int num in source)
            {
                //Om nummret redan finns i dictionary, gå till nästa
                if (repetitionDictionary.ContainsKey(num))
                {
                    repetitionDictionary[num]++;
                }
                //Om nummret inte finns i dictionary, lägg till nummret 
                else
                {
                    repetitionDictionary[num] = 1;
                }
            }
           
           //Hitta det mest repeterade nummret bland alla nummer
            int maxRepetition = 0;
            foreach (int repetition in repetitionDictionary.Values)
            {
                if (repetition > maxRepetition)
                {  
                    maxRepetition = repetition; 
                }
            }

            //Skapa en lista som lagrar modes
            List<int> mode = new List<int>();

            //Upprepa genom disctionary för att hitta nummer med antal repetitioner lika med maxRepetition
            foreach (KeyValuePair<int, int> kvp in repetitionDictionary)
            {
                if (kvp.Value ==  maxRepetition)
                {
                    //Lägg till nummer till mode listan
                    mode.Add(kvp.Key);
                }
            }

            //Ändra mode listan till en array
            int[] modeArray = mode.ToArray();


            return modeArray;

        }


        public static int Range()
        {
            Array.Sort(Statistics.source);
            int min = source[0];
            int max = source[0];

            for (int i = 0; i < source.Length; i++)
                if (source[i] > max)
                    max = source[i];

            int range = max - min;
            return range;
        }

        public static double StandardDeviation() 
        {

            double average = source.Average();
            double sumOfSquaresOfDifferences = source.Select(val => (val - average) * (val - average)).Sum();
            double sd = Math.Sqrt(sumOfSquaresOfDifferences / source.Length);

            double round = Math.Round(sd, 1);
            return round;
        }

    }
}
