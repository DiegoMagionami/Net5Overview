using Net5Console.Helpers;
using Net5Console.Models.Classes;
using Net5Console.Models.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5Console
{
    public class RecordsOverview
    {
        public void InitRecord()
        {
            // intro
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Hello! I can diplay some nutritional information about your preferred food.");
            Console.WriteLine("Please enter the name of your preferred food");
            Console.ForegroundColor = ConsoleColor.White;
            var food = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Now insert the weight in grams");
            Console.ForegroundColor = ConsoleColor.White;
            var weightInserted = Console.ReadLine();

            double weight = 0;
            string statement = string.Empty;
            
            if (double.TryParse(weightInserted, out weight))
            {
                statement = weight switch
                {
                    <= 100 => "You're good!",
                    > 100 and <= 200 => "Maybe you should eat a litte bit less",
                    > 200 and <= 300 => "You should really consider to eat less",
                    > 300 => "Do you really can eat all that stuff?"
                };
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{statement}\nPress enter to continue...");
            Console.ResetColor();
            Console.ReadLine();

            var foodClass = this.GetClass(food, weight);
            var foodRecord = this.GetRecord(food, weight);
            var copy1 = this.CreateCopy(foodRecord);

            this.ToStringRecords(foodRecord, foodClass);
            Console.WriteLine("Press a key to continue...");
            Console.ReadLine();
            
            this.PrintRecordCopy(copy1);
            Console.WriteLine("Press a key to continue...");
            Console.ReadLine();
            CompareRecords(foodRecord, copy1);
        }

        public FoodRecord GetRecord(string name, double weight)
        {
            int id = new Random().Next(1, 999);
            int calories = new Random().Next(1, 999);
            FoodRecord food = new(id, name, weight, calories);

            return food;
        }

        public Food GetClass(string name, double weight)
        {
            int id = new Random().Next(1, 999);

            Food food = new() { Id = id, Name = name, Weight = weight };
            
            // You can change the Id value either in a constructor or when you first create the object
            // food.Id = 2; Error: LastName is not settable

            return food;
        }

        /**
         * With-expressions allows to create a new value from an
         * existing one. The with-expression works by copying 
         * the full state of the old object into a new one.
         */
        public FoodRecord CreateCopy(FoodRecord record)
        {
            var food = record with { Weight = record.Weight * 2 };

            return food;
        }

        private void PrintRecordCopy(FoodRecord copy)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            OutputHelper.PrintDelimiter('*', 100);
            Console.WriteLine("let's try to double the weight...");
            OutputHelper.PrintDelimiter('*', 100);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{ copy }\n");
            Console.ResetColor();
        }

        private void ToStringRecords(FoodRecord record, Food c)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            OutputHelper.PrintDelimiter('*', 100);
            Console.WriteLine("Look how the toString() method works compared to classes");
            OutputHelper.PrintDelimiter('*', 100);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nThat's a record:\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{record} \n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"And that's a class: \n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{c}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n");
            OutputHelper.PrintDelimiter('*', 100);
            Console.ResetColor();

        }

        /**
         * Records, like Structs, override the virtual Equals(object) method 
         * from the object class in order to have "value-based equality"
         */
        private void CompareRecords(FoodRecord record, FoodRecord copy)
        {
            Console.Clear();
            var record2 = new FoodRecord(record.Id, record.Name, record.Weight, record.Calories);
            var eq = Equals(record, copy);
            var eq2 = Equals(record, record2);

            Console.ForegroundColor = ConsoleColor.Yellow;
            OutputHelper.PrintDelimiter('*', 100);
            Console.WriteLine("Now let's compare the two record.\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Is {record}\n\nequal to\n\n{copy}?\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{eq}\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            OutputHelper.PrintDelimiter('*', 100);
            Console.WriteLine("They are not equal because they have different values.\nLook what happens when we compare two records with the same value: ");
            OutputHelper.PrintDelimiter('*', 100);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Is {record}\n\nequal to\n\n{record2}?\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{eq2}\n");
            Console.ResetColor();
        }
    }
}
