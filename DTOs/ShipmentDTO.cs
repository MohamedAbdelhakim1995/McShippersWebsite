using System;
using System.Collections.Generic;

namespace McShippersWebsite.DTOs
{
    public class ShipmentDTO
    {
        public string PickUpPointAddress { get; set; }
        public string  PickUpPointShipperName { get; set; }

        public long PickUpPointShipperPhone { get; set; }

        public List<string> Commodities { get; set; }

        public string DeliveryAddress { get; set; }

        public string DeliveryPointShipperName { get; set; }

        public long DeliveryPointShipperPhone { get; set; }

        public int PickUpPointDateYear { get; set; }
        public int PickUpPointDateMonth { get; set; }
        public int PickUpPointDateDay { get; set; }


        public int DeliveryDateYear { get; set; }
        public int DeliveryDateMonth { get; set; }
        public int DeliveryDateDay { get; set; }


    }
}
