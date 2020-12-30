using System;
using System.Collections.Generic;
using System.Text;

namespace Net5Console.Models.Records
{
    public record FoodRecord(int Id, string Name, double Weight, double Calories);
}
