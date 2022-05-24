using McShippersWebsite.Interfaces;
using McShippersWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace McShippersWebsite.Repository
{
    public class ShipmentRepository : IShipmentRepository
    {

        private readonly Context context;
        public ShipmentRepository(Context context)
        {
            this.context = context;
        }
        public int Delete(int id)
        {
            Shipment p = context.shipment.FirstOrDefault(p => p.Id == id);
            context.shipment.Remove(p);
            return context.SaveChanges();
        }

        public List<Shipment> GetAll()
        {
            return context.shipment.ToList();
        }

        public Shipment GetById(int id)
        {
            return context.shipment.FirstOrDefault(p => p.Id == id);
        }

        public List<Shipment> GetByDate(DateTime pickUpDate ,DateTime deliveryDate)
        {
           List<Shipment> shipments=context.shipment.Where(p=>p.PickUpPointDate ==pickUpDate && p.DeliveryPointDate==deliveryDate).ToList();
            return shipments;
        }

        public int Insert(Shipment obj)
        {
            context.shipment.Add(obj);

            return context.SaveChanges();
        }

        public int Update(int id, Shipment obj)
        {
            Shipment p = context.shipment.FirstOrDefault(c => c.Id == id);

            p.PickedUp = obj.PickedUp;
            p.Delivered = obj.Delivered;

            return context.SaveChanges();
        }
    }
}
