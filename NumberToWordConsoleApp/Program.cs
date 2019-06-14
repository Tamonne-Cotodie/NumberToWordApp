using NumberToWordConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWordConsoleApp
{
    class Program
    {
        private static NumberOperations numberOperations;
        public Program()
        {
            numberOperations = new NumberOperations();
        }
        
        static void Main(string[] args)
        {

            var program = new Program();
            Console.Write("Please Enter The Number To Be Translated: ");

            var input = Console.ReadLine();
            var output = numberOperations.BuildOutput(input);

            Console.Write("Your Number Translates To : ");

            Console.WriteLine(output);
            Console.ReadKey();


        }
    }
}
