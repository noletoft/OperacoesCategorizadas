

using TradeCategorization.Interfaces;

namespace TradeCategorization.Models
{
    public class HighRiskCategory : ITradeCategory
    {
        public string CategoryName => "HIGHRISK";

        public bool Matches(ITrade trade, DateTime referenceDate)
        {
            return trade.TradeValue > 1000000 && trade.ClientSector == "Private";
        }
    }
}