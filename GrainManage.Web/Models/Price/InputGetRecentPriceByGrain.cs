
namespace GrainManage.Web.Models.Price
{
    public class InputGetRecentPriceByGrain : BaseInput
    {
        public string PriceType { get; set; }
        public string Grain { get; set; }
    }
}
