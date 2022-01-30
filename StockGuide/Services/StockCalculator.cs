using System;
using System.Linq;

namespace StockGuide.Services
{
    public class StockCalculator
    {
        public double[] GetHistoricalReturnPercentage(double[] stock)
        {
            int actualIndex, pastIndex;
            double[] historicalReturnArray = new double[stock.Length-1];
            
            for (actualIndex = 1, pastIndex = 0; actualIndex < stock.Length; actualIndex++, pastIndex++)
            {
                historicalReturnArray[pastIndex] = ((stock[actualIndex] - stock[pastIndex]) / stock[pastIndex]) * 100;
            }

            return historicalReturnArray.Reverse().ToArray();
        }
        
        public double GetReturnAveragePercentage(double[] values)
        {
            return GetHistoricalReturnPercentage(values).Average();
        }
    }
}
