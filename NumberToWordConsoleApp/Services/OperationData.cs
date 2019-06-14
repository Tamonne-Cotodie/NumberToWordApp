using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWordConsoleApp.Services
{
   public class OperationData
    {
        public readonly Dictionary<int, string> operationData = new Dictionary<int, string>();


        public OperationData() {

            SetOperationData();
        }
        public Dictionary<int, string> GetOperationData()
        {
            
            return operationData;
        }
          public void SetOperationData()
        {
            operationData.Add(0, "Zero");
            operationData.Add(1, "One");
            operationData.Add(2, "Two");
            operationData.Add(3, "Three");
            operationData.Add(4, "Four");
            operationData.Add(5, "Five");
            operationData.Add(6, "Six");
            operationData.Add(7, "Seven");
            operationData.Add(8, "Eight");
            operationData.Add(9, "Nine");
            operationData.Add(10, "Ten");
            operationData.Add(11, "Eleven");
            operationData.Add(12, "Twelve");
            operationData.Add(13, "Thirteen");
            operationData.Add(14, "Fourteen");
            operationData.Add(15, "Fifteen");
            operationData.Add(16, "Sixteen");
            operationData.Add(17, "Seventeen");
            operationData.Add(18, "Eighteen");
            operationData.Add(19, "Nineteen");
            operationData.Add(20, "Twenty");
            operationData.Add(30, "Thirty");
            operationData.Add(40, "Forty");
            operationData.Add(50, "Fifty");
            operationData.Add(60, "Sixty");
            operationData.Add(70, "Seventy");
            operationData.Add(80, "Eighty");
            operationData.Add(90, "Ninety");
            operationData.Add(100, "Hundred");
            operationData.Add(1000, "Thousand");
            operationData.Add(1000000, "Million");



        }



    }
}
