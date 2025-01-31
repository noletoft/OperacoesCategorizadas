
using TradeCategorization.Interfaces;
using TradeCategorization.Models;

namespace TradeCategorization.Manager
{
    public class TradeCategorizationManager
    {
        private readonly List<ITradeCategory> _categories;

        public TradeCategorizationManager()
        {
            // Facilmente adaptavel para novas Categorias, basta criar um nova classe com a sua propria regra
            _categories = new List<ITradeCategory>
            {
                new ExpiredCategory(),
                new HighRiskCategory(),
                new MediumRiskCategory()
            };
        }

        public string CategorizeTrade(ITrade trade, DateTime referenceDate)
        {
            foreach (var category in _categories)
            {
                if (category.Matches(trade, referenceDate))
                {
                    return category.CategoryName;
                }
            }
            return "UNCATEGORIZED";
        }
    }
}