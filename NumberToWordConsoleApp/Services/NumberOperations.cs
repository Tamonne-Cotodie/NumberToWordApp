using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWordConsoleApp.Services
{
   public class NumberOperations
    {

        private readonly Dictionary<int, string> dataCollection = new Dictionary<int, string>();
        private OperationData dataRepo;
      
        private StringBuilder results = new StringBuilder();
        public NumberOperations()
        {
            dataRepo = new OperationData();
            dataCollection = dataRepo.GetOperationData();
           
        }

        public string BuildOutput(string input)
        {

            if (int.Parse(input) == 0)
                return "Zero";

            var formattedInput = input.ToString().Split(new char[] { ',', '.' });
            var counter = 0;

            foreach (var item in formattedInput)
            {
                counter++;
                if (counter == 2)
                    results.Append("And");

                var numericValue = int.Parse(item);
                PrepareFormula(numericValue);

                if (counter == 2)
                    results.AppendFormat(" Cents");
            }

            return results.ToString();
        }
        public string PrepareFormula(int currentNumber)
        {


            if (currentNumber >= 1000)
            {

                currentNumber = GetMillions(currentNumber);

                currentNumber = GetThousands(currentNumber, currentNumber.ToString().Length);
            }

            Textualise(currentNumber);

            return results.ToString().Trim();
        }
        public int Textualise(int currentNumber)
        {
            /*The Sequence Is Modified Everytime An Operation Has Been effected*/
            currentNumber = GetHundreds(currentNumber, currentNumber.ToString().Length);
            currentNumber = GetDoubleUnits(currentNumber, currentNumber.ToString().Length);
            currentNumber = GetSingleUnits(currentNumber, currentNumber.ToString().Length);

            return currentNumber;

        }
        public int GetSingleUnits(int value, int baseValue)
        {
            if (value > 0 && value < 20)
            {
                results.AppendFormat("{0} ", dataCollection[value]);
            }
            else
                GetDoubleUnits(value, baseValue);

            return 0;
        }
        public int GetDoubleUnits(int value, int baseValue)
        {

            if (value >= 20)
            {
                var initialBaseValue = GetBrackets(baseValue);
                var result = (int)(value / initialBaseValue);
                results.AppendFormat("{0} ", dataCollection[result * 10]);

                return (int)(value - (initialBaseValue * result));
            }
            return value;
        }
        public int GetHundreds(int value, int baseValue)
        {
            if (value >= 100)
            {
                var initialBaseValue = GetBrackets(baseValue);

                var result = (int)(value / initialBaseValue);
                results.AppendFormat("{0} {1} ", dataCollection[result], dataCollection[100]);

                return (int)(value - (initialBaseValue * result));
            }

            return value;
        }
        public int GetThousands(int value, int baseValue)
        {

            if (value > 1000)
            {
                /*Cater For The "Thousands Categories" */
                var num = value / 1000;

                /*If Any Other Value Falls Between, Get It If Not, Nothing Will be Appened.*/
                Textualise(num);

                results.AppendFormat("{0} ", dataCollection[1000]);
                value = value - (num * 1000);

                /*Recursively Call The function Untill The Above Condition Is False*/
                return GetThousands(value, value.ToString().Length);

            }

            return value;
        }
        public double GetBrackets(int baseValue)
        {
            return Math.Pow(10, baseValue - 1);
        }
        public int GetMillions(int value)
        {
            /*Append Where Value Is A million.*/
            if (value >= 1000000)
            {
                var result = (value / 1000000);
                results.AppendFormat("{0} {1} ", dataCollection[result], dataCollection[1000000]);
                return value - (1000000 * result);
            }
            return value;
        }


    }
}
