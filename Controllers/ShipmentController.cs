using McShippersWebsite.DTOs;
using McShippersWebsite.Interfaces;
using McShippersWebsite.Models;
using McShippersWebsite.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace McShippersWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentController : ControllerBase
    {
        private readonly IShipmentRepository shipmentRepository;
        private readonly ICommedityRepository commodityRepository;

        public ShipmentController(IShipmentRepository shipmentRepository ,ICommedityRepository commodityRepository)
        {
            this.shipmentRepository = shipmentRepository;
            this.commodityRepository = commodityRepository;
        }


        [HttpPost("newShipment")]
        public IActionResult Insert(ShipmentDTO p)
        {
            Shipment newShipment = new Shipment();
           
            newShipment.DeliveryAddress = p.DeliveryAddress;
            newShipment.DeliveryPointDate = new DateTime(p.DeliveryDateYear, p.DeliveryDateMonth, p.DeliveryDateDay);
            newShipment.DeliveryPointShipperName = p.DeliveryPointShipperName;
            newShipment.DeliveryPointShipperPhone = p.DeliveryPointShipperPhone;
            newShipment.PickUpPointAddress = p.PickUpPointAddress;
            newShipment.PickUpPointDate = new DateTime(p.PickUpPointDateYear, p.PickUpPointDateMonth, p.PickUpPointDateDay);
            newShipment.PickUpPointShipperName = p.PickUpPointShipperName;
            newShipment.PickUpPointShipperPhone = p.PickUpPointShipperPhone;
            newShipment.Delivered = false;
            newShipment.PickedUp = false;



            try
            {
                shipmentRepository.Insert(newShipment);

                foreach (var item in p.Commodities)
                {
                    Commodity newCommedity = new Commodity() { Name = item ,ShipmentId=newShipment.Id };
                    commodityRepository.insert(newCommedity);
                }

                return Ok( p);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet]
        public IActionResult GetByDate(DateTime pickUpDate, DateTime deliveryDate)
        {

            List<Shipment> shipments = shipmentRepository.GetByDate(pickUpDate ,deliveryDate);

            if (shipments == null)
            {
                return BadRequest("no shippments");
            }
            return Ok(shipments);

        }
    }
}
