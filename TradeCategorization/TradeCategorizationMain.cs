/*
    Note que utilizei o contexo de sintax em Ingles já que 
    a requisicao no PDF sugeriu se tratar de uma demanda externa (internacional),
    logo os nomes de classes e seus atrubutos seguiram esta convencao, o que me 
    ajudou muito por ja trabalhar assim nos ultimos 12 anos.
*/


using TradeCategorization.Manager;

namespace TradeCategorization
{
    public class TradeCategorizationMain
    {
        public static void Main(string[] args)
        { 
            Console.WriteLine("");
            Console.WriteLine("**** Trade Categorization v1.0 ****");
            Console.WriteLine(""); 

            var vManager = new ValidatorManager();

            // Read reference date            
            var referenceDate = vManager.GetDataValida("Enter the reference date (MM/dd/yyyy) : ");            

            // Read number of trades                        
            int numberOfTrades = vManager.GetOperacoesValida("Enter the number of Trades (1 to n) : ");

            var tcManager = new TradeCategorizationManager();

            // Process each trade
            for (int i = 0; i < numberOfTrades; i++)
            {           
                var trade = vManager.ValidaOperacao($"Enter the Trade {i+1} of {numberOfTrades} (tradeValue clientSector nextPaymentDate) : ");

                string category = tcManager.CategorizeTrade(trade, referenceDate);
                Console.WriteLine($"Trade Category Result : {category}");
            }            
        }
    }
}