namespace OperacoesCategorizadas.Interfaces
{
    public interface ITrade
    {
        double TradeValue { get; }
        string ClientSector { get; }
        DateTime NextPaymentDate { get; }
    }
}