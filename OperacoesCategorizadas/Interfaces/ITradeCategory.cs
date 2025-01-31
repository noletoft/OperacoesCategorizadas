/*
    Este 'contrato' garante a implementacao de regra a cada categoria criada, 
    tornando a apllicacao facilmente expansivel e sustentavel.
*/

namespace OperacoesCategorizadas.Interfaces
{
    public interface ITradeCategory
    {
        string CategoryName { get; }
        bool Matches(ITrade trade, DateTime referenceDate);
    }
}