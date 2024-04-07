﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqIterator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> daysInMonths = new Dictionary<string, int>()
            {
                { "Janurary", 31 },
                { "February", 28 },
                { "March", 31 },
                { "April", 30 },
                { "May", 31 },
                { "June", 30 },
                { "July", 31 },
                { "August", 31 },
                { "September", 30 },
                { "October", 31 },
                { "November", 30 },
                { "December", 31 }
            };

            var selection = from n in daysInMonths
                            where n.Key.Length > 5
                            select n;

            selection = from n in selection
                        where n.Value == 31
                        orderby n.Key
                        select n;

            foreach (var n in selection)
            {
                Console.Write(n + " ");
            }

            Console.WriteLine("\n");
        }
    }
}
