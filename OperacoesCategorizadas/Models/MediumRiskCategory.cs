

using OperacoesCategorizadas.Interfaces;

namespace OperacoesCategorizadas.Models
{
    public class MediumRiskCategory : ITradeCategory
    {
        public string CategoryName => "MEDIUMRISK";

        public bool Matches(ITrade trade, DateTime referenceDate)
        {
            return trade.TradeValue > 1000000 && trade.ClientSector == "Public";
        }
    }
}