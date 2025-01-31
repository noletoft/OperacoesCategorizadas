

using TradeCategorization.Interfaces;

namespace TradeCategorization.Models
{
    public class ExpiredCategory : ITradeCategory
    {
        public string CategoryName => "EXPIRED";

        public bool Matches(ITrade trade, DateTime referenceDate)
        {
            return (referenceDate - trade.NextPaymentDate).TotalDays > 30;
        }
    }
}