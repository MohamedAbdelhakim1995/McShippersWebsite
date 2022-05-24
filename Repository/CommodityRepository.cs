using McShippersWebsite.Interfaces;
using McShippersWebsite.Models;

namespace McShippersWebsite.Repository
{
    public class CommodityRepository : ICommedityRepository
    {
        private readonly Context context;

        public CommodityRepository(Context context)
        {
            this.context = context;
        }
        public int insert(Commodity obj)
        {
            context.commodity.Add(obj);

            return context.SaveChanges();
        }
    }
}
