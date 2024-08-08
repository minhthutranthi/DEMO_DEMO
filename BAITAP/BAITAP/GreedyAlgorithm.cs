using System;
using System.Collections.Generic;

namespace BAITAP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Item> items = new List<Item>
            {
                new Item { Value = 60, Weight = 10 },
                new Item { Value = 100, Weight = 20 },
                new Item { Value = 120, Weight = 30 },
                new Item { Value = 50, Weight = 5 },
                new Item { Value = 70, Weight = 10 }
            };

            int capacity = 50;

            double maxValue = GreedyKnapsack(capacity, items);
            Console.WriteLine("Maximum value in Knapsack = " + maxValue);
        }

        public class Item
        {
            public int Value { get; set; }
            public int Weight { get; set; }
            public double Ratio { get { return (double)Value / Weight; } }
        }

        public static double GreedyKnapsack(int capacity, List<Item> items)
        {
         

            double totalValue = 0;
            int currentWeight = 0;

            
            foreach (var item in items)
            {
                if (currentWeight + item.Weight <= capacity)
                {
                    currentWeight += item.Weight;
                    totalValue += item.Value;
                }
                else
                {
                    int remainingWeight = capacity - currentWeight;
                    totalValue += item.Value * ((double)remainingWeight / item.Weight);
                    break;
                }
            }

            return totalValue;
        }
    }
}
