
namespace GrainManage.Web.Models.Trade
{
    public class TradeWithContactView : TradeTotalWithAreaView
    {
        public int ContactID { get; set; }
        public string ContactName { get; set; }
        public string Cellphone { get; set; }
    }
}
