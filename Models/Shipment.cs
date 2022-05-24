using System;
using System.Collections.Generic;

namespace McShippersWebsite.Models
{
    public class Shipment
    {
        public int Id { get; set; }
        public string PickUpPointAddress { get; set; }
        public string PickUpPointShipperName { get; set; }

        public long PickUpPointShipperPhone { get; set; }


        public string DeliveryAddress { get; set; }

        public string DeliveryPointShipperName { get; set; }

        public long DeliveryPointShipperPhone { get; set; }
        public DateTime DeliveryPointDate { get; set; }

        public DateTime PickUpPointDate { get; set; }


        public bool Delivered { get; set; }

        public bool PickedUp { get; set; }

        public virtual ICollection<Commodity> Commodities { get; set; }


    }
}
