

using OperacoesCategorizadas.Interfaces;

namespace OperacoesCategorizadas.Models
{
    public class Trade : ITrade
    {
        public double TradeValue { get; }
        public string ClientSector { get; }
        public DateTime NextPaymentDate { get; }

        public Trade(double tradeValue, string clientSector, DateTime nextPaymentDate)
        {
            TradeValue = tradeValue;
            ClientSector = clientSector;
            NextPaymentDate = nextPaymentDate;
        }
    }
}