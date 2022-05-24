using System.ComponentModel.DataAnnotations.Schema;

namespace McShippersWebsite.Models
{
    public class Commodity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("Shippment")]
        public int ShipmentId { get; set; }

        public Shipment Shippment { get; set; }


    }
}
