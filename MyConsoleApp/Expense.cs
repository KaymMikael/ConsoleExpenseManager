using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp
{
    internal class Expense
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }

        public Expense(int id, string name, string category, double price)
        {
            Id = id;
            Name = name;
            Category = category;
            Price = price;
        }

        public void PrintInfo()
        {
            Console.WriteLine();
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Category: {Category}");
            Console.WriteLine($"Price: {FormatPrice(Price)}");
        }
        protected string FormatPrice(double price)
        {
            string result = price.ToString("#,00.00");
            return result;
        }
    }
}
