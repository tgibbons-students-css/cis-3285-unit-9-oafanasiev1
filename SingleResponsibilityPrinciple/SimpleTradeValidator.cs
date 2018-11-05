
using SingleResponsibilityPrinciple.Contracts;

namespace SingleResponsibilityPrinciple
{
    public class SimpleTradeValidator : ITradeValidator
    {
        private readonly ILogger logger;

        public SimpleTradeValidator(ILogger logger)
        {
            this.logger = logger;
        }

        public bool Validate(string[] tradeData)
        {
            if (tradeData.Length != 3)
            {
                logger.LogWarning("Line malformed. Only {0} field(s) found.", tradeData.Length);
                return false;
            }

            if (tradeData[0].Length != 6)
            {
                logger.LogWarning("Trade currencies malformed: '{0}'", tradeData[0]);
                return false;
            }




            int tradeAmount;
            if (!int.TryParse(tradeData[1], out tradeAmount))
            {
                logger.LogWarning("Trade not a valid integer: '{0}'", tradeData[1]);
                return false;
            }

            int tradeAmount1;
            int.TryParse(tradeData[1], out tradeAmount1);
            if (tradeAmount1 < 1000 || tradeAmount1 > 100000)
            {
                 logger.LogWarning("Trade must be within the range of 1000 and 100000", tradeData[1]);
                return false;
            }



            decimal tradePrice;
            if (!decimal.TryParse(tradeData[2], out tradePrice))
            {
                logger.LogWarning("Trade price not a valid decimal: '{0}'", tradeData[2]);
                return false;
            }

            return true;
        }
    }
}
