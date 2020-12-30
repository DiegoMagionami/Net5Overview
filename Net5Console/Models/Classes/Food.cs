using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5Console.Models.Classes
{
    public class Food
    {
        // Initial setter to create an immutable data
        public int Id { get; init; }

        public string Name { get; set; }

        public double Weight { get; set; }

        public double Calories => new Random().Next(1, 999);
    }
}
